using API.Models.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
    {
        var user = await _userService.CreateUserAsync(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.Role);

        return Ok(user);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        return user is null ? NotFound() : Ok(user);
    }
}
