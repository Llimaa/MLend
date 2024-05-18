using MongoDB.Driver;

namespace MLend.Infrastructure;

public interface IDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}
