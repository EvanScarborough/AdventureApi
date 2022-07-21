using System;
namespace adventureApi.Models.Settings
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string DbConnectionString { get; set; }
        public string EncryptionKey { get; set; }
        public string BlobStorageUrl { get; set; }
        public string BlobStorageName { get; set; }
        public string BlobAccessKey { get; set; }
        public string BlobSecretKey { get; set; }
    }
}
