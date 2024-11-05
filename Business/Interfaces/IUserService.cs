using Business.Models;

public interface IUserService
{
    User GetUserById(int id);
    void RegisterUser(string username, string email, string password);
}