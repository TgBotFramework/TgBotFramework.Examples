using BanHubBot.Services;
using Microsoft.Extensions.Logging;
using TgBotFramework;

namespace BanHubBot.Handlers;

public class CallbackHandler : IUpdateHandler<BanHubContext>
{
    private readonly IUsersStore _userStore;
    private readonly ILogger<CallbackHandler> _logger;

    public CallbackHandler(IUsersStore userStore, ILogger<CallbackHandler> logger)
    {
        _userStore = userStore;
        _logger = logger;
    }

    public async Task HandleAsync(BanHubContext context, UpdateDelegate<BanHubContext> next,
        CancellationToken cancellationToken)
    {
        var callback = context.Update.CallbackQuery;
        var chatId = context.Update.CallbackQuery.Message.Chat.Id;
        var userId = context.Update.CallbackQuery.From.Id;

        var ans = _userStore.Get(chatId, userId);

        if (ans == null)
        {
            // всё херня, уже был в чате
        }
        
        // add checks
    }
}