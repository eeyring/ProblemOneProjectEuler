#r "Microsoft.WindowsAzure.Storage"

using System;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;

public class multipleof : TableEntity
{
    public int sumOfMutliples { get; set; }
}

public static void Run(string myQueueItem, ICollector<multipleof> outputSumOfMultipleTable, TraceWriter log)
{
    log.Info($"C# Queue trigger function processed: {myQueueItem}");

    outputSumOfMultipleTable.Add(new multipleof {
            PartitionKey = "test",
            RowKey = myQueueItem,
            sumOfMutliples = int.Parse(myQueueItem)
        });    
}
