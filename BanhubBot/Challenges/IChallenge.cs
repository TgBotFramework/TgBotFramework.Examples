using Telegram.Bot;
using Telegram.Bot.Types;

namespace BanHubBot.Challenges;

public interface IChallenge
{
    /// <summary>
    /// Sends challenge to specific chat and returns right result
    /// </summary>
    /// <param name="client">telegram client to send request with</param>
    /// <param name="chatId">Chat to send challenge to</param>
    /// <param name="user"></param>
    /// <param name="messageId">Optional. Reply to message</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ChallengeAnswer> SendTaskToChat(ITelegramBotClient client, long chatId, User user, int? messageId = null, bool joinChatRequest = false,
        CancellationToken cancellationToken = default);
}