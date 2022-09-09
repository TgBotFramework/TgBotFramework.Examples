using Telegram.Bot.Types;

namespace BanHubBot.Challenges;

public class ChallengeAnswer
{
    public long ChatId { get; set; }    
    public int? MessageId { get; set; }
    public string Answer { get; set; }
    public User User { get; set; }
    public bool JoinRequest { get; set; }
}