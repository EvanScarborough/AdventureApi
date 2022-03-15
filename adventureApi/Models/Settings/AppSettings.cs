using System;
namespace adventureApi.Models.Settings
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string DbConnectionString { get; set; }
        public string EncryptionKey { get; set; }
    }
}
