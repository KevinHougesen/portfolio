using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.CosmosDB;

namespace Company.Function
{
    public static class OutCounter
    {
        public static async Task UpdateDocumentAsync(Counter counter)
        {
            // Create a CosmosDB client.
            CosmosClient client = new CosmosClient(Environment.GetEnvironmentVariable("CosmosDbConnectionString"));

            // Get the database and collection.
            Database database = client.GetDatabase("AzurePortfolio");
            Container container = database.GetContainer("Counter");

            // Update the document.
            await container.UpsertItemAsync(counter);

            // Close the client.
            client.Dispose();
        }
    }
}
