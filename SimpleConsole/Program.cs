using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;
using TgBotFramework;
using TgBotFramework.WrapperExtensions;


await Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<ConsoleEchoHandler>();
    
    services.AddBotService<ExampleContext>("token", builder => builder
            .UseLongPolling(ParallelMode.MultiThreaded, new LongPollingOptions() { DebugOutput = true } )
            .SetPipeline(pipeBuilder => pipeBuilder.Use<ConsoleEchoHandler>())
    );
}).RunConsoleAsync();

public class ExampleContext : BaseUpdateContext { } 

public class ConsoleEchoHandler : IUpdateHandler<ExampleContext>
{
    public async Task HandleAsync(ExampleContext context, UpdateDelegate<ExampleContext> next, CancellationToken cancellationToken)
    {
        Console.WriteLine(context.Update.ToJsonString()); // prints to console any update you receive from Telegram
    }
}