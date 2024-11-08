using EFCoreSpeedTest.Storage.Converters;
using System.Net;
using System.Text.Json.Serialization;

namespace EFCoreSpeedTest.Storage.Abstractions.UserAccount.Dto;

public class UserAccountDto
{
    public Guid Id { get; set; }
    
    public required string Username { get; set; }
    
    public required string Email { get; set; }

    [JsonConverter(typeof(IpAddressConverter))]
    public required IPAddress IpAddress { get; set; }
}