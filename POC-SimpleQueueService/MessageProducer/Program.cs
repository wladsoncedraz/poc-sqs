using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

Console.WriteLine("[Producer] - Starting message process sending to SQS");

// Creating a SQS Client, specific to the Sao Paulo region
var sqsClient = new AmazonSQSClient(RegionEndpoint.SAEast1);

// Creating a request to send a message to the queue
var requestSendMessage = new SendMessageRequest
{
    QueueUrl = "https://sqs.sa-east-1.amazonaws.com/992382800221/discoverylogservice",
    MessageBody = "[LOG] - O personagem foi morto por Spinx"
};

// Sending the message to the queue
var response = await sqsClient.SendMessageAsync(requestSendMessage);
response = await sqsClient.SendMessageAsync(requestSendMessage);
response = await sqsClient.SendMessageAsync(requestSendMessage);
response = await sqsClient.SendMessageAsync(requestSendMessage);
response = await sqsClient.SendMessageAsync(requestSendMessage);