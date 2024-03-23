using backend.Dto;
using backend.Entities;
using backend.Exceptions.Shared;
using backend.Exceptions.User;
using backend.Repository.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services;

public class ApprovedMessagesService : IApprovedMessagesService
{
    private readonly IApprovedMessagesRepository _approvedMessagesRepository;
    private readonly IUserRepository _userRepository;

    public ApprovedMessagesService(IApprovedMessagesRepository approvedMessagesRepository, IUserRepository userRepository)
    {
        _approvedMessagesRepository = approvedMessagesRepository;
        _userRepository = userRepository;
    }
    
    public async Task<ICollection<ApprovedMessageResponse>> CreateAsync(ICollection<ApprovedMessageRequest> messages)
    {
        var result = new List<ApprovedMessageResponse>();
        foreach (var message in messages)
        {
            var dbMessage = new ApprovedMessage()
            {
                Keyword = message.Keyword,
                ChatId = message.ChatId,
                Content = message.Content,
                IsFound = message.IsFound,
                MessageId = message.MessageId,
                SessionString = message.SessionString,
                Title = message.Title
            };
            result.Add(MapToResponse(await _approvedMessagesRepository.CreateAsync(dbMessage)));
        }
        return result;
    }

    public async Task<ICollection<ApprovedMessageResponse>> GetAllByQueryAsync(string query)
    {
        var messages = await _approvedMessagesRepository.GetAllByQueryAsync(query);
        return messages.Select(MapToResponse).ToList();
    }

    private ApprovedMessageResponse MapToResponse(ApprovedMessage message)
    {
        return new ApprovedMessageResponse()
        {
            ChatId = message.ChatId,
            Content = message.Content,
            MessageId = message.MessageId,
            SessionString = message.SessionString,
            Title = message.Title
        };
    }
}