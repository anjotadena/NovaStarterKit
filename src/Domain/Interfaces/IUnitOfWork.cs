namespace Domain.Interfaces;

// Ensures all changes are saved in a single transaction
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
