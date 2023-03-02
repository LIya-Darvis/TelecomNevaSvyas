using System;

namespace TelecomNevaSvyas.DBModels;

public class Employee
{
    public int Id { get; set; }
    public int PositionId { get; set; }
    public int Number { get; set; }
    public string? Password { get; set; }
}