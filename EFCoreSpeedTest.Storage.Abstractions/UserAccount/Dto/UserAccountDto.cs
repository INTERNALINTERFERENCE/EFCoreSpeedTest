using System.Net;

namespace EFCoreSpeedTest.Storage.Abstractions.UserAccount.Dto;

public class UserAccountDto
{
    public Guid Id { get; set; }
    
    public required string Username { get; set; }
    
    public required string Email { get; set; }
    
    public required IPAddress IpAddress { get; set; }
}