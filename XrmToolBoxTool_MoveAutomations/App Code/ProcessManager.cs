using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XrmToolBoxTool_MoveAutomations.AppCode
{
    public class ProcessManager
    {
        private readonly IOrganizationService _service;

        public ProcessManager(IOrganizationService service)
        {
            _service = service;
        }

        public List<Entity> LoadProcesses(KeyValuePair<string, Guid> solution)
        {
            var query = new QueryExpression("workflow")
            {
                NoLock = true,
                ColumnSet = new ColumnSet("name", "category", "statecode", "primaryentity"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("type", ConditionOperator.Equal, 1)
                    }
                }
            };

            query.LinkEntities.Add(new LinkEntity
            {
                LinkFromEntityName = "workflow",
                LinkFromAttributeName = "workflowid",
                LinkToAttributeName = "objectid",
                LinkToEntityName = "solutioncomponent",
                LinkEntities =
                {
                    new LinkEntity
                    {
                        LinkFromEntityName = "solutioncomponent",
                        LinkFromAttributeName = "solutionid",
                        LinkToAttributeName = "solutionid",
                        LinkToEntityName = "solution",
                        LinkCriteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("uniquename", ConditionOperator.Equal, solution.Key)
                            }
                        }
                    }
                }
            });

            return _service.RetrieveMultiple(query).Entities.ToList();
        }
    }
}