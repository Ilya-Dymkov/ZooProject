using ZooLibrary.Getters;
using ZooLibrary.ZooMethods;

var zooCalculator = new ZooCalculator(new FoodPriceGetter(), new AnimalTypesGetter(), new AnimalsGetter());
var totalCost = zooCalculator.CalculateTotalCost(
    getter => getter.GetFoodPricesFromFile(@"C:\Users\Ilya\RiderProjects\ZooProject\ZooConsoleTest\prices.txt"),
    getter => getter.GetAnimalTypesFromFile(@"C:\Users\Ilya\RiderProjects\ZooProject\ZooConsoleTest\animals.csv"),
    getter => getter.GetAnimalsFromFile(@"C:\Users\Ilya\RiderProjects\ZooProject\ZooConsoleTest\zoo.csv"));

Console.WriteLine($"Total cost: {await totalCost:C}");