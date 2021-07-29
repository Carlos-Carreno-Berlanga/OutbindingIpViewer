using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace OutbindingIpViewerDotnetInProcess
{
    public static class OutbindingIp
    {
        [FunctionName("OutbindingIp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
         
            log.LogInformation("C# HTTP trigger function processed a request.");
            string result = req.HttpContext.Connection.RemoteIpAddress.ToString();

           return new OkObjectResult(result);

        }
    }
}
