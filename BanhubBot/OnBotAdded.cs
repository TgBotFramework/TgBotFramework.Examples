using Telegram.Bot;
using TgBotFramework;

namespace BanHubBot;

public class OnBotAdded : IUpdateHandler<BanHubContext>
{
    public async Task HandleAsync(BanHubContext context, UpdateDelegate<BanHubContext> next, CancellationToken cancellationToken)
    {
        // add settings menu
        await context.Client.SendTextMessageAsync(context.ChatId, "Hi, don't forget to make me administrator", cancellationToken: cancellationToken);
    }
}