
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace TaskManagement.Application.Services;
public class S3Service
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public S3Service(IConfiguration configuration)
    {
        var accessKey = configuration["AWS:AccessKey"];
        var secretKey = configuration["AWS:SecretKey"];
        var region = configuration["AWS:Region"];
        _bucketName = configuration["AWS:BucketName"];

        _s3Client = new AmazonS3Client(accessKey, secretKey, RegionEndpoint.GetBySystemName(region));
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        var fileTransferUtility = new TransferUtility(_s3Client);

        // Upload do arquivo
        await fileTransferUtility.UploadAsync(fileStream, _bucketName, fileName);

        // Retorna a URL pública do arquivo (se o bucket estiver configurado como público)
        return $"https://{_bucketName}.s3.amazonaws.com/{fileName}";
    }
}
