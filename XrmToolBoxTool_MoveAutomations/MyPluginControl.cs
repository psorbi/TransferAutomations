using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
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
using XrmToolBox.Extensibility;
using XrmToolBoxTool_MoveAutomations.AppCode;

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
            

            //if (mySettings != null && detail != null)
            //{
            //    mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
            //    LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            //}
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
                        break;
                    }
            
                case serviceType.Target:
                    {
                        retrieveService = targetService;
                        targetSolutions?.Clear();
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

                    //foreach (var pi in _processInfos)
                    //{
                    //    var grp = pi.Category;

                    //    if (lvProcesses.Groups[grp] == null)
                    //    {
                    //        lvProcesses.Groups.Add(grp, grp);
                    //    }

                    //    pi.Item.Group = lvProcesses.Groups[grp];
                    //}

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
                /*.Where(p => chkShowActions.Checked && p.CategoryCode == 3
                    || chkShowBusinessProcessFlows.Checked && p.CategoryCode == 4
                    || chkShowBusinessRules.Checked && p.CategoryCode == 2
                    || chkShowModernFlows.Checked && p.CategoryCode == 5
                    || chkShowWorkflows.Checked && p.CategoryCode == 0
                )*/ //select which automation to add to list view
                /*.Where(p => !chkShowOnlyDifference.Checked || chkShowOnlyDifference.Checked && p.HasDifference)*/ //when comparing only add processes with different states
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

            if (lvSourceProcesses.CheckedItems.Count == 0)
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
                        if (e.Error == null)
                        {
                            LoadProcesses(solutionName, serviceType.Target);
                        }
                        if (e.Error != null)
                        {
                            MessageBox.Show(this, $@"Error while transferring processes: {e.Error.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                "updatestage", "versionnumber", "workflowid", "workflowidunique", "xaml"); //owner set by dynamics on create, set solution id separately - "statecode","statuscode",

            foreach (var item in selectedProcesses)
            {
                try
                {
                    sourceProcess = Service.Retrieve(entityName: item.LogicalName, id: item.Id, columnSet: columns);

                    //add a condition to check for exitsting process in target



                    targetService.Create(sourceProcess);

                    //Create the Solution Component
                    var newProcess = targetService.Retrieve(item.LogicalName, item.Id, new ColumnSet("workflowid"));
                    if(newProcess.Id != null)
                    {
                        CreateProcessSolutionComponent(newProcess.Id, solutionName);
                    }
                    

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); //replace this with a log?
                }

            }
        }

        private void CreateProcessSolutionComponent(Guid workflowId, string solutionUniqueName)
        {

            AddSolutionComponentRequest request = new AddSolutionComponentRequest()
            {
                ComponentType = 29,
                ComponentId = workflowId,
                SolutionUniqueName = solutionUniqueName
            };

            var response = (AddSolutionComponentResponse)targetService.Execute(request); 
        }
        private void btnSelectTarget_Click(object sender, EventArgs e)
        {
            ExecuteMethod(AddAdditionalOrganization);
        }

        private void cbSourceSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            //KeyValuePair<string, Guid> solutionKVP = sourceSolutions.FirstOrDefault(x => x.Key == cbSourceSolution.Text);
            string solutionName = cbSourceSolution.Text;

            if (solutionName != null)
            {
                LoadProcesses(solutionName, serviceType.Source);
            }
        }

        private void cbTargetSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            //KeyValuePair<string, Guid> solutionKVP = targetSolutions.FirstOrDefault(x => x.Key == cbTargetSolution.Text);
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
    }
}