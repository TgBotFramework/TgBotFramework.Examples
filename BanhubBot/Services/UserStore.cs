using System.Collections.Concurrent;
using BanHubBot.Challenges;
using Telegram.Bot.Types;

namespace BanHubBot.Services;

public class UserStore : IUsersStore
{
    private readonly ConcurrentDictionary<ChatUser, ChallengeAnswer> _users;

    public UserStore()
    {
        _users = new ConcurrentDictionary<ChatUser, ChallengeAnswer>();
    }

    public void Add(ChallengeAnswer answer)
    {
        var key = new ChatUser(answer.ChatId, answer.User.Id);
        var newValue = answer;

        _users.AddOrUpdate(key, newValue, (_, _) => newValue);
    }

    public IReadOnlyCollection<ChallengeAnswer> GetAll()
    {
        return _users.Values.ToArray(); 
    }

    public ChallengeAnswer Get(long chatId, long userId)
    {
        if (_users.TryGetValue(new ChatUser(chatId, userId), out var newUser)) 
            return newUser;

        return null;
    }

    public void Remove(ChallengeAnswer user)
    {
        _users.TryRemove(new ChatUser(user.ChatId, user.User.Id), out _);
    }
}