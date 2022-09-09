using Telegram.Bot.Types.Enums;
using TgBotFramework;
using TgBotFramework.WrapperExtensions;

namespace BanHubBot;

public static class When
{
    public static bool ThisBotAdded(UpdateContext context) =>
        (context.Update.MyChatMember.NewChatMember.Status == ChatMemberStatus.Member &&
        context.Update.MyChatMember.OldChatMember.Status == ChatMemberStatus.Left) &&
        context.Update.MyChatMember.NewChatMember.User.Username == context.Bot.Username;
    
    public static bool ThisBotRemoved(UpdateContext context) =>
        context.Update.MyChatMember.NewChatMember.Status is ChatMemberStatus.Left or ChatMemberStatus.Kicked &&
        context.Update.MyChatMember.NewChatMember.User.Username == context.Bot.Username;

    public static bool ThisBotPromoted(BanHubContext context) =>
        context.Update.MyChatMember.NewChatMember.Status == ChatMemberStatus.Administrator &&
        context.Update.MyChatMember.NewChatMember.User.Username == context.Bot.Username;
}