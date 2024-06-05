using System.Data;

namespace ZooLibrary.Models;

public class AnimalType(string name, decimal coefficient, string foodType)
{
    public string Name { get; } = name;
    public decimal Coefficient { get; } = coefficient;
    public string FoodType { get; } = foodType;
    public int? MeatPercentage { get; set; }

    public void CalculateCost(FoodPrice foodPrice, decimal animalWeight, ref decimal totalCost)
    {
        var foodQuantity = animalWeight * Coefficient;

        switch (FoodType)
        {
            case "meat":
                totalCost += foodQuantity * foodPrice.MeatPrice;
                break;
            case "fruit":
                totalCost += foodQuantity * foodPrice.FruitPrice;
                break;
            case "both":
            {
                var meatQuantity = foodQuantity * (MeatPercentage / 100m);
                var fruitQuantity = foodQuantity - meatQuantity;

                if (meatQuantity != null && fruitQuantity != null)
                    totalCost += (decimal)meatQuantity * foodPrice.MeatPrice +
                                 (decimal)fruitQuantity * foodPrice.FruitPrice;
                else throw new DataException($"Meat percentage is not set for type {Name}!");
                break;
            }
            default: throw new DataException($"Food type '{FoodType}' does not exist!");
        }
    }
}