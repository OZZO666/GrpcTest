using System.Text.Json;
using Grpc.Core;
using Message.Grpc;

namespace Message.Grpc.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }
    
    public override Task<LogMessageReply> LogMessage(LogMessageRequest request, ServerCallContext context)
    {
        Console.WriteLine(JsonSerializer.Serialize(request));
        return Task.FromResult(new LogMessageReply
        {
            Status = true
        });
    }
}