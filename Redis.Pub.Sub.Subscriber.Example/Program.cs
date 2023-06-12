// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;

Console.WriteLine("Hello, World!");

ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost:1453");

ISubscriber subscriber = connection.GetSubscriber();

await subscriber.SubscribeAsync("mychannel", (channel, message) =>
{
    Console.WriteLine(message);
});

Console.ReadLine();