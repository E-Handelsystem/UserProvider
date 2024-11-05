using UserProvider.Business.Interfaces;
using UserProvider.Business.Models;

namespace UserProvider.Business.Services;

public class UserValidator : IUserValidator
{
    // Metod för att validera e-postadress
    public bool ValidateEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) &&
               email.Contains("@") &&
               email.Contains(".");
    }

    // Metod för att validera lösenord
    public bool ValidatePassword(string password)
    {
        return !string.IsNullOrWhiteSpace(password) &&
               password.Length >= 8; // Exempel: minst 8 tecken
    }

    // Metod för att validera användarnamn
    public bool ValidateUsername(string username)
    {
        return !string.IsNullOrWhiteSpace(username) &&
               username.Length >= 3; // Exempel: minst 3 tecken
    }

    // Metod för att validera hela användarobjektet
    public bool ValidateUser(User user)
    {
        return ValidateUsername(user.Username) &&
               ValidateEmail(user.Email) &&
               ValidatePassword(user.Password);
    }

    // Metod för att kontrollera att e-postadressen är unik
    public bool ValidateUniqueEmail(string email, List<User> existingUsers)
    {
        return existingUsers.All(user => user.Email != email);
    }
}
