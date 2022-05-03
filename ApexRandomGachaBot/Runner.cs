using System.Reflection;
using ApexRandomGachaBot.Configuration;
using ApexRandomGachaBot.Log;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

namespace ApexRandomGachaBot;
public class Runner : ConsoleAppBase
{
    private readonly DiscordSocketClient _client;
    private readonly CommandService _commandService;
    private readonly IConfigRepository _configRepository;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;
    public Runner(DiscordSocketClient client, CommandService commandService, IConfigRepository configRepository, IServiceProvider serviceProvider, ILogger<Runner> logger)
    {
        _client = client;
        _commandService = commandService;
        _configRepository = configRepository;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task ExecuteAsync()
    {
        var config = await _configRepository.GetOrCreateDefaultAsync();
        if (string.IsNullOrEmpty(config.Token))
        {
            _logger.LogCritical("Write your Discord Token to ./config.json");
            return;
        }

        _client.Log += m =>
        {
            _logger.Log(m.Severity.ToLogLevel(), m.Exception, m.Message);
            return Task.CompletedTask;
        };

        _client.MessageReceived += MessageHandler;

        await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);
        await _client.LoginAsync(TokenType.Bot, config.Token);
        await _client.StartAsync();

        await Task.Delay(-1, Context.CancellationToken);

        await _client.StopAsync();
    }

    private async Task MessageHandler(SocketMessage message)
    {
        if(message is not SocketUserMessage msg || msg.Author.IsBot)
            return;

        var argPos = 0;
        var config = await _configRepository.GetOrCreateDefaultAsync();
        var hasPrefix = msg.HasCharPrefix(config.Prefix, ref argPos) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos);
        
        if(!hasPrefix)
            return;

        var context = new CommandContext(_client, msg);
        await _commandService.ExecuteAsync(context, argPos, _serviceProvider);
    }
}