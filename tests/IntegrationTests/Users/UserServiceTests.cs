using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Users;

public class UserServiceTests
{
    private readonly IUserService _userService;

    public UserServiceTests()
    {
        var provider = TestSetup.BuildServiceProvider();

        _userService = provider.GetRequiredService<IUserService>();
    }

    [Fact]
    public async Task CreateUser_ShouldReturnUserDto_WithValidInput()
    {
        // Arrange
        var firstName = "Test";
        var lastName = "User";
        var email = "test.user@email.co";
        var password = "password";
        var role = "User";

        // Act
        var result = await _userService.CreateUserAsync(firstName, lastName, email, password, role);

        Assert.NotNull(result);
        Assert.Equal(firstName, result.FirstName);
        Assert.Equal(lastName, result.LastName);
        Assert.Equal(email, result.Email);
        Assert.Equal(role, result.Role);
    }
}
