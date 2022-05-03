using ApexRandomGachaBot;
using ApexRandomGachaBot.Configuration;
using ApexRandomGachaBot.Gacha.Legends;
using ApexRandomGachaBot.Gacha.Weapons;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
{
    services.AddOptions();
    services.AddSingleton<IConfigRepository, ConfigRepository>();
    services.AddSingleton<ILegendGacha, LegendGacha>();
    services.AddSingleton<IWeaponGacha, WeaponGacha>();
    services.AddSingleton(_ => new DiscordSocketClient(new DiscordSocketConfig
    {
        GatewayIntents = GatewayIntents.GuildMessages | GatewayIntents.Guilds | GatewayIntents.DirectMessages
    }));
    services.AddSingleton<CommandService>();
}).RunConsoleAppFrameworkAsync<Runner>(args);