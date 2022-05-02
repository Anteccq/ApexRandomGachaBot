using Utf8Json;

namespace ApexRandomGachaBot;

public class ConfigRepository : IConfigRepository
{
    private const string FilePath = "./config.json";
    private static Config DefaultConfig => new("", '!');
    public async Task<Config> GetOrCreateDefaultAsync()
    {
        if (!File.Exists(FilePath))
        {
            var config = DefaultConfig;
            await CreateConfigFileAsync(config);
            return config;
        }

        try
        {
            return await GetAsync();
        }
        catch
        {
            return DefaultConfig;
        }
    }

    private static async Task<Config> GetAsync()
    {
        await using var fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
        return await JsonSerializer.DeserializeAsync<Config>(fs);
    }

    private static async Task CreateConfigFileAsync(Config config)
    {
        await using var fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
        await JsonSerializer.SerializeAsync(fs, config);
    }
}