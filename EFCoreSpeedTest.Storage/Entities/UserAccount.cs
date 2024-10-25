using System.Net;

namespace EFCoreSpeedTest.Storage.Entities;

public class UserAccount : Entity
{
    public required string Username { get; set; }
    
    public required string Email { get; set; }
    
    public required IPAddress IpAddress { get; set; }
}