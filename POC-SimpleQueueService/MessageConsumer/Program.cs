using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

Console.WriteLine("[Consumer] - Starting consuming messages from SQS");

// Creating a SQS Client, specific to the Sao Paulo region
var sqsClient = new AmazonSQSClient(RegionEndpoint.SAEast1);

// Creating a request to send a message to the queue
var request = new ReceiveMessageRequest
{
    QueueUrl = "https://sqs.sa-east-1.amazonaws.com/992382800221/discoverylogservice"
};

// Monitoring messages from the SQS
while (true)
{
    // Capture the messages from the queue specified in the request
    var response = await sqsClient.ReceiveMessageAsync(request);

    // Iterate over the messages received
    foreach (var message in response.Messages)
    {
        Console.WriteLine($"[Consumer] - Received message: {message.Body}");

        // Delete the message from the queue
        await sqsClient.DeleteMessageAsync(request.QueueUrl, message.ReceiptHandle);
    }
}