using Microsoft.EntityFrameworkCore;
using StudentApi.Models;

namespace StudentApi.Data;

public class Context : DbContext
{
    DbSet<Student> Students { get; set; }
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var username = Environment.GetEnvironmentVariable("POSTGRES_USER");
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            var database = Environment.GetEnvironmentVariable("POSTGRES_DB");
            var host = "postgres"; // nome do serviço definido no docker-compose.yml
            var connectionString = $"Host={host};Database={database};Username={username};Password={password}";

            optionsBuilder.UseNpgsql(connectionString);
        }
            base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("Students");
    }
}
