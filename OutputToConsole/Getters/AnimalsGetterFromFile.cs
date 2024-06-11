using ZooLibrary.Getters;
using ZooLibrary.Models;

namespace OutputToConsole.Getters;

public class AnimalsGetterFromFile : IAnimalsGetter<string>
{
    public async Task<IList<Animal>> GetAnimals(string filePath) =>
        (await File.ReadAllLinesAsync(filePath))
            .Skip(1)
            .Select(line => line.Split(';'))
            .Select(parts => new Animal(parts[0], parts[1], decimal.Parse(parts[2])))
            .ToList();
}