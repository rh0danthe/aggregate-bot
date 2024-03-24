using backend.Dto;

namespace backend.Services.Interfaces;

public interface IApprovedMessagesService
{
    public Task<ICollection<ApprovedMessageResponse>> CreateAsync(ICollection<ApprovedMessageRequest> messages, bool isFound, string  sessionString);
    public Task<ICollection<ApprovedMessageResponse>> GetAllByKeywordsAsync(string[] keywords, string sessionString);
}