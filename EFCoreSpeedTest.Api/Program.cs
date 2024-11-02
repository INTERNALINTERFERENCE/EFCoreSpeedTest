using EFCoreSpeedTest.Api.Queries;
using EFCoreSpeedTest.Api.Services;
using EFCoreSpeedTest.Business.Logic;
using EFCoreSpeedTest.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<UserAccountQuery>();

var speedDbContextConfiguration = builder.Configuration
    .GetRequiredSection(nameof(SpeedDbContextConfiguration))
    .Get<SpeedDbContextConfiguration>()!;

builder.Services.AddDbContextPool<SpeedDbContext>(options =>
{
    options.UseNpgsql(
        speedDbContextConfiguration.ConnectionString,
        o => o.UseNodaTime());
});

builder.Services.AddScoped<UserAccountLogic>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

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