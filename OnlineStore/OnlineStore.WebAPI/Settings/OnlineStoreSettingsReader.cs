namespace OnlineStore.WebAPI.Settings
{
    public static class OnlineStoreSettingsReader
    {
        public static OnlineStoreSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new OnlineStoreSettings();
        }
    }
}
