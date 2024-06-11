using System.Data;
using ZooLibrary.Getters;

namespace ZooLibrary.ZooMethods;

public class ZooCalculator<TFoodPriceSource, TAnimalTypesSource, TAnimalsSource>(
    IFoodPriceGetter<TFoodPriceSource> foodPriceGetter,
    IAnimalTypesGetter<TAnimalTypesSource> animalTypesGetter,
    IAnimalsGetter<TAnimalsSource> animalsGetter)
{
    public async Task<decimal> CalculateTotalCost(
        TFoodPriceSource foodPriceSource,
        TAnimalTypesSource animalTypesSource,
        TAnimalsSource animalsSource)
    {
        var animals = animalsGetter.GetAnimals(animalsSource);
        var animalTypes = animalTypesGetter.GetAnimalTypes(animalTypesSource);
        var foodPrice = foodPriceGetter.GetFoodPrices(foodPriceSource);

        decimal totalCost = 0;

        foreach (var animal in await animals)
            if ((await animalTypes).TryGetValue(animal.Type, out var animalType))
                animalType.CalculateCost(await foodPrice, animal.Weight, ref totalCost);
            else throw new DataException($"Animal type '{animal.Type}' does not exist!");

        return totalCost;
    }
}