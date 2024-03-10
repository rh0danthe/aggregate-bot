using backend.Dto;
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
    
    public async Task CreateAsync(UserRequest user)
    {
        var dbUser = new User()
        {
            Token = user.Token,
            Query = user.Query
        };
        await _userRepository.CreateAsync(dbUser);
    }
}