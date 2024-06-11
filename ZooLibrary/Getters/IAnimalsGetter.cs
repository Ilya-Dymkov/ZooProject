using ZooLibrary.Models;

namespace ZooLibrary.Getters;

public interface IAnimalsGetter<in TSource>
{
    Task<IList<Animal>> GetAnimals(TSource source);
}