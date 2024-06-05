using ZooLibrary.Models;

namespace ZooLibrary.Getters.GettersSource;

public interface IFoodPriceGetter
{
    Task<FoodPrice> GetFoodPricesFromFile(string filePath);
}