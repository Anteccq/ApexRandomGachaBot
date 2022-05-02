namespace ApexRandomGachaBot.Gacha;

internal interface ILegendGacha
{
    public string Gacha();
    public IEnumerable<string> Gacha(int count);
}