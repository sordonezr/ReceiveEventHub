
using Azure.Messaging.EventHubs.Consumer;

var connectionString = "Endpoint=sb://demodevtest1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=sJQyeOzJtvsJ07xs9ESPEO4YPg5E1pdROzr8q6hX6EI=";
var eventHubName = "demo1";

string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
{
    using var cancellationSource = new CancellationTokenSource();
    cancellationSource.CancelAfter(TimeSpan.FromMinutes(50));

    await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
    {
        Console.WriteLine(receivedEvent.Data.EventBody);
    }
}