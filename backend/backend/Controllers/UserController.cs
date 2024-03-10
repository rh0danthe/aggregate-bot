using backend.Dto;
using backend.Services;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Controller]
[Route("backend/user_data")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService) 
    { 
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(UserRequest user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _userService.CreateAsync(user);
        return Ok();
    }
}