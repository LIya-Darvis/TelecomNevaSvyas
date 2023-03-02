using Microsoft.EntityFrameworkCore;

namespace TelecomNevaSvyas.DBModels;

public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;User Id=postgres;Password=123;Database=TelecomNevaSvyasDB");
    }
}