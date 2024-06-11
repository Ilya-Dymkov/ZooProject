using ZooLibrary.Models;

namespace ZooLibrary.Getters;

public interface IAnimalTypesGetter<in TSource>
{
    Task<IDictionary<string, AnimalType>> GetAnimalTypes(TSource source);
}