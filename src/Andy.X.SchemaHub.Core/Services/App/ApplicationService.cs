using Andy.X.SchemaHub.Core.Extensions;
using Andy.X.SchemaHub.IO.Locations;
using Andy.X.SchemaHub.Model.Configurations;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace Andy.X.SchemaHub.Core.Services.App
{
    public class ApplicationService
    {
        public ApplicationService(ILogger<ApplicationService> logger, IServiceProvider serviceProvider, NodeConfiguration nodeConfiguration)
        {
            var generalColor = Console.ForegroundColor;

            Console.WriteLine($"                   Starting {ApplicationProperties.Name}");
            Console.WriteLine("                   Set your information in motion.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  ###"); Console.ForegroundColor = generalColor; Console.WriteLine("      ###");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("    ###"); Console.ForegroundColor = generalColor; Console.Write("  ###");
            //Console.WriteLine("       Andy X 3.0.0-alpha. Copyright (C) 2022 Buildersoft LLC");
            Console.WriteLine($"       {ApplicationProperties.ShortName} {ApplicationProperties.Version}. Developed with (love) by Buildersoft LLC.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("      ####         "); Console.ForegroundColor = generalColor; Console.WriteLine("Licensed under the Apache License 2.0. See https://bit.ly/3DqVQbx");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    ###  ###");
            Console.Write("  ###      ###     "); Console.ForegroundColor = generalColor; Console.WriteLine("Andy X is an open-source distributed streaming platform designed to deliver the best performance possible for high-performance data pipelines, streaming analytics, streaming between microservices and data integrations.");
            Console.WriteLine("");

            ExposePorts();

            Console.WriteLine("");
            Console.WriteLine($"                   Starting {ApplicationProperties.ShortName}...");
            Console.WriteLine("\n");
            logger.LogInformation($"Starting {ApplicationProperties.ShortName}...");
            Console.WriteLine("");
            logger.LogInformation($"Server environment:os.name: {GetOSName()}");
            logger.LogInformation($"Server environment:os.platform: {Environment.OSVersion.Platform}");
            logger.LogInformation($"Server environment:os.version: {Environment.OSVersion}");
            logger.LogInformation($"Server environment:os.is64bit: {Environment.Is64BitOperatingSystem}");
            logger.LogInformation($"Server environment:domain.user.name: {Environment.UserDomainName}");
            logger.LogInformation($"Server environment:user.name: {Environment.UserName}");
            logger.LogInformation($"Server environment:processor.count: {Environment.ProcessorCount}");
            logger.LogInformation($"Server environment:dotnet.version: {Environment.Version}");
            Console.WriteLine("");

            logger.LogInformation("Update settings");
            logger.LogInformation($"Node identifier is '{nodeConfiguration.NodeId}'");

            logger.LogInformation($"{ApplicationProperties.ShortName} is ready");


        }

        private static void ExposePorts()
        {
            var exposedUrls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")!.Split(';');
            foreach (var url in exposedUrls)
            {
                try
                {
                    var u = new Uri(url);
                    if (u.Scheme == "https")
                        Console.WriteLine($"                   Port exposed {u.Port} SSL");
                    else
                        Console.WriteLine($"                   Port exposed {u.Port}");
                }
                catch (Exception)
                {
                    if (url.StartsWith("https://"))
                        Console.WriteLine($"                   Port exposed {url.Split(':').Last()} SSL");
                    else
                        Console.WriteLine($"                   Port exposed {url.Split(':').Last()}");
                }
            }
        }

        public static void TryCreateDataDirectory()
        {
            if (Directory.Exists(AppLocations.GetDataDirectory()) != true)
                Directory.CreateDirectory(AppLocations.GetDataDirectory());

            if (Directory.Exists(AppLocations.GetStoreDirectory()) != true)
                Directory.CreateDirectory(AppLocations.GetStoreDirectory());

            if (Directory.Exists(AppLocations.GetSchemasDirectory()) != true)
                Directory.CreateDirectory(AppLocations.GetSchemasDirectory());

            if (Directory.Exists(AppLocations.GetLogsDirectory()) != true)
                Directory.CreateDirectory(AppLocations.GetLogsDirectory());
        }

        private static string GetOSName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "Windows";
            }
            else if (RuntimeInformation.IsOSPlatform(osPlatform: OSPlatform.OSX))
            {
                return "MacOS";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "Linux";
            }
            else
            {
                return "NOT_SUPPORTED";
            }

        }
    }
}