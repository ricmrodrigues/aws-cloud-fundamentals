using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

var secretsManagerClient = new AmazonSecretsManagerClient();

var request = new GetSecretValueRequest
{
    SecretId = "ApiKey",
    VersionId = "1f10b055-b6d8-4bb8-a5a8-ea0ecba2a0ed"
};

var listSecretVersionRequest = new ListSecretVersionIdsRequest
{
    SecretId = "ApiKey",
    IncludeDeprecated = true
};

var responseSecretVersion = await secretsManagerClient.ListSecretVersionIdsAsync(listSecretVersionRequest);

var response = await secretsManagerClient.GetSecretValueAsync(request);

Console.WriteLine(response.SecretString);

var describeResponse = await secretsManagerClient.DescribeSecretAsync(new DescribeSecretRequest
{
    SecretId = "ApiKey"
});

Console.WriteLine(describeResponse);