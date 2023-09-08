namespace MiniAPI;

public class Task
{
    public string Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
    public int Age { get; set; }
    public string RandomProperty { get; set; }
}
