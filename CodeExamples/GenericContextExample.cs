using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using TgBotFramework;
using TgBotFramework.WrapperExtensions;

namespace CodeExamples;

public static class GenericContextExample
{
    public static IServiceCollection Configure(IServiceCollection serv)
    {
        serv.AddSingleton<GenericConsoleEchoHandler>();
        serv.AddSingleton<GenericStartCommand>();

        serv.AddBotService<ExampleBot, GenericContext<object>>(builder => builder
            .UseLongPolling(ParallelMode.MultiThreaded)
            .SetPipeline(pipeBuilder => pipeBuilder
                .UseCommand<GenericStartCommand>("start")
                .Use<GenericConsoleEchoHandler>()
            )
        );

        return serv;
    }
}

public class GenericStartCommand : CommandBase<GenericContext<object>>
{
    public override async Task HandleAsync(GenericContext<object> context, UpdateDelegate<GenericContext<object>> next, string[] args, CancellationToken cancellationToken)
    {
        await context.Client.SendTextMessageAsync(context.Update.GetChat().Id, "Hello", cancellationToken: cancellationToken);
    }
}

public class GenericConsoleEchoHandler : IUpdateHandler<GenericContext<object>>
{
    public async Task HandleAsync(GenericContext<object> context, UpdateDelegate<GenericContext<object>> next, CancellationToken cancellationToken)
    {
        Console.WriteLine("Hello");
    }
}

public class GenericContext<T> : UpdateContext
{
    private T State { get; set; }
}

