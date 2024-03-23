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
    private readonly NeuralClient _bot;
    
    public ApprovedMessagesController(IApprovedMessagesService approvedMessagesService, NeuralClient bot) 
    { 
        _approvedMessagesService = approvedMessagesService;
        _bot = bot;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromBody] ICollection<ApprovedMessageRequest> messages)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var res = await _approvedMessagesService.CreateAsync(messages);
        await _bot.PostAsync(res);
        return Ok(res);
    }
}