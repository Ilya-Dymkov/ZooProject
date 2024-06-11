using OutputToConsole.Getters;
using ZooLibrary.ZooMethods;

var zooCalculator = new ZooCalculator<string, string, string>(
    new FoodPriceGetterFromFile(), new AnimalTypesGetterFromFile(), new AnimalsGetterFromFile());

var stringTotalCost = zooCalculator.CalculateTotalCost(
    @"C:\Users\Ilya\RiderProjects\ZooProject\OutputToConsole\Data\prices.txt",
    @"C:\Users\Ilya\RiderProjects\ZooProject\OutputToConsole\Data\animals.csv",
    @"C:\Users\Ilya\RiderProjects\ZooProject\OutputToConsole\Data\zoo.csv");

Console.WriteLine($"Total cost: {await stringTotalCost:C}");