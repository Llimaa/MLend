using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MLend.Infrastructure;

public class DbContext : IDbContext
{
    private IMongoDatabase database { get; }

    public DbContext(IOptions<MongoDbSettings> mongodbSettings) 
    {
        var mongoClient = new MongoClient(mongodbSettings.Value.ConnectionString);
        database = mongoClient.GetDatabase(mongodbSettings.Value.DatabaseName);
    }
    public IMongoCollection<T> GetCollection<T>(string name) =>
        database.GetCollection<T>(name);
}