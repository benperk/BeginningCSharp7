using System;
using System.IO;
using System.Configuration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using static System.Console;

namespace Ch16Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.AppSettings["StorageConnectionString"]);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("carddeck");
                if (container.CreateIfNotExists())
                {
                    WriteLine($"Created container '{container.Name}' " +
                     $"in storage account '{storageAccount.Credentials.AccountName}'.");
                }
                else
                {
                    WriteLine($"Container '{container.Name}' already exists " +
                     $"for storage account '{storageAccount.Credentials.AccountName}'.");
                }
                container.SetPermissions(new BlobContainerPermissions
                { PublicAccess = BlobContainerPublicAccessType.Blob });
                WriteLine($"Permission for container '{container.Name}' is public.");

                int numberOfCards = 0;
                DirectoryInfo dir = new DirectoryInfo(@"Cards");
                foreach (FileInfo f in dir.GetFiles("*.*"))
                {
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(f.Name);
                    using (var fileStream = System.IO.File.OpenRead(@"Cards\" + f.Name))
                    {
                        blockBlob.UploadFromStream(fileStream);
                        WriteLine($"Uploading: '{f.Name}' which " +
                         $"is {fileStream.Length} bytes.");
                    }
                    numberOfCards++;
                }
                WriteLine($"Uploaded {numberOfCards.ToString()} cards.");
                WriteLine();

                numberOfCards = 0;
                foreach (IListBlobItem item in container.ListBlobs(null, false))
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        WriteLine($"Card image url '{blob.Uri}' with length " +
                         $" of {blob.Properties.Length}");
                    }
                    numberOfCards++;
                }
                WriteLine($"Listed {numberOfCards.ToString()} cards.");

                WriteLine("Enter Y to delete listed cards, press enter to skip deletion:");
                if (ReadLine() == "Y")
                {
                    numberOfCards = 0;
                    foreach (IListBlobItem item in container.ListBlobs(null, false))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        CloudBlockBlob blockBlobToDelete = container.GetBlockBlobReference(blob.Name);
                        blockBlobToDelete.Delete();
                        WriteLine($"Deleted: '{blob.Name}' which was {blob.Name.Length} bytes.");
                        numberOfCards++;
                    }
                    WriteLine($"Deleted {numberOfCards.ToString()} cards.");
                }
            }
            catch (StorageException ex)
            {
                WriteLine($"StorageException: {ex.Message}");
            }
            catch (Exception ex)
            {
                WriteLine($"Exception: {ex.Message}");
            }
            WriteLine("Press enter to exit.");
            ReadLine();
        }
    }
}