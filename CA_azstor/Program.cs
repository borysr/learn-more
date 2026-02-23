using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Identity;

Console.WriteLine("Azure Blob Storage exercise\n");

// Create a DefaultAzureCredentialOptions object to configure DefaultAzureCredentials
DefaultAzureCredentialOptions options = new()
{
    ExcludeEnvironmentCredential = true,
    ExcludeManagedIdentityCredential = true
};

// Run the examples asynchronosly, wait for results before proceeding
await ProcessAsync();

Console.WriteLine("\nPress enter to exit the sample application.");
Console.ReadLine();

async Task ProcessAsync()
{
    // CREATE A BLOB STORAGE CLIENT
    string accountName = "storageacct7207";
    DefaultAzureCredential credential = new DefaultAzureCredential(options);

    string blobServiceEndpoint = $"https://{accountName}.blob.core.windows.net";
    BlobServiceClient blobServiceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), credential);
    
    // CREATE A CONTAINER 
    string containerName = "wtblob-persistent";
    Console.WriteLine($"Ensuring container {containerName} exists...");
    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
    await containerClient.CreateIfNotExistsAsync();
    
    if (containerClient is not null)
    {
        Console.WriteLine($"Container {containerName} created successfully. Press Enter to continue");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine($"Failed to create container {containerName}! exiting !");
        return;
    }
    
    // CREATE A LOCAL FILE FOR UPLOAD TO BLOB STORAGE
    Console.WriteLine("Creating local file to upoload");

    string localPath = "./data/";
    string fileName = "wtfile" + Guid.NewGuid().ToString() + ".txt";
    string localFilePath = Path.Combine(localPath, fileName);
    
    await File.WriteAllTextAsync(localFilePath, $"Hello World! {localFilePath}");
    Console.WriteLine($"Local file created at {localFilePath}. Press enter to continue");
    Console.ReadLine();
    
    // UPLOAD THE FILE TO BLOB STORAGE
    BlobClient blobClient = containerClient.GetBlobClient(fileName);
    Console.WriteLine($"Uploading to blob storage as blob:\n\t{blobClient.Uri.ToString()}" );

    await using FileStream uploadFilestream = new FileStream(localFilePath, FileMode.Open);
    await blobClient.UploadAsync(uploadFilestream);
    uploadFilestream.Close();
    
    bool blobExists = await blobClient.ExistsAsync();
    if (blobExists)
    {
        Console.WriteLine($"Blob {fileName} created successfully. Press enter to continue");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("File upload failed. exiting now!");
    }
        
    // LIST BLOBS IN THE CONTAINER
    Console.WriteLine("Listing blobs in the container");
    
    var list = await containerClient.GetBlobsAsync().ToListAsync<BlobItem>(); 
    
    foreach (var blob in list) 
    {
        Console.WriteLine("\t"+blob.Name);
    }

    Console.WriteLine("Press enter to continue");
    Console.ReadLine();
    
    // DOWNLOAD THE BLOB RO A LOCAL FILE
    string downLoadedFile = localFilePath.Replace(".txt", "-downloaded.txt");

    Console.WriteLine($"Download blob to file  {downLoadedFile}");
    BlobDownloadInfo download = await blobClient.DownloadAsync();

    await using FileStream downloadFilestream = File.OpenWrite(downLoadedFile);
    await download.Content.CopyToAsync(downloadFilestream);

    Console.WriteLine($"Blob downloaded succesfullly to file {downLoadedFile}");
}


