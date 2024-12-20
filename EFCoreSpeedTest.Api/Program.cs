using Confluent.Kafka;
using EFCoreSpeedTest.Api;
using EFCoreSpeedTest.Api.Queries;
using EFCoreSpeedTest.Api.Services;
using EFCoreSpeedTest.Business.Logic;
using EFCoreSpeedTest.Services;
using EFCoreSpeedTest.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders().AddConsole();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<UserAccountQuery>();

var speedDbContextConfiguration = builder.Configuration
    .GetRequiredSection(nameof(SpeedDbContextConfiguration))
    .Get<SpeedDbContextConfiguration>()!;

var kafkaConfiguration = builder.Configuration
    .GetRequiredSection(nameof(KafkaConfiguration))
    .Get<KafkaConfiguration>()!;

builder.Services.AddDbContextPool<SpeedDbContext>(options =>
{
    options.UseNpgsql(
        speedDbContextConfiguration.ConnectionString,
        o => o.UseNodaTime());
});

builder.Services.AddScoped<UserAccountLogic>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

builder.Services.AddSingleton(new ProducerConfig
{
    BootstrapServers = kafkaConfiguration.HostIpAddress
});

builder.Services.AddHostedService<CreateUserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();