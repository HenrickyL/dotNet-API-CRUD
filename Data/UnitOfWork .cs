using StudentApi.Models;

namespace StudentApi.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly Context _context;
    private Repository<Student>? _students;

    public UnitOfWork(Context context)
    {
        _context = context;
    }

    public IRepository<Student> Students => _students ??= new Repository<Student>(_context);

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

