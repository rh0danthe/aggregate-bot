using backend.Dto;

namespace backend.Services.Interfaces;

public interface IUserService
{
    public Task CreateAsync(UserRequest user);
}