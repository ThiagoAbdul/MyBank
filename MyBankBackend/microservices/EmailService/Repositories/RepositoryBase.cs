using EmailService.Data;
using EmailService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EmailService.Repositories;

public abstract class RepositoryBase<T> : IRepository<T> where T : ModelBase
{
    protected readonly IMongoCollection<T> _collection;
    public RepositoryBase(IOptions<DatabaseConfiguration> options, string collectionName)
    {
        DatabaseConfiguration databaseConfiguration = options.Value;
        var mongoClient = new MongoClient(databaseConfiguration.ConnectionString);
        IMongoDatabase mongoDatabase = mongoClient
            .GetDatabase(databaseConfiguration.DatabaseName);
        _collection = mongoDatabase.GetCollection<T>(collectionName);
    }
    public async Task<T> CreateAsync(T t)
    {
        await _collection.InsertOneAsync(t);
        return t;
    }

    public async Task<T?> FindByIdAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}