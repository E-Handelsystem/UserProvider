using UserProvider.Business.Models;

namespace UserProvider.Business.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User SaveGuestUser(User guestUser);
        void SaveUser(User user);
    }
}