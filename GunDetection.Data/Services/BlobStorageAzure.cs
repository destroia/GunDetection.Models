using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GunDetection.Data.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GunDetection.Data.Services
{
    public class BlobStorageAzure : IBlobStorageAzure
    {
        readonly BlobServiceClient _blobServiceClient;

        public BlobStorageAzure(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

       

        public async Task<Uri> UploadBase64BlobAsync(string blobContainerName, string imgBase64, string fileName)
        {
            var encodedImage = imgBase64.Split(',')[1];
            var decodedImage = Convert.FromBase64String(encodedImage);

            var containerClient = GetContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(fileName);

            using (var fileStream = new MemoryStream(decodedImage))
            {
                // upload image stream to blob
                await blobClient.UploadAsync(fileStream);
                return blobClient.Uri;
            }

        }

        public async Task<Uri> UploadFileBlobAsync(string blobContainerName, Stream content, string contentType, string fileName)
        {
            
            var containerClient = GetContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });
            return blobClient.Uri;
        }


      
        BlobContainerClient GetContainerClient(string blobContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;
        }
    }
}
