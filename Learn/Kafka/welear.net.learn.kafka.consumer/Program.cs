// See https://aka.ms/new-console-template for more information

using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using welear.net.learn.kafka.consumer;

Console.WriteLine("Hello, World!");

var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddEnvironmentVariables()
        .AddJsonFile("appsettings.json")
    ;

var configuration = builder.Build();

var consumerConfig = new ConsumerConfig {
    BootstrapServers = configuration["Kafka:BootstrapServers"],
    GroupId = "TestConsumerGroup",
    AutoOffsetReset = AutoOffsetReset.Earliest,
    
    SaslUsername = configuration["Kafka:Username"],
    SaslPassword = configuration["Kafka:Password"],
    SecurityProtocol = SecurityProtocol.SaslSsl,
    SaslMechanism = SaslMechanism.ScramSha256
};

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) => {
    e.Cancel = true; // prevent the process from terminating.
    cts.Cancel();
};

AvroConsumer.Consume(configuration, consumerConfig, cts.Token);

// using var consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
//
// const string topic = "GMA.CAPP.LDS.TW_SCORING.V2";
// consumer.Subscribe(topic);
//
// try {
//     while (true) {
//         var cr = consumer.Consume(cts.Token);
//         Console.WriteLine($"Consumed event from topic {topic}: key = {cr.Message.Key,-10} value = {cr.Message.Value}");
//     }
// }
// catch (OperationCanceledException) {
//     // Ctrl-C was pressed.
//     Console.WriteLine("Ctrl-C was pressed.");
// }
// finally{
//     consumer.Close();
// }