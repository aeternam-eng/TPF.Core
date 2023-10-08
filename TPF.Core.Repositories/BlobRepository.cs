using Azure.Storage;
using Azure.Storage.Blobs;
using TPF.Core.Borders.Repositories;
using TPF.Core.Shared.Configurations;

namespace TPF.Core.Repositories;

public class BlobRepository : IBlobRepository
{
    private readonly ApplicationConfig _appConfig;

    public BlobRepository(ApplicationConfig appConfig)
    {
        _appConfig = appConfig;
    }

    public async Task<string?> UploadBlob(Stream fileStream, string fileName)
    {
        try
        {
            StorageSharedKeyCredential storageCredentials = new(_appConfig.AzureStorage.AccountName, _appConfig.AzureStorage.AccountKey);

            Uri blobUri = new($"https://{_appConfig.AzureStorage.AccountName}.blob.core.windows.net/{_appConfig.AzureStorage.ContainerName}/{fileName}");

            var blobServiceClient = new BlobServiceClient(blobUri, storageCredentials);
            var blobClient = blobServiceClient.GetBlobContainerClient(_appConfig.AzureStorage.ContainerName);

            await blobClient.UploadBlobAsync(fileName, fileStream);

            return blobUri.ToString();
        }
        catch (Exception)
        {
            return null;
        }
    }
}
