using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TgBotFramework;

namespace CodeExamples;

public class SimpleExample
{
    public static IServiceCollection Configure(IServiceCollection serv)
    {
        
        serv.AddSingleton<ConsoleEchoHandler>();
    
        serv.AddBotService<ExampleBot, SimpleContext>(builder => builder
            .UseLongPolling(ParallelMode.MultiThreaded)
            .SetPipeline(pipeBuilder => 
                pipeBuilder.Use<ConsoleEchoHandler>())
        );

        return serv;
    }
}