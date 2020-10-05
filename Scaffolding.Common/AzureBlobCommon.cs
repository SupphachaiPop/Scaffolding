using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace Scaffolding.Common
{
    public interface IAzureBlobCommon
    {
        string UploadFile(AzureBlobEntity azureBlobEntity);

        string DownloadFile(AzureBlobEntity azureBlobEntity);

        void DeleteFile(AzureBlobEntity azureBlobEntity);
    }

    public class AzureBlobCommon : IAzureBlobCommon
    {
        public string UploadFile(AzureBlobEntity azureBlobEntity)
        {
            try
            {
                Byte[] bytes = null;
                MemoryStream memoryStream = new MemoryStream();
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(azureBlobEntity.AzureBlobAccessKey);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(azureBlobEntity.ContainerName);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(azureBlobEntity.FileNameWithPath);
                azureBlobEntity.Stream.Position = 0;

                azureBlobEntity.Stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();

                blockBlob.UploadFromByteArray(bytes, 0, bytes.Length);

                return blockBlob.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DownloadFile(AzureBlobEntity azureBlobEntity)
        {
            try
            {
                MemoryStream memStream = new MemoryStream();
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(azureBlobEntity.AzureBlobAccessKey);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(azureBlobEntity.ContainerName);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(azureBlobEntity.FileName);
                blockBlob.DownloadToStreamAsync(memStream).Wait();

                return memStream.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFile(AzureBlobEntity azureBlobEntity)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(azureBlobEntity.AzureBlobAccessKey);
                CloudBlobClient _blobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer _cloudBlobContainer = _blobClient.GetContainerReference(azureBlobEntity.ContainerName);
                CloudBlockBlob _blockBlob = _cloudBlobContainer.GetBlockBlobReference(azureBlobEntity.FileName);
                _blockBlob.DeleteAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class AzureBlobEntity
    {
        public Stream Stream { get; set; }
        public string FileName { get; set; }
        public string FileNameWithUrl { get; set; }
        public string FileNameWithPath { get; set; }
        public string FileExtension { get; set; }
        public string ContainerName { get; set; }
        public string AzureBlobAccessKey { get; set; }
    }
}
