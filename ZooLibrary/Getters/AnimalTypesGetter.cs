using ZooLibrary.Getters.GettersSource;
using ZooLibrary.Models;

namespace ZooLibrary.Getters;

public class AnimalTypesGetter : IAnimalTypesGetter
{
    public async Task<IDictionary<string, AnimalType>> GetAnimalTypesFromFile(string filePath)
    {
        var animalTypes = new Dictionary<string, AnimalType>();
        
        foreach (var line in await File.ReadAllLinesAsync(filePath))
        {
            var parts = line.Split(';');
            var animalType = new AnimalType(name: parts[0], coefficient: decimal.Parse(parts[1]), foodType: parts[2]);
            
            if (!string.IsNullOrEmpty(parts[3])) animalType.MeatPercentage = int.Parse(parts[3].Trim('%'));
            animalTypes.Add(animalType.Name, animalType);
        }
        
        return animalTypes;
    }
}