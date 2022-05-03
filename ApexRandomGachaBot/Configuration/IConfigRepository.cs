namespace ApexRandomGachaBot.Configuration;

public interface IConfigRepository
{
    public ValueTask<Config> GetOrCreateDefaultAsync();
}