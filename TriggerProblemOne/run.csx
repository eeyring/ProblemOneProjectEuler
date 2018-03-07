using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, ICollector<string> outputNumber, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    string numberString = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "number", true) == 0)
        .Value;

    if (numberString == null)
    {
        // Get request body
        dynamic data = await req.Content.ReadAsAsync<object>();
        numberString = data?.number;
    }

    var number = int.Parse(numberString);

    for (var i = 0; i < number; i++)
    {
        outputNumber.Add(i.ToString());
    }

    return numberString == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a number on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Hello " + numberString);
}
