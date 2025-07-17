using Domain.Entities;
using Persistence.Contexts;

namespace Infrastructure.Repositories;

public class PermissionRepository : GenericRepository<Permission, Guid>
{
    public PermissionRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
