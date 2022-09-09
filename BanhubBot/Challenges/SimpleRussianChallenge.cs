using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BanHubBot.Challenges;

public class SimpleRussianChallenge : IChallenge
{
    private static readonly string[] NumberTexts =
    {
        "ноль",
        "один",
        "два",
        "три",
        "четыре",
        "пять",
        "шесть",
        "семь",
        "восемь",
    };
    
    private static Random _random = new();
    
    public async Task<ChallengeAnswer> SendTaskToChat(ITelegramBotClient client, long chatId, User user, int? messageId = null, bool joinRequest = false, CancellationToken cancellationToken = default)
    {
        var answer = _random.Next(1, ButtonsCount);
        var sendTo = joinRequest ? user.Id : chatId;
        var sentMessage = await client.SendTextMessageAsync(
            chatId,
            $"Привет, {user.ToString()}, нажми кнопку {NumberTexts[answer]}, чтобы тебя не забанили!",
            replyToMessageId: messageId,
            replyMarkup: new InlineKeyboardMarkup(GetKeyboardButtons()), cancellationToken: cancellationToken);

        return new ChallengeAnswer() { Answer = answer.ToString(), ChatId = chatId, MessageId = sentMessage.MessageId, User = user, JoinRequest = joinRequest};
    }
    
    private const int ButtonsCount = 8;

    private static IEnumerable<InlineKeyboardButton> GetKeyboardButtons()
    {
        for (int i = 1; i <= ButtonsCount; i++)
        {
            var label = i.ToString();
            yield return InlineKeyboardButton.WithCallbackData(label, label);
        }
    }
}