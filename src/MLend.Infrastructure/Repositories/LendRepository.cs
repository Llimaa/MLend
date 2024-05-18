using Microsoft.Extensions.Options;
using MLend.Application;
using MongoDB.Driver;

namespace MLend.Infrastructure;

public class LendRepository : ILendRepository
{
    private readonly IMongoCollection<Lend> collection;
    
    public LendRepository(IDbContext dbContext, IOptions<MongoDbSettings> mongodbSettings) =>
        collection =dbContext.GetCollection<Lend>(mongodbSettings.Value.LendCollection);

    public async Task<bool> ExistWithBookIdAndStatusLoan(Guid bookId, CancellationToken cancellationToken) =>
        await collection.Find(x => x.BookId == bookId && x.Status == Status.Loan).AnyAsync(cancellationToken);

    public async Task<Lend> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await collection.Find(_ => _.Id == id).FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<Lend>> GetLendsByStatus(Status status, CancellationToken cancellationToken) =>
        await collection.Find(_ => _.Status == status).ToListAsync(cancellationToken);

    public async Task InsertAsync(Lend lend, CancellationToken cancellationToken) =>
        await collection.InsertOneAsync(lend, cancellationToken: cancellationToken);

    public async Task UpdateAsync(Lend lend, CancellationToken cancellationToken) =>
        await collection.ReplaceOneAsync(_ => _.Id == lend.Id, lend, cancellationToken: cancellationToken);
}
