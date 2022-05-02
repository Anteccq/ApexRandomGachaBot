using ApexRandomGachaBot;
using ApexRandomGachaBot.Gacha;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
{
    services.AddOptions();
    services.AddSingleton<IConfigRepository, ConfigRepository>();
    services.AddSingleton<ILegendGacha, LegendGacha>();
    services.AddSingleton<IWeaponGacha, WeaponGacha>();
}).RunConsoleAppFrameworkAsync<Runner>(args);