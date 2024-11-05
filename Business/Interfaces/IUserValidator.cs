﻿using Business.Models;

public interface IUserValidator
{
    bool ValidateEmail(string email);
    bool ValidatePassword(string password);
    bool ValidateUniqueEmail(string email, List<User> existingUsers);
    bool ValidateUser(User user);
    bool ValidateUsername(string username);
}