using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using TgBotFramework;
using TgBotFramework.WrapperExtensions;


await Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<ConsoleEchoHandler>();
    services.AddSingleton<StartCommandExample>();
    services.AddBotService<ExampleContext>("<token>", builder => builder
        .UseLongPolling(ParallelMode.SingleThreaded, new LongPollingOptions() { DebugOutput = true })
        .SetPipeline(pipeBuilder => pipeBuilder
                .UseCommand<StartCommandExample>("start")
                .Use<ConsoleEchoHandler>()
                )
    );
}).RunConsoleAsync();

public class ExampleContext : UpdateContext { } 

public class ConsoleEchoHandler : IUpdateHandler<ExampleContext>
{
    public async Task HandleAsync(ExampleContext context, UpdateDelegate<ExampleContext> next, CancellationToken cancellationToken)
    {
        Console.WriteLine(context.Update.ToJsonString());
    }
}

public class StartCommandExample : CommandBase<ExampleContext>
{
    public override async Task HandleAsync(ExampleContext context, UpdateDelegate<ExampleContext> next, string[] args, CancellationToken cancellationToken)
    {
        await context.Client.SendTextMessageAsync(context.ChatId, "Hello");
    }
}