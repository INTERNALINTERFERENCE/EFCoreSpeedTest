using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace EFCoreSpeedTest.Services;

public class CreateUserService : BackgroundService
{
    private readonly IProducer<string, byte[]> _producer;

    public CreateUserService(ProducerConfig producerConfig)
    {
        _producer = new ProducerBuilder<string, byte[]>(producerConfig).Build();
    }
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
            
            _producer.Produce(topic: "users", message: new Message<string, byte[]>
            {
                Key = "user",
                Value = "User Created"u8.ToArray()
            });
        }
    }
}