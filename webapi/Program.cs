using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureAppConfiguration(((context, builder) =>
                {
                    var environmentName = (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development").ToLower();
                    var platformName = "sample-platform";
                    var serviceName = "account-service";
                    
                    builder.AddJsonFile("appsettings.json");
                    builder.AddEnvironmentVariables();

                    AWSOptions awsOptions = null;

                    if (Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID") != null)
                    {
                        awsOptions = new AWSOptions();
                        awsOptions.Region = RegionEndpoint.USEast1;
                        awsOptions.Credentials = new EnvironmentVariablesAWSCredentials();
                    }

                    var awsParameterProcessor = new AWSParameterProcessor();
                    
                    builder.AddSystemsManager((source) =>
                    {
                        source.Path = $"/{platformName}/{environmentName}";
                        source.AwsOptions = awsOptions;
                        source.ParameterProcessor = awsParameterProcessor;
                    });

                    builder.AddSystemsManager((source) =>
                    {
                        source.Path = $"/{platformName}/{serviceName}/{environmentName}";
                        source.AwsOptions = awsOptions;
                        source.ParameterProcessor = awsParameterProcessor;
                    }); 
                }));
    }
}
