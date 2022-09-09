using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using TgBotFramework;

namespace BanHubBot.Handlers;

public class DebugHandler : IUpdateHandler<BanHubContext>
{
    public async Task HandleAsync(BanHubContext context, UpdateDelegate<BanHubContext> next, CancellationToken cancellationToken)
    {
        //var link = await context.Client.CreateChatInviteLinkAsync("-1001449134392", createsJoinRequest: true);
        await context.Client.SendTextMessageAsync(context.ChatId, "Hello",
            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData("1", "1")));
        // put break point. Then compare console output of update with what you see in debugger in context.Update
        await next(context, cancellationToken);
    }
}