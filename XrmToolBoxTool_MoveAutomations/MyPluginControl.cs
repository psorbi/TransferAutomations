using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using XrmToolBox.Extensibility;
using XrmToolBoxTool_MoveAutomations.AppCode;
using XrmToolBoxTool_MoveAutomations.Forms;

namespace XrmToolBoxTool_MoveAutomations
{
    public partial class MyPluginControl :  MultipleConnectionsPluginControlBase
    {
        //Variables

        private Settings mySettings;
        private enum serviceType
        {
            Source,
            Target
        }
        private enum componentType
        {
            Process,
            environmentVariableDefinition,
            environmentVariableValue
        }
        private Dictionary<string, Guid> sourceSolutions = new Dictionary<string, Guid>(); 
        private Dictionary<string, Guid> targetSolutions = new Dictionary<string, Guid>();
        //private IOrganizationService sourceService = null;
        private IOrganizationService targetService = null;  
        private List<ProcessInfo> _processInfos;

        //End Variables

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAccounts);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            if(actionName == "AdditionalOrganization")
            {
                if(!AdditionalConnectionDetails.Contains(detail))
                {
                    AdditionalConnectionDetails.Clear();
                    AdditionalConnectionDetails.Add(detail);
                    SetConnectionLabel(detail.ConnectionName, serviceType.Target);
                    RetrieveSolutions(serviceType.Target);
                }
            }
            else
            {
                base.UpdateConnection(newService, detail, actionName, parameter);
                SetConnectionLabel(detail.ConnectionName, serviceType.Source);
                RetrieveSolutions(serviceType.Source);
            }
            
        }
       
        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e) 
        {
            // For now, only support one target org
            if (e.Action.Equals(NotifyCollectionChangedAction.Add))
            {
                var detail = (ConnectionDetail)e.NewItems[0];
                SetConnectionLabel(detail.ConnectionName, serviceType.Target);
                targetService = detail.ServiceClient;
            }
        }
        
        private void SetConnectionLabel(string name, serviceType serviceType) 
        {
            switch (serviceType)
            {
                case serviceType.Source:
                    {
                        lbSourceEnvValue.Text = name;
                        lbSourceEnvValue.ForeColor = Color.Green;
                        break;
                    }

                case serviceType.Target:
                    {
                        lbTargetEnvValue.Text = name;
                        lbTargetEnvValue.ForeColor = Color.Green;
                        break;
                    }
            }
        }
        
        private void RetrieveSolutions(serviceType serviceType)
        {
            IOrganizationService retrieveService = null;

            switch (serviceType)
            {
                case serviceType.Source:
                    {
                        retrieveService = Service;
                        sourceSolutions?.Clear();
                        cbSourceSolution.Items.Clear();
                        cbSourceSolution.ResetText();
                        break;
                    }
            
                case serviceType.Target:
                    {
                        retrieveService = targetService;
                        targetSolutions?.Clear();
                        cbTargetSolution.Items.Clear();
                        cbTargetSolution.ResetText();
                        break;
                    }
            }

            QueryExpression query = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet = new ColumnSet("uniquename", "solutionid"),
                Criteria = new FilterExpression()
            };

            query.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);

            try
            {
                foreach (Entity solution in retrieveService.RetrieveMultiple(query).Entities)
                {
                    if (solution["uniquename"].ToString() != "System" && solution["uniquename"].ToString() != "Active" && solution["uniquename"].ToString() != "Basic" && solution["uniquename"].ToString() != "ActivityFeeds")
                    {                        
                        switch (serviceType)
                        {
                            case serviceType.Source:
                                {
                                    sourceSolutions.Add(solution["uniquename"].ToString(), solution.Id);
                                    cbSourceSolution.Items.Add(solution["uniquename"]);
                                    break;
                                }

                            case serviceType.Target:
                                {
                                    targetSolutions.Add(solution["uniquename"].ToString(), solution.Id);
                                    cbTargetSolution.Items.Add(solution["uniquename"]);
                                    break;
                                }

                        }
                    }
                }
            }
            catch(FaultException<OrganizationServiceFault> ex) 
            {
                throw new Exception(ex.Message);
            }


        }

        private void LoadProcesses(string solution, serviceType serviceType)
        {
            
            //clears the lv
            ClearContent(serviceType);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading processes...",
                Work = (bw, e) =>
                {
                    ProcessManager pManager = null;
                    switch (serviceType)
                    {
                        case serviceType.Source:
                            {
                                pManager = new ProcessManager(Service);
                                break;
                            }

                        case serviceType.Target:
                            {
                                pManager = new ProcessManager(targetService);
                                break;
                            }
                    }
                    _processInfos = pManager.LoadProcesses(solution).Select(p => new ProcessInfo(p, ConnectionDetail, 1)).ToList();
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, $@"Error while loading processes: {e.Error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    DisplayProcesses(serviceType);
                }
            });
        }

        private void DisplayProcesses(serviceType serviceType, object term = null)
        {
            Invoke(new Action(() =>
            {
                ListView listView = new ListView();

                switch (serviceType)
                {
                    case serviceType.Source:
                        {
                            listView = lvSourceProcesses;
                            break;
                        }

                    case serviceType.Target:
                        {
                            listView = lvTargetProcesses;
                            break;
                        }
                }
                listView.Items.Clear();
                listView.Items.AddRange(_processInfos.Where(p =>
                term == null || p.Item.Text.ToLower().IndexOf(term.ToString().ToLower()) >= 0)
                .Select(pi => pi.Item)
                .ToArray());

                foreach (ListViewItem item in listView.Items)
                {
                    var grp = ((ProcessInfo)item.Tag).Category;

                    if (listView.Groups[grp] == null)
                    {
                        listView.Groups.Add(grp, grp);
                    }

                    item.Group = listView.Groups[grp];
                }
            }));
        }

        private void ClearContent(serviceType serviceType)
        {
            switch (serviceType)
            {
                case serviceType.Source:
                    {
                        lvSourceProcesses.Items.Clear();
                        break;
                    }

                case serviceType.Target:
                    {
                        lvTargetProcesses.Items.Clear();
                        break;
                    }
            }
        }

        private void TransferAutomations()
        {
            string solutionName =  cbTargetSolution.Text;
            List<ProcessInfo> selectedProcesses = lvSourceProcesses.CheckedItems.Cast<ListViewItem>().Select(item => (ProcessInfo)item.Tag).ToList();

            if (targetService == null)
            {
                MessageBox.Show("You must connect to a Target Environment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (cbTargetSolution.SelectedItem == null)
            {
                MessageBox.Show("You must select a Target Solution", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (lvSourceProcesses.CheckedItems.Count == 0)
            {
                MessageBox.Show("You must select at least one automation to be transfered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (lvSourceProcesses.CheckedItems.Count > 0 && AdditionalConnectionDetails.Count > 0)
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Transfering Automations",
                    Work = (w, e) =>
                    {
                        // This code is executed in another thread
                        // ExecuteMethod(CreateProcessesInTarget(solutionName, selectedProcesses));
                        CreateProcessesInTarget(solutionName, selectedProcesses);

                        e.Result = 1;
                    },
                    ProgressChanged = e =>
                    {
                        SetWorkingMessage(e.UserState.ToString());
                    },
                    PostWorkCallBack = e =>
                    {
                        if (ErrorHandling.Errors == null)
                        {
                            LoadProcesses(solutionName, serviceType.Target);
                        }
                        if (ErrorHandling.Errors != null)
                        {
                            LoadProcesses(solutionName, serviceType.Target);

                            ErrorList errors = new ErrorList();
                            errors.ShowDialog();
                            return;
                        }
                    },
                    AsyncArgument = null,
                    // Progress information panel size
                    MessageWidth = 340,
                    MessageHeight = 150
                });
                
                
            }
        }

        private void CreateProcessesInTarget(string solutionName, List<ProcessInfo> selectedProcesses)
        {
            Entity sourceProcess = new Entity();
            ColumnSet columns = new ColumnSet("asyncautodelete", "businessprocesstype", "category", "clientdata", "componentstate", "createmetadata",
                "createstage", "definition", "deletestage", "description", "entityimage", "formid", "inputparameters", "inputs", "introducedversion", "iscrmuiworkflow",
                "ismanaged", "istransacted", "languagecode", "metadata", "mode", "name", "ondemand", "outputs", "primaryentity", "processorder", "processroleassignment",
                "processtriggerscope", "rank", "rendererobjecttypecode", "runas", "schemaversion", "scope", "subprocess", "suspensionreasondetails",
                "syncworkflowlogonfailure", "throttlingbehavior", "triggeroncreate", "triggerondelete", "triggeronupdateattributelist", "type", "uiflowtype", "uniquename",
                "updatestage", "versionnumber", "workflowid", "workflowidunique", "xaml"); //owner set by dynamics on create - "statecode","statuscode",
            String clientDataJson;
            ErrorHandling.ClearErrors();


            foreach (var item in selectedProcesses)
            {
                try
                {
                    sourceProcess = Service.Retrieve(entityName: item.LogicalName, id: item.Id, columnSet: columns);
                    clientDataJson = sourceProcess.GetAttributeValue<String>("clientdata");
                    
                    //if turn workflow on is checked

                    //if workflow is a Modern Flow (category = 5), handle the Connection References and Environment Variables
                    if (sourceProcess.GetAttributeValue<OptionSetValue>("category").Value == 5)
                    {
                        sourceProcess["clientdata"] = EditConnectionReferences(clientDataJson);
                        HandleEnvironmentVariables(clientDataJson, solutionName);
                    }

                    //add a condition to check for exitsting process in target?

                    targetService.Create(sourceProcess);

                    //Create the Solution Component
                    var newProcess = targetService.Retrieve(item.LogicalName, item.Id, new ColumnSet("workflowid"));
                    if(newProcess.Id != null)
                    {
                        CreateSolutionComponent(newProcess.Id, solutionName, componentType.Process);
                    }
                    

                }
                catch (Exception ex)
                {
                    ErrorHandling.AddError(item.Name, ex);
                }

            }
        }

        private void CreateSolutionComponent(Guid Id, string solutionUniqueName, componentType type)
        {
            AddSolutionComponentRequest record = null;
            int componentInt = -1;

            switch (type)
            {
                case componentType.Process:
                    componentInt = 29;
                    break;
                
                case componentType.environmentVariableDefinition:
                    componentInt = 380;
                    break;

                case componentType.environmentVariableValue:
                    componentInt = 381;
                    break;
            }

            record = new AddSolutionComponentRequest()
            {
                ComponentType = componentInt,
                ComponentId = Id,
                SolutionUniqueName = solutionUniqueName
            };

            var response = (AddSolutionComponentResponse)targetService.Execute(record); 
        }

        private string EditConnectionReferences(String clientDataJson)
        { 
            //edit the JSON to remove the Connection References
            JObject clientData = JObject.Parse(clientDataJson);
            JObject clientDataProperties = (JObject)clientData["properties"];

            clientDataProperties["connectionReferences"] = null;

            return(clientData.ToString());
        }

        private void HandleEnvironmentVariables(String clientDataJson, string solutionName) 
        {
            //JSON from selected automation
            JObject clientData = JObject.Parse(clientDataJson);

            Dictionary<string, FlowVariable> parameters = new Dictionary<string, FlowVariable>();
            parameters = clientData["properties"]["definition"]["parameters"].ToObject<Dictionary<string, FlowVariable>>();

            //if does not start with $connections or $authentication it's an environment variable
            foreach (KeyValuePair<string, FlowVariable> pair in parameters)
            {
                if (pair.Key != "$connections" &&  pair.Key != "$authentication")
                {
                    if (!CheckForEnvironmentVariables(pair))
                    {
                        CreateEnvironmentVariable(pair, solutionName);
                    }
                }
            }
        }

        private bool CheckForEnvironmentVariables(KeyValuePair<string, FlowVariable> enVar)
        {
            //Query target environment for variable with same schema name, return true if record exists
            Dictionary<string, string> metadata = enVar.Value.Metadata;
            string schemaName = enVar.Value.Metadata["schemaName"];


            string query = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' returntotalrecordcount='true'>
                <entity name='environmentvariabledefinition'>
                <attribute name='environmentvariabledefinitionid'/>
                <attribute name='schemaname'/>
                <attribute name='createdon'/>
                <order attribute='schemaname' descending='false'/>
                <filter type='and'>
                <condition attribute='schemaname' operator='eq' value='";
            query += schemaName;
            query +=  "'/></filter></entity></fetch>";


            EntityCollection result = targetService.RetrieveMultiple(new FetchExpression(query)); 

            if (result.TotalRecordCount > 0)
            {
                return true;
            }
            else return false;
            
        }

        private void CreateEnvironmentVariable(KeyValuePair<string, FlowVariable> enVar, string solutionName)
        {
            Dictionary<string, string> metadata = enVar.Value.Metadata;
            string schemaName = enVar.Value.Metadata["schemaName"];
            Entity enVarDefinition = new Entity();

            //environment variable definition with matching schemaName
            string query = @"<fetch version='1.0' top='1' output-format='xml-platform' mapping='logical' distinct='false'>
                <entity name='environmentvariabledefinition'>
                <attribute name='environmentvariabledefinitionid'/>
                <attribute name='schemaname'/>
                <attribute name='createdon'/>
                <attribute name='valueschema'/>
                <attribute name='type'/>
                <attribute name='statuscode'/>
                <attribute name='statecode'/>
                <attribute name='secretstore'/>
                <attribute name='parentdefinitionid'/>
                <attribute name='parameterkey'/>
                <attribute name='isrequired'/>
                <attribute name='ismanaged'/>
                <attribute name='hint'/>
                <attribute name='displayname'/>
                <attribute name='description'/>
                <attribute name='defaultvalue'/>
                <attribute name='apiid'/>
                <attribute name='overriddencreatedon'/>
                <order attribute='schemaname' descending='false'/>
                <filter type='and'>
                <condition attribute='schemaname' operator='eq' value='";
            query += schemaName;
            query += "'/></filter></entity></fetch>";

            EntityCollection definitionResult = Service.RetrieveMultiple(new FetchExpression(query));

            enVarDefinition = definitionResult[0];

            //Create the environment variable definition in the target environment
            targetService.Create(enVarDefinition);

            //Create solution component for Environment Variable Definition
            var newEnVarDef = targetService.Retrieve("environmentvariabledefinition", enVarDefinition.Id, new ColumnSet("environmentvariabledefinitionid"));
            if (newEnVarDef.Id != null)
            {
                CreateSolutionComponent(newEnVarDef.Id, solutionName, componentType.environmentVariableDefinition);
            }

            //environment variable value with lookup to definition
            string definitionGUID = enVarDefinition.Id.ToString();
            Entity enVarValue = new Entity();

            string valueQuery = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' returntotalrecordcount='true'>
                <entity name='environmentvariablevalue'>
                <attribute name='environmentvariablevalueid'/>
                <attribute name='value'/>
                <attribute name='createdon'/>
                <attribute name='statuscode'/>
                <attribute name='statecode'/>
                <attribute name='schemaname'/>
                <attribute name='ismanaged'/>
                <attribute name='environmentvariabledefinitionid'/>
                <order attribute='createdon' descending='true'/>
                <filter type='and'>
                <condition attribute='environmentvariabledefinitionid' operator='eq' value='{";
            valueQuery += definitionGUID;
            valueQuery += "}'/></filter> </entity></fetch>";

            EntityCollection valueResult = Service.RetrieveMultiple(new FetchExpression(valueQuery));

            for (var i = 0; i < valueResult.TotalRecordCount; i++) 
            {
                enVarValue = valueResult[i];
                targetService.Create(enVarValue);

                //Create solution component for Environment Variable Value
                var newEnVarValue = targetService.Retrieve("environmentvariablevalue", enVarValue.Id, new ColumnSet("environmentvariablevalueid"));
                if (newEnVarValue.Id != null)
                {
                    CreateSolutionComponent(newEnVarValue.Id, solutionName, componentType.environmentVariableValue);
                }
            }
            
        }

        private void btnSelectTarget_Click(object sender, EventArgs e)
        {
            ExecuteMethod(AddAdditionalOrganization);
        }

        private void cbSourceSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            string solutionName = cbSourceSolution.Text;

            if (solutionName != null)
            {
                LoadProcesses(solutionName, serviceType.Source);
            }
        }

        private void cbTargetSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            string solutionName = cbTargetSolution.Text;

            if (solutionName != null)
            {
                LoadProcesses(solutionName, serviceType.Target);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            TransferAutomations();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            lvSourceProcesses.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = chkSelectAll.Checked);
        }
    }
}