using backend.Entities;
using backend.Repository.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }  
    
    public async Task<User> CreateAsync(string sessionString)
    {
        var dbUser = new User()
        {
            SessionString = sessionString
        };
        return await _userRepository.CreateAsync(dbUser);
    }
}