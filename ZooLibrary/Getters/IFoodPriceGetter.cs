using ZooLibrary.Models;

namespace ZooLibrary.Getters;

public interface IFoodPriceGetter<in TSource>
{
    Task<FoodPrice> GetFoodPrices(TSource source);
}