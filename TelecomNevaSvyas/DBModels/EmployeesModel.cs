using System;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace TelecomNevaSvyas.DBModels;
using Npgsql;

public class EmployeesModel : DbContext
{
    public DbSet<Positions> Positions { get; set; }
    public EmployeesModel()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=TelecomNevaSvyasDB;Username=postgres;Password=123");
    }
}