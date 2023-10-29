using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Http.AspNetCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker.Extensions.CosmosDB;
using Microsoft.AspNetCore.Http;

namespace tests
{
    public class TestCounter
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async Task Http_trigger_should_return_known_string()
        {
            var counter = new Company.Function.Counter();
            counter.Id = "1";
            counter.Count = 2;
            var requestData = MockHelpers.CreateHttpRequestData();


            var response = (HttpResponseData) await Company.Function.GetVisitorCounter.RunAsync(requestData, counter, logger);
            Assert.Equal(3, counter.Count);
        }

    }
}