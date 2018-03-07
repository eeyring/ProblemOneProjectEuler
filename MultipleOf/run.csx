using System;

public static void Run(string myQueueItem, ICollector<string> outputMultiple, TraceWriter log)
{
    log.Info($"Number is: {myQueueItem}");

    var number = int.Parse(myQueueItem);

    if (number % 5 == 0)
    {
        log.Info($"Number {number} is a multiple of 5");
        outputMultiple.Add(myQueueItem);
    } else if (number % 3 == 0)
    {
        log.Info($"Number {number} is a multiple of 3");
        outputMultiple.Add(myQueueItem);
    } else {
        log.Info($"You number means nothing!");
    }
}
