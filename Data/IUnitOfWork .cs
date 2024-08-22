using StudentApi.Models;

namespace StudentApi.Data;

public interface IUnitOfWork : IDisposable
{
    IRepository<Student> Students { get; }
    IRepository<Cohort> Cohorts { get; }

    Task<int> CompleteAsync();
}
