// See https://aka.ms/new-console-template for more information

using CodeExamples;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TgBotFramework;

await Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json").Build();
    
    services.Configure<BotSettings>(config.GetSection(nameof(ExampleBot)));
    
    SimpleExample.Configure(services);
    //GenericContextExample.Configure(services);
}).RunConsoleAsync();
