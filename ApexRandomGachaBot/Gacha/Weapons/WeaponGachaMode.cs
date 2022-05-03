namespace ApexRandomGachaBot.Gacha.Weapons;

public static class WeaponGachaMode
{
    public const string All = "all";
    public const string FieldOnly = "fieldOnly";
    public const string IncludeCarePackage = "+carePakcage";
    public const string IncludeCraftWeapon = "+craft";

    public static IReadOnlySet<string> ModeSet = new HashSet<string>
    {
        All,
        FieldOnly,
        IncludeCarePackage,
        IncludeCraftWeapon
    };
}