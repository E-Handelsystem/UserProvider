using UserProvider.Business.Data;
using UserProvider.Business.Interfaces;
using UserProvider.Business.Models;

namespace UserProvider.Business.Services;

public class UserRepository : IUserRepository
{

    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public User GetUserById(int id)
    {
        return _context.Users.Find(id);
    }

    public void SaveUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User SaveGuestUser(User guestUser)
    {
        // Logik för att spara en gäst användare
        guestUser.IsGuest = true;
        _context.Users.Add(guestUser);
        _context.SaveChanges();
        return guestUser;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }
}
