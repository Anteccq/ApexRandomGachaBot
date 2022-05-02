namespace ApexRandomGachaBot.Gacha;

public class WeaponGacha : IWeaponGacha
{
    private readonly Random _random = new();

    public string Gacha(bool includeCraft, bool includeCarePackage)
    {
        var weaponList = Weapon.GetWeapons(includeCraft, includeCarePackage);
        return weaponList[_random.Next(weaponList.Count)];
    }
        

    public IEnumerable<string> Gacha(bool canDuplicate, bool includeCraft, bool includeCarePackage, int count)
    {
        if (!canDuplicate) return GetDistinctWeapons(includeCraft, includeCarePackage, count);

        var weaponList = Weapon.GetWeapons(includeCraft, includeCarePackage);
        return Enumerable.Range(0, count).Select(_ => weaponList[_random.Next(weaponList.Count)]);

    }

    private IEnumerable<string> GetDistinctWeapons(bool includeCraft, bool includeCarePackage, int count)
    {
        var weaponList = new List<string>(Weapon.GetWeapons(includeCraft, includeCarePackage));
        for (var i = 0; i < count; i++)
        {
            if(weaponList.Count <= 0)
                yield break;;
            
            var weapon = weaponList[_random.Next(weaponList.Count)];
            yield return weapon;
            weaponList.Remove(weapon);
        }
    }
}