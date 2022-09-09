using BanHubBot.Challenges;
using Telegram.Bot.Types;

namespace BanHubBot.Services;

public interface IUsersStore
{
    void Add(ChallengeAnswer chatMember);

    IReadOnlyCollection<ChallengeAnswer> GetAll();

    ChallengeAnswer Get(long chatId, long userId);
        
    void Remove(ChallengeAnswer user);
}