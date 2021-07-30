using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(OutbindingIpViewerDotnetInProcess.Startup))]
namespace OutbindingIpViewerDotnetInProcess
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {


            builder.Services.AddHttpClient("httpCLient", opts =>
            {
                opts.Timeout = TimeSpan.FromSeconds(600);
            });
        }
    }
}
