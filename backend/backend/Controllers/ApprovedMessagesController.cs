using backend.Dto;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Controller]
[Route("backend/approved")]
public class ApprovedMessagesController : Controller
{
    private readonly IApprovedMessagesService _approvedMessagesService;
    
    public ApprovedMessagesController(IApprovedMessagesService approvedMessagesService) 
    { 
        _approvedMessagesService = approvedMessagesService;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromBody] ICollection<ApprovedMessageRequest> messages)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _approvedMessagesService.CreateAsync(messages);
        return Ok();
    }
}