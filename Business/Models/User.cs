namespace UserProvider.Business.Models;

public class User
{

    public int Id { get; set; }            // Unikt ID för användaren
    public string Username { get; set; } = null!;   // Användarnamn
    public string Email { get; set; } = null!;     // E-postadress
    public string Password { get; set; } = null!; // Lösenord (ska inte sparas i klartext i en riktig applikation!)
    public bool IsGuest { get; set; }
}

