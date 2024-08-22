using MongoDB.Driver;
using StudentApi.Models;


namespace StudentApi.Data;
public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
        _database = client.GetDatabase("CohortDb");
    }
    public IMongoDatabase GetDatabase() => _database;
    public IMongoCollection<Cohort> Cohorts => _database.GetCollection<Cohort>("Cohorts");
}
