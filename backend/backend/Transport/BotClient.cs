using backend.Dto;
using backend.Entities;

namespace backend.Transport;

public class BotClient
{
    private readonly HttpClient _httpClient;
    private readonly string _address;
    
    public BotClient(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _address = configuration.GetSection("Microservices")["bot-api"];
    }

    public async Task PostAsync(ICollection<Msg> messages, string sessionString)
    {
        var content = JsonContent.Create(new BotResponse
        {
            SessionString = sessionString,
            Messages = messages
        });
        var res = await _httpClient.PostAsync(_address, content);
    }
}