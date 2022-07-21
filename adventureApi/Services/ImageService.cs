using System;
using System.IO;
using adventureApi.Models.Settings;
using adventureApi.Services.Interfaces;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeTypes;

namespace adventureApi.Services
{
    public class ImageService : IImageService
    {
        private AppSettings _appSettings;
        public static IAmazonS3 _s3Client;

        public ImageService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            var credentials = new BasicAWSCredentials(_appSettings.BlobAccessKey, _appSettings.BlobSecretKey);
            var s3ClientConfig = new AmazonS3Config
            {
                ServiceURL = _appSettings.BlobStorageUrl,
                Timeout = TimeSpan.FromSeconds(2500),
                MaxErrorRetry = 8
            };
            _s3Client = new AmazonS3Client(credentials, s3ClientConfig);
        }

        public string UploadToBlobStorage(IFormFile file, string folderName)
        {
            var fileName = $"{Guid.NewGuid()}{MimeTypeMap.GetExtension(file.ContentType)}";
            try
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var fileTransferUtility = new TransferUtility(_s3Client);
                    var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = $@"{_appSettings.BlobStorageName}/{folderName}",
                        Key = fileName,
                        InputStream = newMemoryStream,
                        StorageClass = S3StorageClass.StandardInfrequentAccess,
                        PartSize = 6291456, // 6 MB
                        CannedACL = S3CannedACL.PublicRead
                    };
                    fileTransferUtility.Upload(fileTransferUtilityRequest);
                }
            }
            catch (Exception e)
            {

            }
            return $"{_appSettings.BlobStorageUrl}/{_appSettings.BlobStorageName}/{folderName}/{fileName}";
        }
    }
}
