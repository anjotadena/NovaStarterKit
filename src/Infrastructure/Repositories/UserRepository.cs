using Domain.Entities;
using Persistence.Contexts;

namespace Infrastructure.Repositories;

public class UserRepository : GenericRepository<AppUser, Guid>
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
