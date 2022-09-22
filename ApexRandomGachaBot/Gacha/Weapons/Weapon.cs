namespace ApexRandomGachaBot.Gacha.Weapons;

public static class Weapon
{
    private static readonly IReadOnlyList<string> FieldWeapon = new List<string>
    {
        "ヘムロック",
        "ロングボウ DMR",
        "ハボック",
        "オルタネーター SMG",
        "プラウラーバーストPDW",
        "R-99 SMG",
        "デヴォーション",
        "L-STAR",
        "トリプルテイク",
        "チャージライフル",
        "センチネル",
        "EVA8",
        "M600スピットファイア",
        "モザンビーク",
        "ピースキーパー",
        "RE-45",
        "R301 カービン",
        "30-30 リピーター",
        "G7スカウト",
        "フラットライン",
        "ボルトSMG",
        "C.A.R. SMG",
        "ウィングマン"
    };

    private static readonly IReadOnlyList<string> CraftWeapons = new List<string>
    {
        "P2020",
        "ハボックライフル"
    };

    private static readonly IReadOnlyList<string> CarePackageWeapons = new List<string>
    {
        "クレーバー.50",
        "マスティフ",
        "ランページLMG",
        "ボセックボウ"
    };

    public static IReadOnlyList<string> GetWeapons(bool includeCraft, bool includeCarePackage)
    {
        if (!includeCraft && !includeCarePackage)
            return FieldWeapon;

        var weapons = new List<string>(FieldWeapon);
        
        if(includeCraft)
            weapons.AddRange(CraftWeapons);

        if(includeCarePackage)
            weapons.AddRange(CarePackageWeapons);

        return weapons;
    }
}