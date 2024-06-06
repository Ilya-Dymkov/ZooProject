namespace ZooLibrary.Models;

public class Animal(string type, string name, decimal weight)
{
    public string Type { get; } = type;
    public string Name { get; } = name;
    public decimal Weight { get; } = weight;
}