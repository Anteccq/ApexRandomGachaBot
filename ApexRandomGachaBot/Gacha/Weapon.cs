namespace ApexRandomGachaBot.Gacha;

public static class Weapon
{
    private static readonly IReadOnlyList<string> FieldWeapon = new List<string>
    {
        "ヘムロック",
        "R301 カービン",
        "ハボック",
        "オルタネーター",
        "プラウラー",
        "R-99",
        "デヴォーション",
        "Lスター",
        "トリプルテイク",
        "チャージライフル",
        "センチネル",
        "EVA8",
        "マスティフ",
        "モザンビーク",
        "ピースキーパー",
        "RE-45",
        "P2020",
        "ウィングマン",
        "30-30 リピーター",
        "ボセックボウ",
        "ランページLMG",
        "C.A.R. SMG"
    };

    private static readonly IReadOnlyList<string> CraftWeapons = new List<string>
    {
        "フラットライン",
        "ロングボウ"
    };

    private static readonly IReadOnlyList<string> CarePackageWeapons = new List<string>
    {
        "クレーバー",
        "スピットファイア",
        "ボルト",
        "G7スカウト"
    };

    public static IReadOnlyList<string> GetWeapons(bool includeCraft, bool includeCarePackage)
    {
        if (!includeCarePackage && !includeCarePackage)
            return FieldWeapon;

        var weapons = new List<string>(FieldWeapon);
        
        if(includeCraft)
            weapons.AddRange(CraftWeapons);

        if(includeCarePackage)
            weapons.AddRange(CarePackageWeapons);

        return weapons;
    }
}