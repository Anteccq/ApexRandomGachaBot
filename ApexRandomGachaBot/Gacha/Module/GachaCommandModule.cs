using ApexRandomGachaBot.Gacha.Legends;
using ApexRandomGachaBot.Gacha.Weapons;
using Discord;
using Discord.Commands;

namespace ApexRandomGachaBot.Gacha.Module;

public class GachaCommandModule : ModuleBase
{
    private readonly ILegendGacha _legendGacha;
    private readonly IWeaponGacha _weaponGacha;
    private const int WeaponCountLimit = 120;
    public GachaCommandModule(ILegendGacha legendGacha, IWeaponGacha weaponGacha)
    {
        _legendGacha = legendGacha;
        _weaponGacha = weaponGacha;
    }

    [Discord.Commands.Command("weapon")]
    public async Task WeaponCommandAsync(params string[] args)
    {
        var countOption = args.FirstOrDefault(x => int.TryParse(x, out _));
        var count = countOption is null
            ? 2
            : int.Parse(countOption);
        if (count > WeaponCountLimit) count = WeaponCountLimit;

        var mode = args.FirstOrDefault(WeaponGachaMode.ModeSet.Contains);
        var (includeCarePackage, includeCraft) = ModeToBoolean(mode);

        var text = CreateWeaponText(count, includeCarePackage, includeCraft);
        await ReplyAsync(text);
    }

    [Discord.Commands.Command("weaponp")]
    public async Task WeaponPartyCommandAsync(string arg=WeaponGachaMode.All)
    {
        var (includeCarePackage, includeCraft) = ModeToBoolean(arg);

        var text = CreateWeaponText(6, includeCarePackage, includeCraft);
        await ReplyAsync(text);
    }

    [Discord.Commands.Command("legend")]
    public async Task LegendCommandAsync(string arg="1")
    {
        var count = int.TryParse(arg, out var value)
            ? value
            : 1;

        var text = count == 1
            ? _legendGacha.Gacha()
            : string.Join("\n", _legendGacha.Gacha(count));

        await ReplyAsync(text);
    }

    [Discord.Commands.Command("legendp")]
    public Task LegendPartyCommandAsync()
        => ReplyAsync(string.Join("\n", _legendGacha.Gacha(3)));

    [Discord.Commands.Command("all")]
    public async Task AllCommandAsync(params string[] args)
    {
        var countOption = args.FirstOrDefault(x => int.TryParse(x, out _));
        var count = countOption is null
            ? 1
            : int.Parse(countOption);

        if (count > Legend.Legends.Count) count = Legend.Legends.Count;

        var mode = args.FirstOrDefault(WeaponGachaMode.ModeSet.Contains);
        var (includeCarePackage, includeCraft) = ModeToBoolean(mode);

        var legends = _legendGacha.Gacha(count);
        using var weapons = _weaponGacha.Gacha(true, includeCraft, includeCarePackage, count*2).Chunk(2).GetEnumerator();

        var eb = new EmbedBuilder
        {
            Color = Color.DarkGreen
        };
        foreach (var legend in legends)
        {
            weapons.MoveNext();
            eb.AddField(legend, string.Join("\n", weapons.Current));
        }

        await ReplyAsync(":upside_down:", embed: eb.Build());
    }

    [Discord.Commands.Command("allp")]
    public async Task AllPartyCommandAsync(string arg=WeaponGachaMode.All)
    {
        var (includeCarePackage, includeCraft) = ModeToBoolean(arg);

        const int count = 3;
        var legends = _legendGacha.Gacha(3);
        using var weapons = _weaponGacha.Gacha(true, includeCraft, includeCarePackage, count * 2).Chunk(2).GetEnumerator();

        var eb = new EmbedBuilder
        {
            Color = Color.DarkGreen
        };
        foreach (var legend in legends)
        {
            weapons.MoveNext();
            eb.AddField(legend, string.Join("\n", weapons.Current));
        }

        await ReplyAsync(":upside_down:", embed: eb.Build());
    }

    private string CreateWeaponText(int count=1, bool includeCarePackage=true, bool includeCraft=true)
        => count == 1 
            ? _weaponGacha.Gacha(includeCraft, includeCarePackage)
            : string.Join("\n", _weaponGacha.Gacha(true, includeCraft, includeCarePackage, count));

    private static (bool includeCarePackage, bool includeCraft) ModeToBoolean(string? mode)
        => mode switch
        {
            WeaponGachaMode.All => (true, true),
            WeaponGachaMode.IncludeCarePackage => (true, false),
            WeaponGachaMode.IncludeCraftWeapon => (false, true),
            WeaponGachaMode.FieldOnly => (false, false),
            _ => (true, true)
        };
}