using Message.Api.Models;
using Message.Api.Services.Message;
using Microsoft.AspNetCore.Mvc;

namespace Message.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet(Name = "SendMessage")]
    public async Task<IActionResult> SendMessage(string message)
    {
        var msg = new MessageModel()
        {
            Id = Guid.NewGuid(),
            Text = message
        };
        
        await _messageService.SendMessage(msg);
        return Ok();
    }
}