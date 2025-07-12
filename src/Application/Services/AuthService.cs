using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User, Guid> _userRepository;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthService(IRepository<User, Guid> userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = jwtTokenGenerator;
    }

    public async Task<string?> LoginAsync(string email, string password)
    {
        var emailRequest = email.ToLowerInvariant();

        var user = (await _userRepository.FindAsync(u => u.Email.Value == emailRequest)).FirstOrDefault();

        if (user is null || !user.VerifyPassword(password))
        {
            throw new Exception("User not found. Invalid email or password");
        }

        return _tokenGenerator.GenerateToken(user.Id, user.Email.Value, user.Role.ToString());
    }
}
