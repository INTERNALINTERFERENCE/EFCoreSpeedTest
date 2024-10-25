using System.Diagnostics;
using System.Net;
using EFCoreSpeedTest.Api.Services;
using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Commands;
using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Dto;
using EFCoreSpeedTest.Storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreSpeedTest.Api.Controllers;

[ApiController]
[Route("userAccount")]
public class UserAccountController : ControllerBase
{
    private readonly IUserAccountService _userAccountService;

    public UserAccountController(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    [HttpPost("get")]
    public async Task<IActionResult> Get(
        UserAccountGetArguments arguments,
        CancellationToken cancellationToken)
    {
        var result = await _userAccountService.Get(arguments, cancellationToken);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Add(
        UserAccountAddArguments arguments,
        CancellationToken cancellationToken)
    {
        await _userAccountService.Add(arguments, cancellationToken);
        return Ok(arguments.Items);
    }
}