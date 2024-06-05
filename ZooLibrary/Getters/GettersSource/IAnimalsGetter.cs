using ZooLibrary.Models;

namespace ZooLibrary.Getters.GettersSource;

public interface IAnimalsGetter
{
    Task<IList<Animal>> GetAnimalsFromFile(string filePath);
}