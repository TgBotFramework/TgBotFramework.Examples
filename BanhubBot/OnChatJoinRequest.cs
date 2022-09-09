using BanHubBot.Challenges;
using BanHubBot.Services;
using Telegram.Bot;
using TgBotFramework;

namespace BanHubBot;

public class OnChatJoinRequest : IUpdateHandler<BanHubContext>
{
    private readonly IChallengeFabric _challengeFabric;
    private readonly IUsersStore _userStore;
    
    public OnChatJoinRequest(IChallengeFabric challengeFabric, IUsersStore userStore)
    {
        _challengeFabric = challengeFabric;
        _userStore = userStore;
    }

    public async Task HandleAsync(BanHubContext context, UpdateDelegate<BanHubContext> next,
        CancellationToken cancellationToken)
    {
        var joinRequest = context.Update.ChatJoinRequest;
        var challenge = _challengeFabric.Build(ChallengeType.SimpleRussian);
        
        var challengeResult = await challenge.SendTaskToChat(context.Client, joinRequest.Chat.Id, joinRequest.From, null, true,
            cancellationToken);
        await context.Client.SendTextMessageAsync(joinRequest.From.Id, "Hello");
        _userStore.Add(challengeResult);
    }
}