using Amazon.SQS;
using Amazon.SQS.Model;
using SqsPublisher;
using System.Text.Json;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated
{
    Id = Guid.NewGuid(),
    Email = "ricardo@rodrigues.com",
    FullName = "Ricardo Rodrigues",
    DateOfBirth = new DateTime(1985, 5, 27),
    GitHubUsername = "ricmrodrigues"
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");
var sendMessageRequest = new SendMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue> {
        { "MessageType", new MessageAttributeValue
            {
                DataType = "String",
                StringValue = nameof(CustomerCreated)
            }
        }
    }
};
var response = await sqsClient.SendMessageAsync(sendMessageRequest);

Console.WriteLine(response);