using System.Data;
using ZooLibrary.Getters.GettersSource;
using ZooLibrary.Models;

namespace ZooLibrary.ZooMethods;

public class ZooCalculator(
    IFoodPriceGetter foodPriceGetter,
    IAnimalTypesGetter animalTypesGetter,
    IAnimalsGetter animalsGetter)
{
    public async Task<decimal> CalculateTotalCost(
        Func<IFoodPriceGetter, Task<FoodPrice>> getFoodPrice,
        Func<IAnimalTypesGetter, Task<IDictionary<string, AnimalType>>> getAnimalTypes,
        Func<IAnimalsGetter, Task<IList<Animal>>> getAnimals)
    {
        var animals = getAnimals(animalsGetter);
        var animalTypes = await getAnimalTypes(animalTypesGetter);
        var foodPrice = await getFoodPrice(foodPriceGetter);

        decimal totalCost = 0;

        foreach (var animal in await animals)
            if (animalTypes.TryGetValue(animal.Type, out var animalType))
                animalType.CalculateCost(foodPrice, animal.Weight, ref totalCost);
            else throw new DataException($"Animal type '{animal.Type}' does not exist!");

        return totalCost;
    }
}