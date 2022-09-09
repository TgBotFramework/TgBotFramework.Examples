using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using TgBotFramework;
using TgBotFramework.Stages;
using TgBotFramework.WrapperExtensions;

await Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    
    services.AddBotService<ExampleContext>("token", builder => builder
            .UseStages()
            .UseStages<InMemoryVault<CustomStage>, CustomStage, ExampleContext>(StageStrategy.PerChat) // same thing
        .UseLongPolling(ParallelMode.MultiThreaded)
        .SetPipeline(pipeBuilder => pipeBuilder.Use<StepEchoHandler>())
    );
    
    services.AddSingleton<StepEchoHandler>();
}).RunConsoleAsync();

public class ExampleContext : UpdateContext, IStageContext
{
    public IUserState UserStage { get; set; }
    public CustomStage StageData { get; set; }
}

public class CustomStage : BaseStage
{
    
}

public class StepEchoHandler : IUpdateHandler<ExampleContext>
{
    public async Task HandleAsync(ExampleContext context, UpdateDelegate<ExampleContext> next, CancellationToken cancellationToken)
    {
        context.UserStage.Step++;
        await context.Client.SendTextMessageAsync(context.ChatId, context.UserStage.Step.ToString(), cancellationToken: cancellationToken);
    }
}