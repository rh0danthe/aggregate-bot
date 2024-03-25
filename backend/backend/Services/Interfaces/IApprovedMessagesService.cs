using backend.Dto;

namespace backend.Services.Interfaces;

public interface IApprovedMessagesService
{
    public Task<ICollection<ApprovedMessageResponse>> CreateAsync(ICollection<ApprovedMessageRequest> messages, bool isFound, int userId);
    public Task<ICollection<ApprovedMessageResponse>> GetAllByKeywordsAsync(string[] keywords, int userId);
}