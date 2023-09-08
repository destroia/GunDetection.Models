using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GunDetection.Data.Interface
{
    public interface IBlobStorageAzure
    {
        Task<Uri> UploadFileBlobAsync(string blobContainerName, Stream content, string contentType, string fileName);
        Task<Uri> UploadBase64BlobAsync(string blobContainerName, string imgBase64, string fileName);
    }
}
