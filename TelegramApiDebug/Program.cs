﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using TgBotFramework;
using TgBotFramework.WrapperExtensions;


await Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddScoped<DebugHandler>();
    
    services.AddBotService<UpdateContext>("<token>", builder => builder
        .UseLongPolling(ParallelMode.SingleThreaded, new LongPollingOptions() { DebugOutput = true })
        .SetPipeline(pipeBuilder => pipeBuilder
            .Use<DebugHandler>()
        )
    );
}).RunConsoleAsync();

public class DebugHandler : IUpdateHandler<UpdateContext>
{
    public async Task HandleAsync(UpdateContext context, UpdateDelegate<UpdateContext> next, CancellationToken cancellationToken)
    {
        // put break point. Then compare console output of update with what you see in debugger in context.Update
        await next(context, cancellationToken);
    }
}