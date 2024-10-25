using EFCoreSpeedTest.Api.Services;
using EFCoreSpeedTest.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var speedDbContextConfiguration = builder.Configuration
    .GetRequiredSection(nameof(SpeedDbContextConfiguration))
    .Get<SpeedDbContextConfiguration>()!;

builder.Services.AddSingleton(speedDbContextConfiguration);
builder.Services.AddSingleton<ISpeedDbContextFactory, SpeedDbContextFactory>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();