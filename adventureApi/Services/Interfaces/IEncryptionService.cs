using System;
namespace adventureApi.Services.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string s);
        string Decrypt(string s);
    }
}
