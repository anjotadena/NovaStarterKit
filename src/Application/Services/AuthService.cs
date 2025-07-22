using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<AppUser, Guid> _userRepository;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthService(IRepository<AppUser, Guid> userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = jwtTokenGenerator;
    }

    public Task<string?> LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }
}
