using ZooLibrary.Getters.GettersSource;
using ZooLibrary.Models;

namespace ZooLibrary.Getters;

public class AnimalsGetter : IAnimalsGetter
{
    public async Task<IList<Animal>> GetAnimalsFromFile(string filePath) =>
        (await File.ReadAllLinesAsync(filePath))
            .Skip(1)
            .Select(line => line.Split(';'))
            .Select(parts => new Animal { Type = parts[0], Name = parts[1], Weight = decimal.Parse(parts[2]) })
            .ToList();
}