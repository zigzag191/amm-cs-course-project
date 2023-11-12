namespace OnlineStore.WebAPI.Settings;

public static class OnlineStoreSettingsReader
{
    public static OnlineStoreSettings Read(IConfiguration configuration)
    {
        return new OnlineStoreSettings()
        {
            OnlineStoreDbContextConnectionString = configuration.GetValue<string>("OnlineStoreDbContext")
        };
    }
}
