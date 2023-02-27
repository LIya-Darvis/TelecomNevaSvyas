using System;
using Npgsql;

namespace TelecomNevaSvyas.DBModels;

public class DBConnection
{
    public NpgsqlConnection Connection()
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=123;Database=TelecomNevaSvyasDB;");
        conn.Open();

        return conn;
    }
}