using StudentApi.Models;

namespace StudentApi.Data;

public interface IUnitOfWork : IDisposable
{
    IRepository<Student> Students { get; }
    Task<int> CompleteAsync();
}
