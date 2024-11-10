using Confluent.Kafka;
using EFCoreSpeedTest.Common;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EFCoreSpeedTest.Services;

public class CreateUserService : BackgroundService
{
    private readonly IProducer<string, byte[]> _producer;
    private readonly ILogger<CreateUserService> _logger;

    public CreateUserService(ProducerConfig producerConfig, ILogger<CreateUserService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _producer = new ProducerBuilder<string, byte[]>(producerConfig).Build();
    }
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(10), cancellationToken);
            
            var message = new Message<string, byte[]>
            {
                Key = "user", 
                Value= "User Created"u8.ToArray()
            };

            _producer
                .ProduceAsync("users", message, cancellationToken)
                .NoWait(_logger);
        }
    }
}