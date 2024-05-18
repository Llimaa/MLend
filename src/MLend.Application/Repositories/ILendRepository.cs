namespace MLend.Application;

public interface ILendRepository 
{
    Task InsertAsync(Lend lend, CancellationToken cancellationToken);
    Task UpdateAsync(Lend lend, CancellationToken cancellationToken);
    Task<Lend> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistWithBookIdAndStatusLoan(Guid bookId, CancellationToken cancellationToken);
    Task<IEnumerable<Lend>> GetLendsByStatus(Status status, CancellationToken cancellationToken);
}
