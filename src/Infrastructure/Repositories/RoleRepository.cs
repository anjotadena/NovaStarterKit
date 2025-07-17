using Domain.Entities;
using Persistence.Contexts;

namespace Infrastructure.Repositories;

public class RoleRepository : GenericRepository<Role, Guid>
{
    public RoleRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
