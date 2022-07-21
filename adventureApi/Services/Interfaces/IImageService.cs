using System;
using Microsoft.AspNetCore.Http;

namespace adventureApi.Services.Interfaces
{
    public interface IImageService
    {
        string UploadToBlobStorage(IFormFile file, string folderName);
    }
}
