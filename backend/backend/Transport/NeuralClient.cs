using backend.Entities;

namespace backend.Transport;

public class NeuralClient
{
    private readonly HttpClient _httpClient;
    private readonly string _address;
    
    public NeuralClient(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _address = configuration.GetSection("Microservices")["Neural"];
    }

    public async Task PostAsync(ICollection<Message> messages)
    {
        await _httpClient.PostAsync(_address, JsonContent.Create(messages));
    }
}