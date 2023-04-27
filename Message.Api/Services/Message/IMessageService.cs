using Message.Api.Models;

namespace Message.Api.Services.Message;

public interface IMessageService
{
    Task SendMessage(MessageModel input);
}