using Telegram.Bot;
using Telegram.Bot.Types;
using TgBotFramework;

namespace BanHubBot;

public class OnBotPromoted : IUpdateHandler<BanHubContext>
{
    public async Task HandleAsync(BanHubContext context, UpdateDelegate<BanHubContext> next, CancellationToken cancellationToken)
    {
        var privileges = context.Update.MyChatMember.NewChatMember as ChatMemberAdministrator;
        if (privileges == null)
            throw new Exception("Error in OnBotPromoted promoted not to admin, wtf");

        if (!privileges.CanInviteUsers)
        {
            await context.Client.SendTextMessageAsync(context.ChatId, "I need \"Invite Users\" privilege, if you want me to handle Join Requests",
                cancellationToken: cancellationToken);
        }
        else
        {
            await context.Client.SendTextMessageAsync(context.ChatId, "Great, now I can handle Join Requests",
                cancellationToken: cancellationToken);
        }
    }
}