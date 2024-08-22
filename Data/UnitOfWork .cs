using StudentApi.Models;

namespace StudentApi.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly Context _context;
    private readonly MongoDbContext _mongoContext;

    private Repository<Student>? _students;
    private MongoRepository<Cohort>? _cohorts;


    public UnitOfWork(Context context, MongoDbContext mongoContext)
    {
        _context = context;
        _mongoContext = mongoContext;
    }

    public IRepository<Student> Students => _students ??= new Repository<Student>(_context);
    public IRepository<Cohort> Cohorts => _cohorts ??= new MongoRepository<Cohort>(_mongoContext);


    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

