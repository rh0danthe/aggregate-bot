using backend.Entities;

namespace backend.Services.Interfaces;

public interface IUserService
{
    public Task<User> CreateAsync(string sessionString);
}