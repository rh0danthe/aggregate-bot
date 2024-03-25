using backend.Dto;
using backend.Services.Interfaces;
using backend.Transport;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Controller]
[Route("backend/approved")]
public class ApprovedMessagesController : Controller
{
    private readonly IApprovedMessagesService _approvedMessagesService;
    private readonly IUserService _userService;
    private readonly BotClient _bot;
    
    public ApprovedMessagesController(IApprovedMessagesService approvedMessagesService, IUserService userService, BotClient bot) 
    { 
        _approvedMessagesService = approvedMessagesService;
        _userService = userService;
        _bot = bot;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromBody] NeuralRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userService.CreateAsync(request.session);
        await _approvedMessagesService.CreateAsync(request.msgs, request.is_found, user.Id);
        var res = await _approvedMessagesService.GetAllByKeywordsAsync(request.keywords, user.Id);

        await _bot.PostAsync(res, request.session);
        return Ok(res);
    }
}