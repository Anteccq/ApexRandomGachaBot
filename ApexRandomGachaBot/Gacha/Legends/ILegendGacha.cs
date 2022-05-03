namespace ApexRandomGachaBot.Gacha.Legends;

public interface ILegendGacha
{
    public string Gacha();
    public IEnumerable<string> Gacha(int count);
}