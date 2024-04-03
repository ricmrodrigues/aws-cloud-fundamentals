using Amazon.SQS;
using Amazon.SQS.Model;

var cts = new CancellationTokenSource();
var sqsClient = new AmazonSQSClient();

var queueName = args.Length == 1 ? args[0] : "customers";

var queueUrlResponse = await sqsClient.GetQueueUrlAsync(queueName);

var receiveMessageRequest = new ReceiveMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    AttributeNames = new List<string>(["All"]),
    MessageAttributeNames = new List<string>(["All"])
};

while (!cts.IsCancellationRequested)
{
    var response = await sqsClient.ReceiveMessageAsync(receiveMessageRequest, cts.Token);

    foreach (var message in response.Messages)
    {
        Console.WriteLine($"{nameof(message.MessageId)}: {message.MessageId}");
        Console.WriteLine($"{nameof(message.Body)}: {message.Body}");

        await sqsClient.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle);
    }

    await Task.Delay(1000);
}