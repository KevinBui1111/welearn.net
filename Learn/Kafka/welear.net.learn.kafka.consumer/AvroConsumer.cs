using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Hci.Hcd.VnPosAppointment.InfrastructureLayer.Abstraction.Kafka;
using Microsoft.Extensions.Configuration;

namespace welear.net.learn.kafka.consumer;

public class AvroConsumer
{
    public static void Consume(IConfiguration configuration, ConsumerConfig consumerConfig, CancellationToken ct)
    {
        var schemaRegistryConfig = new SchemaRegistryConfig
        {
            // Note: you can specify more than one schema registry url using the
            // schema.registry.url property for redundancy (comma separated list). 
            // The property name is not plural to follow the convention set by
            // the Java implementation.
            Url = configuration["Kafka:SchemaRegistry"],
            BasicAuthUserInfo = $"{configuration["Kafka:Username"]}:{configuration["Kafka:Password"]}",
        };

        using var schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
        using var consumer =
            new ConsumerBuilder<string, TwScoringMessage>(consumerConfig)
                .SetValueDeserializer(new AvroDeserializer<TwScoringMessage>(schemaRegistry).AsSyncOverAsync())
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                .SetPartitionsAssignedHandler((c, partition) =>
                {
                    return partition.Select(p => new TopicPartitionOffset(p, Offset.Beginning));
                })
                .Build();

        const string topic = "GMA.CAPP.LDS.TW_SCORING.V2";
        consumer.Subscribe(topic);

        try
        {
            while (true)
            {
                try
                {
                    var consumeResult = consumer.Consume(ct);
                    var user = consumeResult.Message.Value;
                    Console.WriteLine(
                        $"key: {consumeResult.Message.Key}, user name: {user.Cuid}, favorite number: {user.CustomerFullName}, favorite color: {user.AppointmentType}, hourly_rate: {user.DateOfBirth}");
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Consume error: {e.Error.Reason}");
                }
            }
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine($"OperationCanceledException: {ex.Message}");
            consumer.Close();
        }
    }
}