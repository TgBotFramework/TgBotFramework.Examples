using TgBotFramework;
using TgBotFramework.WrapperExtensions;

public class ConsoleEchoHandler : IUpdateHandler<SimpleContext>
{
    public async Task HandleAsync(SimpleContext context, UpdateDelegate<SimpleContext> next, CancellationToken cancellationToken)
    {
        Console.WriteLine(context.Update.ToJsonString()); // prints to console any update you receive from Telegram
    }
}