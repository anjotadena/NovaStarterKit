using Application.Users.Dtos;

namespace Application.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateUserAsync(string firstName, string lastName, string email, string password, string role);
    Task<UserDto?> GetUserByIdAsync(Guid id);
}
