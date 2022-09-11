using Azure;
using Azure.Data.Tables;
using MedsPlanner.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedsPlanner.Api
{
    public static class ActionList
    {
        // TODO: Pass the Partition Key as part of the API request
        public const string PARTITION_KEY = "jessiepalmer";

        public static readonly string AzureTablesUri = Environment.GetEnvironmentVariable("AzureTablesUri");
        public static readonly string AzureTableName = Environment.GetEnvironmentVariable("AzureTableName");
        public static readonly string AzureStorageAccountName = Environment.GetEnvironmentVariable("AzureStorageAccountName");
        public static readonly string AzureStorageAccountKey = Environment.GetEnvironmentVariable("AzureStorageAccountKey");

        [FunctionName("ActionList")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var tableClient = new TableClient(
                new Uri(AzureTablesUri),
                AzureTableName,
                new TableSharedKeyCredential(AzureStorageAccountName, AzureStorageAccountKey));

            Pageable<TableEntity> actionItemEntities = tableClient.Query<TableEntity>(ent => ent.PartitionKey == PARTITION_KEY && 
                                                                                             ent.GetBoolean("Status") != false);

            var actionItems = new List<ActionItem>();
            foreach (TableEntity actionItem in actionItemEntities)
            {
                actionItems.Add(new ActionItem()
                {
                    PartitionKey = actionItem.PartitionKey,
                    RowKey = actionItem.RowKey,
                    ActionType = actionItem.GetString("ActionType"),
                    Time = actionItem.GetString("Time"),
                    Name = actionItem.GetString("Name"),
                    Strength = actionItem.GetString("Strength"),
                    Quantity = actionItem.GetDouble("Quantity"),
                    Unit = actionItem.GetString("Unit"),
                    Type = actionItem.GetString("Type"),
                    Water = actionItem.GetInt32("Water"),
                    Rate = actionItem.GetInt32("Rate"),
                    Application = actionItem.GetString("Application"),
                    //Status = actionItem.GetBoolean("Status")
                });
            }

            //return new OkObjectResult(actionItems.OrderBy(e => e.Time));
            return new OkObjectResult(actionItems);
        }
    }
}
