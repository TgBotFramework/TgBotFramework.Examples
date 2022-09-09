namespace BanHubBot.Challenges;

public interface IChallengeFabric
{
    IChallenge Build(ChallengeType challengeType);
}