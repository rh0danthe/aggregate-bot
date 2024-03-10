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
            if ((await _userRepository.GetByIdAsync(message.UserId)) == null)
                throw new UserNotFoundException("Пользователя с таким айди не существует");
            var dbMessage = new ApprovedMessage()
            {
                Content = message.Content,
                Query = message.Query,
                UserId = message.UserId
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
            Content = message.Content,
            Query = message.Query,
            UserId = message.UserId,
            Id = message.Id
        };
    }
}