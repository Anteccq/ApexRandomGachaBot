using Microsoft.Extensions.Configuration;
using Utf8Json;

namespace ApexRandomGachaBot.Configuration;

public class ConfigRepository : IConfigRepository
{
    private const string FilePath = "./config.json";
    private const string TokenKeyName = "DiscordToken";
    private static Config DefaultConfig => new("", '!');

    private readonly IConfiguration _configuration;

    private Config? _cachedConfig = null;

    public ConfigRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async ValueTask<Config> GetOrCreateDefaultAsync()
    {
        if (_cachedConfig is not null)
            return _cachedConfig;

        if (!string.IsNullOrEmpty(_configuration[TokenKeyName]))
        {
            _cachedConfig = new Config(_configuration[TokenKeyName], '!');
            return _cachedConfig;
        }

        try
        {
            if (File.Exists(FilePath))
            {
                _cachedConfig = await GetAsync();
                return _cachedConfig;
            }

            _cachedConfig = DefaultConfig;
            await CreateConfigFileAsync(_cachedConfig);
            return _cachedConfig;
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
        var json = JsonSerializer.Serialize(config);
        json = JsonSerializer.PrettyPrintByteArray(json);
        await using var fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
        await fs.WriteAsync(json);
    }
}