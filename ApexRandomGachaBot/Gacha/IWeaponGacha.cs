﻿namespace ApexRandomGachaBot.Gacha;

public interface IWeaponGacha
{
    string Gacha(bool includeCraft, bool includeCarePackage);

    IEnumerable<string> Gacha(bool canDuplicate, bool includeCraft, bool includeCarePackage, int count);
}