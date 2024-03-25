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
    
    public async Task<ICollection<Msg>> CreateAsync(ICollection<ApprovedMessageRequest> messages, bool isFound, int userId)
    {
        var result = new List<Msg>();
        foreach (var message in messages)
        {
            var dbMessage = new ApprovedMessage()
            {
                UserId = userId,
                ChatId = message.chat_id,
                Content = message.content,
                MessageId = message.message_id,
                Title = message.title,
                IsFound = isFound,
                ChatName = message.ChatName,
                SenderContacts = message.SenderContacts,
                SenderName = message.SenderName
            };
            result.Add(MapToResponse(await _approvedMessagesRepository.CreateAsync(dbMessage)));
        }
        return result;
    }

    public async Task<ICollection<Msg>> GetAllByKeywordsAsync(string[] keywords, int userId)
    {
        if (keywords.Length == 0)
        {
            var withoutKeywords = await _approvedMessagesRepository.GetAllByUserAsync(userId);
            return withoutKeywords.Select(MapToResponse).ToList();
        }
        var messages = await _approvedMessagesRepository.GetAllByQueryAsync(keywords, userId);
        return messages.Select(MapToResponse).ToList();
    }

    private Msg MapToResponse(ApprovedMessage message)
    {
        return new Msg()
        {
            ChatId = message.ChatId,
            Content = message.Content,
            MessageId = message.MessageId,
            Title = message.Title,
            ChatName = message.ChatName,
            SenderContacts = message.SenderContacts,
            SenderName = message.SenderName
        };
    }
}