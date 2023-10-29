using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker.Extensions.CosmosDB;
using Microsoft.AspNetCore.Http;

namespace Company.Function
{
    public class GetVisitorCounter
    {

        [Function("GetVisitorCounter")]
        public static async Task<HttpResponseData> RunAsync(
            [HttpTrigger(
                AuthorizationLevel.Function, 
                "get", 
                "post"
                )] HttpRequestData req,

            [CosmosDBInput(
                databaseName:"AzurePortfolio", 
                containerName:"Counter", 
                Connection = "CosmosDbConnectionString", 
                Id = "1", 
                PartitionKey = "1"
                )] Counter counter,
                
            FunctionContext Context
            )
        {
            // Function starts here
            var logger = Context.GetLogger("GetVisitorCounter");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            // Increments visitor counter
            counter.Count++;

            // Updates the Cosmos DB
            await OutCounter.UpdateDocumentAsync(counter);

            // Create Json Object for API
            var jsonToReturn = JsonConvert.SerializeObject(counter);

            // Returns the new visitor count to the user.
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString(jsonToReturn);
            return response;
    }
}
}
