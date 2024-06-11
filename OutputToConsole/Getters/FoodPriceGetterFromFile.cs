using ZooLibrary.Getters;
using ZooLibrary.Models;

namespace OutputToConsole.Getters;

public class FoodPriceGetterFromFile : IFoodPriceGetter<string>
{
    public async Task<FoodPrice> GetFoodPrices(string filePath)
    {
        var foodPrice = new FoodPrice();
        
        foreach (var line in await File.ReadAllLinesAsync(filePath))
        {
            var parts = line.Split('=');
            
            switch (parts[0])
            {
                case "Meat":
                    foodPrice.MeatPrice = decimal.Parse(parts[1]);
                    break;
                case "Fruit":
                    foodPrice.FruitPrice = decimal.Parse(parts[1]);
                    break;
            }
        }
        
        return foodPrice;
    }
}