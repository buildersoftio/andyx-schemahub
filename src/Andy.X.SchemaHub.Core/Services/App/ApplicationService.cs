﻿using Microsoft.Extensions.Logging;

namespace Andy.X.SchemaHub.Core.Services.App
{
    public class ApplicationService
    {
        public ApplicationService(ILogger<ApplicationService> logger, IServiceProvider serviceProvider)
        {
            var generalColor = Console.ForegroundColor;

            Console.WriteLine("                   Starting Buildersoft Andy X | SchemaHub");
            //Console.WriteLine("                   Copyright (C) 2022 Buildersoft LLC");
            Console.WriteLine("                   Set your information in motion.");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  ###"); Console.ForegroundColor = generalColor; Console.WriteLine("      ###");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("    ###"); Console.ForegroundColor = generalColor; Console.Write("  ###");
            //Console.WriteLine("       Andy X 3.0.0-alpha. Copyright (C) 2022 Buildersoft LLC");
            Console.WriteLine("       Andy X | SchemaHub 3.0.0-alpha1. Developed with (love) by Buildersoft LLC.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("      ####         "); Console.ForegroundColor = generalColor; Console.WriteLine("Licensed under the Apache License 2.0. See https://bit.ly/3DqVQbx");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    ###  ###");
            Console.Write("  ###      ###     "); Console.ForegroundColor = generalColor; Console.WriteLine("Andy X is an open-source distributed streaming platform designed to deliver the best performance possible for high-performance data pipelines, streaming analytics, streaming between microservices and data integrations.");
            Console.WriteLine("");

            ExposePorts();

            Console.WriteLine("");
            Console.WriteLine("                   Starting Andy X | SchemaHub...");
            Console.WriteLine("\n");
            logger.LogInformation("Starting Andy X | SchemaHub...");
            logger.LogInformation("Update settings");

            //if (Environment.GetEnvironmentVariable("ANDYX_EXPOSE_CONFIG_ENDPOINTS").ToLower() == "true")
            //    logger.LogInformation("Configuration endpoints are exposed");

            logger.LogInformation("Andy X SchemaHub is ready");


        }

        private static void ExposePorts()
        {
            var exposedUrls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS").Split(';');
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
    }
}
