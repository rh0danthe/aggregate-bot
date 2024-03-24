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
    private readonly BotClient _bot;
    
    public ApprovedMessagesController(IApprovedMessagesService approvedMessagesService, BotClient bot) 
    { 
        _approvedMessagesService = approvedMessagesService;
        _bot = bot;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromBody] NeuralRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _approvedMessagesService.CreateAsync(request.Messages, request.IsFound, request.SessionString);
        var res = await _approvedMessagesService.GetAllByKeywordsAsync(request.Keywords, request.SessionString);
        await _bot.PostAsync(res, request.SessionString);
        return Ok(res);
    }
}