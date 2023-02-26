using System;
using System.Data;

namespace TelecomNevaSvyas.DBModels;
using Npgsql;

public class EmployeesModel
{
    public void TestConnection()
    {
        try
        {
            NpgsqlConnection conn =
                new NpgsqlConnection(
                    "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=TelecomNevaSvyasDB;");
            conn.Open();
            Console.WriteLine("Success");
        }
        catch (Exception)
        {
            Console.WriteLine("Error...");
        }
    }
}