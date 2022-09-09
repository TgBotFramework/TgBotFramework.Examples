using BanHubBot.Challenges;
using BanHubBot.Services;
using Telegram.Bot.Types.Enums;
using TgBotFramework;

namespace BanHubBot.Handlers;

public class NewChatMemberHandler : IUpdateHandler<BanHubContext>
{
    private readonly IChallengeFabric _challengeFabric;
    private readonly IUsersStore _userStore;

    public NewChatMemberHandler(IChallengeFabric challengeFabric, IUsersStore userStore)
    {
        _challengeFabric = challengeFabric;
        _userStore = userStore;
    }
    
    public async Task HandleAsync(BanHubContext context, UpdateDelegate<BanHubContext> next, CancellationToken cancellationToken)
    {
        var chatMember = context.Update.ChatMember ?? throw new Exception("Fuck...");
        if (chatMember.NewChatMember.Status == ChatMemberStatus.Restricted)
        {
            // old chat member, ignore?
        }
        else if (chatMember.OldChatMember.Status == ChatMemberStatus.Member)
        {
            // new or old returning
            var challenge = _challengeFabric.Build(ChallengeType.SimpleRussian);
            var challengeResult = await challenge.SendTaskToChat(context.Client, chatMember.Chat.Id, chatMember.From, null, false, cancellationToken);
            _userStore.Add(challengeResult);
        } // all other options.. we don't care
    }
}