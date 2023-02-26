namespace TelecomNevaSvyas.DBModels;

public class Positions
{
    public Positions(string name)
    {
        this.Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}