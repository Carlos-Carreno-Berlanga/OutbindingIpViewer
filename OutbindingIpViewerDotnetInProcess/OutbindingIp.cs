using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Environment;

namespace OutbindingIpViewerDotnetInProcess
{
    public class OutbindingIp
    {
        private readonly HttpClient _httpClient;
        public OutbindingIp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [FunctionName("OutbindingIp")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            var ipAddres = await _httpClient.GetAsync(GetEnvironmentVariable("requestIpUrl"));
            return new OkObjectResult("Ipaddres:" + ipAddres);


            log.LogInformation("C# HTTP trigger function processed a request.");
            string result = req.HttpContext.Connection.RemoteIpAddress.ToString();

            return new OkObjectResult(result);

        }
    }
}
