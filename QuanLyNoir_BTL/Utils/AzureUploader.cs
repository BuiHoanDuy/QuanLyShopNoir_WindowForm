using Azure.Storage.Blobs;

namespace QuanLyNoir_BTL.Utils
{
    public class AzureUploader
    {
        private readonly string connectionString = Environment.GetEnvironmentVariable("AZURE_CONNECTION_STRING")!;
        private readonly string containerName = "images";

        public async Task<string> UploadImageAsync(Image image, string fileName)
        {
            try
            {
                using MemoryStream memoryStream = new();
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                memoryStream.Position = 0;
                BlobServiceClient blobServiceClient = new(connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                await containerClient.CreateIfNotExistsAsync();
                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                await blobClient.UploadAsync(memoryStream, overwrite: true);
                return blobClient.Uri.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Image upload failed: {ex.Message}");
            }
        }
    }
}
