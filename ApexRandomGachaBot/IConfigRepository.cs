namespace ApexRandomGachaBot;

public interface IConfigRepository
{
    public Task<Config> GetOrCreateDefaultAsync();
}