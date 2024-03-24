using backend.Dto;
using backend.Entities;

namespace backend.Transport;

public class NeuralClient
{
    private readonly HttpClient _httpClient;
    private readonly string _address;
    
    public NeuralClient(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _address = configuration.GetSection("Microservices")["bot"];
    }

    public async Task PostAsync(ICollection<ApprovedMessageResponse> messages)
    {
        var toMsg = messages.Select(msg => new Msg
        {
            ChatId = msg.ChatId,
            MessageId = msg.MessageId,
            SessionString = msg.SessionString,
            Title = msg.Title,
            Text = msg.Content,
        });
        var content = JsonContent.Create(new NeuralRequest
        {
            Messages = toMsg.ToList()
        });
        var res = await _httpClient.PostAsync(_address, content);
    }
}