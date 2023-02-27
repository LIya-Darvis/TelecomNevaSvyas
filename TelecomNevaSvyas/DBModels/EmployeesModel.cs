using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Npgsql;

namespace TelecomNevaSvyas.DBModels;

public class EmployeesModel
{
    static DBConnection connection = new DBConnection();
    NpgsqlConnection conn = connection.Connection();
    
    private const string TABLE_NAME = "Employees";


    
    

    public bool NumberInDB(String number)
    {
        // Define a query returning a single row result set
        NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM {TABLE_NAME}", conn);

        List<string> numbers = new List<string>();
        
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            numbers.Add(reader.GetInt32(2).ToString());
        }
        if (numbers.Contains(number)) {return true;}
        else { return false;}

    }
    
    public bool PasswordInDB(String number)
    {
        // Define a query returning a single row result set
        NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM {TABLE_NAME}", conn);

        List<string> numbers = new List<string>();
        
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            numbers.Add(reader.GetInt32(3).ToString());
        }
        if (numbers.Contains(number)) {return true;}
        else { return false;}

    }
}

public class BoardEmployee
{
    public int Id { get; set; }
    public int PositionId { get; set; }
    public int Number { get; set; }
    public string? Password { get; set; }
}
