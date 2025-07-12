using Application.Interfaces;
using Application.Users.Dtos;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IRepository<User, Guid> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IRepository<User, Guid> userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto> CreateUserAsync(string firstName, string lastName, string email, string password, string role)
    {
        var user = new User(
            firstName,
            lastName,
            Email.Create(email),
            password,
            Enum.Parse<Role>(role));

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return new UserDto(user.Id, user.FirstName, user.LastName, user.Email.Value, user.Role.ToString());
    }

    public async Task<UserDto?> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return user is null ? null : new UserDto(user.Id, user.FirstName, user.LastName, user.Email.Value, user.Role.ToString());
    }
}
