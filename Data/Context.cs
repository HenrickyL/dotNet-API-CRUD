using Microsoft.EntityFrameworkCore;
using StudentApi.Models;

namespace StudentApi.Data;

public class Context : DbContext
{
    DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseOracle("User Id=system;Password=YourPassword;Data Source=localhost:1521/XEPDB1;");
        base.OnConfiguring(optionsBuilder);
    }
}
