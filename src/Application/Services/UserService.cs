using Application.Interfaces;
using Application.Users.Dtos;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IRepository<AppUser, Guid> _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppLogger<UserService> _logger;

    public UserService(IRepository<AppUser, Guid> userRepository, IUnitOfWork unitOfWork, IAppLogger<UserService> logger)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public Task<UserDto> CreateUserAsync(string firstName, string lastName, string email, string password, string role)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto?> GetUserByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
