using TgBotFramework;

namespace BanHubBot;

public class OnBotRemoved : IUpdateHandler<BanHubContext>
{
    public async Task HandleAsync(BanHubContext context, UpdateDelegate<BanHubContext> next, CancellationToken cancellationToken)
    {
        //Oh well
    }
}