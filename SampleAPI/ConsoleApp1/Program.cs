using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Serialization.Json;
using SampleAPI.Models;

namespace SampleAPITest
{
    class Program
    {
        [Test]
        public void TestGet()
        {
            var client = new RestClient("https://localhost:44395/");
            var request = new RestRequest("api/item", Method.GET);
            
            var response = client.Execute(request);

            var result = JsonConvert.DeserializeObject<List<Item>>(response.Content);

            Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(result.First());
        }
    }
}
