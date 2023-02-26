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
                    "Server=localhost;Port=5432;Username=postgres;Password=123;Database=TelecomNevaSvyasDB;");
            conn.Open();
            
            if (conn != null) {Console.WriteLine("Success");}
            else {Console.WriteLine("Not Success");}
            
        }
        catch (Exception)
        {
            Console.WriteLine("Error...");
        }
    }
}