using UserProvider.Business.Models;

namespace UserProvider.Business.Interfaces;
public interface IUserService
{
    User GetUserById(int id);
    void RegisterUser(string username, string email, string password);
    User LoginAsGuest();
}