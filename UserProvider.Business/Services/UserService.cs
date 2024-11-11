using UserProvider.Business.Interfaces;
using UserProvider.Business.Models;

namespace UserProvider.Business.Services;



public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    private List<User> users = new List<User>

    {
        new User { Id = 1, Username = "john_doe", Email = "john@example.com", Password = "password123" },
        new User { Id = 2, Username = "jane_doe", Email = "jane@example.com", Password = "password456" }
    };

    public User GetUserById(int id)
    {
        return users.FirstOrDefault(user => user.Id == id);
        // Hämta användare baserat på ID
    }

    public void RegisterUser(string username, string email, string password)
    {
        // Skapa en ny användare och lägg till i listan
        int newId = users.Count + 1; // En enkel metod för att ge nytt ID
        users.Add(new User { Id = newId, Username = username, Email = email, Password = password });

        // Logik för att spara användaren i en databas eller en lista.
        // Just nu kan det bara 
        // vara en plats för att visa hur metoden ska se ut.
    }

    public User LoginAsGuest()
    {

        var guestUser = new User { Id = users.Count + 1, Username = "Guest", IsGuest = true };

        _userRepository.SaveGuestUser(guestUser);

        return guestUser;
    }
    public string AddToWishlist(User user, string productId)
    {
        if (user.IsGuest)
        {
            return "Please create an account to save items to your wishlist.";
        }

        // Logik för att lägga till något i önskelistan
        // ...

        return "Item added to wishlist.";
    }
}
