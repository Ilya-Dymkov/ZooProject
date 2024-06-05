using ZooLibrary.Getters.GettersSource;
using ZooLibrary.Models;

namespace ZooLibrary.Getters;

public class FoodPriceGetter : IFoodPriceGetter
{
    public async Task<FoodPrice> GetFoodPricesFromFile(string filePath)
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