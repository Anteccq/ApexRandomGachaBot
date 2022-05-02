namespace ApexRandomGachaBot.Gacha;

public class LegendGacha : ILegendGacha
{
    private readonly Random _random = new();
    public string Gacha()
        => Legend.Legends[_random.Next(Legend.Legends.Count)];

    public IEnumerable<string> Gacha(int count)
    {
        var legendList = new List<string>(Legend.Legends);
        for (var i = 0; i < count; i++)
        {
            if(legendList.Count <= 0)
                yield break;
            
            var legend = legendList[_random.Next(legendList.Count)];
            yield return legend;
            legendList.Remove(legend);
        }
    }
}