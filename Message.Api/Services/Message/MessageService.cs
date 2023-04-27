using Grpc.Net.Client;
using Message.Api.Models;

namespace Message.Api.Services.Message;

public class MessageService : IMessageService
{
    public async Task SendMessage(MessageModel input)
    {
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        var channel = GrpcChannel.ForAddress("https://localhost:7068", new GrpcChannelOptions { HttpHandler = httpHandler });
        var client = new Greeter.GreeterClient(channel);
         await client.LogMessageAsync(new LogMessageRequest()
         {
             Id = input.Id.ToString(),
             Text = input.Text
         });
    }
}