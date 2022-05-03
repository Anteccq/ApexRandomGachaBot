using Discord;
using Discord.Commands;

namespace ApexRandomGachaBot;

public class CommonCommandModule : ModuleBase
{
    private static readonly Color DeepSkyBlue = new(0, 0xbf, 0xff);

    [Discord.Commands.Command("apex-h")]
    [Alias("help")]
    public async Task HelpCommandAsync()
    {
        var eb = new EmbedBuilder
        {
            Color = DeepSkyBlue,
            Title = "Command List"
        };
        eb.AddField("weapon [number(option)] [mode(option)]", $"```{CreateArgumentText("[number]", "1,2...")}\n{CreateArgumentText("[mode]", "all, +craft, +carePackage, fieldOnly")}```");
        eb.AddField("legend [number(option)]", $"```{CreateArgumentText("[number]", "1,2...")}```");
        eb.AddField("weaponp [mode(option)]", "```Same as 'weapon 6 [mode]' (Alias for full squad)```");
        eb.AddField("legendp", "```Same as 'legend 3' (Alias for full squad)```");
        eb.AddField("all [number of player(option)] [mode(option)]",
            $"```{CreateArgumentText("[number]", "1,2...")}\n{CreateArgumentText("[mode]", "all, +craft, +carePackage, fieldOnly")}```");
        eb.AddField("allp [mode(option)]", $"```Same as 'all 3 [mode]' (Alias for full squad)```");
        eb.AddField("Supported Season", $"We supported Season {BotInfo.SupportedSeason}");
        eb.AddField("Source Code", "[GitHub](https://github.com/Anteccq/ApexRandomGachaBot)");
        eb.Footer = new EmbedFooterBuilder()
            .WithIconUrl(
                "https://github.com/Anteccq.png")
            .WithText("Developed by Anteccq");
        await ReplyAsync(embed: eb.Build());
    }

    private static string CreateArgumentText(string name, string description)
        => $"{name,-10}: {description}";
}