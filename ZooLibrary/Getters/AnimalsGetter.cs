using ZooLibrary.Getters.GettersSource;
using ZooLibrary.Models;

namespace ZooLibrary.Getters;

public class AnimalsGetter : IAnimalsGetter
{
    public async Task<IList<Animal>> GetAnimalsFromFile(string filePath) =>
        (await File.ReadAllLinesAsync(filePath))
            .Skip(1)
            .Select(line => line.Split(';'))
            .Select(parts => new Animal(parts[0], parts[1], decimal.Parse(parts[2])))
            .ToList();
}