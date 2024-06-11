using ZooLibrary.Getters;
using ZooLibrary.Models;

namespace OutputToConsole.Getters;

public class AnimalTypesGetterFromFile : IAnimalTypesGetter<string>
{
    public async Task<IDictionary<string, AnimalType>> GetAnimalTypes(string filePath)
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