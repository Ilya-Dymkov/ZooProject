using ZooLibrary.Models;

namespace ZooLibrary.Getters.GettersSource;

public interface IAnimalTypesGetter
{
    Task<IDictionary<string, AnimalType>> GetAnimalTypesFromFile(string filePath);
}