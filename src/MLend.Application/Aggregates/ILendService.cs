using System.Collections;

namespace MLend.Application;

public interface ILendService 
{
    Task<Guid> InsertAsync(LendRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(Guid bookId, CancellationToken cancellationToken);

    Task<IEnumerable<Lend>> GetLendsByStatus(Status status, CancellationToken cancellationToken);
}
