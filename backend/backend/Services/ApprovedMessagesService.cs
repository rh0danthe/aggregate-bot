using backend.Dto;
using backend.Entities;
using backend.Repository.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services;

public class ApprovedMessagesService : IApprovedMessagesService
{
    private readonly IApprovedMessagesRepository _approvedMessagesRepository;

    public ApprovedMessagesService(IApprovedMessagesRepository approvedMessagesRepository)
    {
        _approvedMessagesRepository = approvedMessagesRepository;
    }
    
    public async Task<ICollection<ApprovedMessageResponse>> CreateAsync(ICollection<ApprovedMessageRequest> messages, bool isFound, string  sessionString)
    {
        var result = new List<ApprovedMessageResponse>();
        foreach (var message in messages)
        {
            var dbMessage = new ApprovedMessage()
            {
                ChatId = message.chat_id,
                Content = message.content,
                MessageId = message.message_id,
                SessionString = sessionString,
                Title = message.title,
                IsFound = isFound
            };
            result.Add(MapToResponse(await _approvedMessagesRepository.CreateAsync(dbMessage)));
        }
        return result;
    }

    public async Task<ICollection<ApprovedMessageResponse>> GetAllByKeywordsAsync(string[] keywords, string sessionString)
    {
        if (keywords.Length == 0)
            return new List<ApprovedMessageResponse>();
        var messages = await _approvedMessagesRepository.GetAllByQueryAsync(keywords, sessionString);
        return messages.Select(MapToResponse).ToList();
    }

    private ApprovedMessageResponse MapToResponse(ApprovedMessage message)
    {
        return new ApprovedMessageResponse()
        {
            ChatId = message.ChatId,
            Content = message.Content,
            MessageId = message.MessageId,
            Title = message.Title
        };
    }
}