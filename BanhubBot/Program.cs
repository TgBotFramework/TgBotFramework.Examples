using BanHubBot;
using BanHubBot.Challenges;
using BanHubBot.Handlers;
using BanHubBot.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot.Types.Enums;
using TgBotFramework;

await Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    // Challenges
    services.AddScoped<IChallengeFabric, ChallengeFabric>();
    services.AddScoped<IUsersStore, UserStore>();
    
    // Handlers
    services.AddScoped<DebugHandler>();
    services.AddScoped<NewChatMemberHandler>();
    services.AddScoped<CallbackHandler>();
    services.AddScoped<OnBotAdded>();
    services.AddScoped<OnBotRemoved>();
    services.AddScoped<OnBotPromoted>();
    services.AddScoped<OnChatJoinRequest>();
    
    
    services.AddBotService<BanHubContext>("1768149218:AAGP046F02E-myekgv0rKQsyHxRO8ssoM0w", builder => builder
        .UseLongPolling(ParallelMode.SingleThreaded, new LongPollingOptions() { DebugOutput = true, DropPendingUpdates = true, AllowedUpdates = new []
            {
                UpdateType.Message,  UpdateType.Unknown, UpdateType.CallbackQuery, UpdateType.MyChatMember,
                UpdateType.ChannelPost, UpdateType.ChatMember, UpdateType.EditedMessage, UpdateType.InlineQuery, 
                UpdateType.PollAnswer, UpdateType.ShippingQuery, UpdateType.ChatJoinRequest, UpdateType.Poll,
                UpdateType.ChosenInlineResult, UpdateType.EditedChannelPost, UpdateType.PreCheckoutQuery
            } //all
              } 
        )
        .SetPipeline(pipeBuilder => pipeBuilder
                .Use<DebugHandler>()
                .MapWhen(On.MyChatMember, branch => branch
                    .MapWhen<OnBotAdded>(When.ThisBotAdded)
                    .MapWhen<OnBotRemoved>(When.ThisBotRemoved)
                    .MapWhen<OnBotPromoted>(When.ThisBotPromoted)
                )
                .MapWhen<OnChatJoinRequest>(On.ChatJoinRequest)
                //.MapWhen<NewChatMemberHandler>(On.ChatMember)
                .MapWhen<CallbackHandler>(On.CallbackQuery)
                
        )
    );
}).RunConsoleAsync();