using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker;

namespace Company.Function
{
    public class Counter
    {

            [JsonProperty(propertyName:"id")]
            public string Id {get ; set;}
            
            [JsonProperty(propertyName:"count")]
            public int Count {get ; set;}
    }
}
