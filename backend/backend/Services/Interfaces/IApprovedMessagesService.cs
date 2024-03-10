using backend.Dto;

namespace backend.Services.Interfaces;

public interface IApprovedMessagesService
{
    public Task<ICollection<ApprovedMessageResponse>> CreateAsync(ICollection<ApprovedMessageRequest> messages);
    public Task<ICollection<ApprovedMessageResponse>> GetAllByQueryAsync(string query);
}