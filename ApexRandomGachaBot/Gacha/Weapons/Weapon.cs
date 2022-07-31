namespace ApexRandomGachaBot.Gacha.Weapons;

public static class Weapon
{
    private static readonly IReadOnlyList<string> FieldWeapon = new List<string>
    {
        "ヘムロック",
        "ロングボウ",
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
        "スピットファイア",
        "モザンビーク",
        "ピースキーパー",
        "RE-45",
        "P2020",
        "R301 カービン",
        "30-30 リピーター",
        "ボセックボウ",
        "フラットライン",
        "ランページLMG"
    };

    private static readonly IReadOnlyList<string> CraftWeapons = new List<string>
    {
        "C.A.R. SMG",
        "ウィングマン"
    };

    private static readonly IReadOnlyList<string> CarePackageWeapons = new List<string>
    {
        "クレーバー",
        "マスティフ",
        "ボルト",
        "G7スカウト"
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