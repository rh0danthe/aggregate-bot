﻿using backend.Entities;

namespace backend.Repository.Interfaces;

public interface IUserRepository
{
    public Task<User> CreateAsync(User user);
}