using ZooLibrary.Getters.GettersSource;
using ZooLibrary.Models;

namespace OwnImplementationGetters.OwnGetters;

public static class OwnAnimalsGetter
{
    public static Task<FoodPrice> GetFoodPriceFromDb(this IFoodPriceGetter getter)
    {
        throw new NotImplementedException();
    }
}