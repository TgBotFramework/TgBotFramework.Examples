namespace BanHubBot.Challenges;

public class ChallengeFabric : IChallengeFabric
{
    public IChallenge Build(ChallengeType challengeType)
    {
        switch (challengeType)
        {
            case ChallengeType.SimpleRussian:
                return new SimpleRussianChallenge();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(challengeType), challengeType, null);
        }
    }
}