namespace eAppointmentServer.Domain.Repositories.GenericRepositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    int SaveChanges();
}
