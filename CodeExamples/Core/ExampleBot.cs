using Microsoft.Extensions.Options;
using Telegram.Bot;
using TgBotFramework;

namespace CodeExamples;

public class ExampleBot : BaseBot
{
    public ExampleBot(IOptions<BotSettings> options) : base(options)
    {
    }
}