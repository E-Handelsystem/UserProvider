
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using UserProvider.Business.Interfaces;
using UserProvider.Business.Services;
using UserProvider.Business.Models;

namespace UserProvider.Tests.Business;

public class UserService_Tests
{
    private readonly UserService _userService;
    private readonly Mock<IUserRepository> _mockUserRepository;

    public UserService_Tests()
    {
        
        _mockUserRepository = new Mock<IUserRepository>();
        _userService = new UserService(_mockUserRepository.Object);
    }

    [Fact]
    public void LoginAsGuest_ShouldLogInUserAsGuest()
    {
        // Arrange
        var expectedGuestUser = new User { Id = 0, Username = "Guest", IsGuest = true }; // Skapa en gäst-användare
        // Ingen information ska sparas långsiktigt för gäst
        _mockUserRepository.Setup(repo => repo.SaveGuestUser(It.IsAny<User>()))
            .Returns(expectedGuestUser);

        // Act
        var result = _userService.LoginAsGuest();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.IsGuest);
        Assert.Equal("Guest", result.Username);
        // Kontrollera att inga personliga uppgifter sparas
        _mockUserRepository.Verify(repo => repo.SaveGuestUser(It.IsAny<User>()), Times.Once);
    }
    [Fact]
    public void AddToWishlist_GuestUser_ShouldReturnPromptToCreateAccount()
    {
        // Arrange
        var guestUser = new User { IsGuest = true }; 
        string productId = "123";  // Exempel på produkt id

        // Act
        var result = _userService.AddToWishlist(guestUser, productId);

        // Assert
        Assert.Equal("Please create an account to save items to your wishlist.", result);
    }
}
