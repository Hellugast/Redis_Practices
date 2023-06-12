// See https://aka.ms/new-console-template for more information
using StackExchange.Redis;

Console.WriteLine("Hello, World!");

ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost:1453");

ISubscriber subscriber = connection.GetSubscriber();

while (true)
{
    Console.WriteLine("Message : ");
    string message = Console.ReadLine();
    await subscriber.PublishAsync("mychannel", message);
}