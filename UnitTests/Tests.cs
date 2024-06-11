using OutputToConsole.Getters;
using ZooLibrary.ZooMethods;

namespace UnitTests;

public class Tests
{
    [Test]
    public async Task TestZooCalculator()
    {
        var zooCalculator = new ZooCalculator<string, string, string>(
            new FoodPriceGetterFromFile(), new AnimalTypesGetterFromFile(), new AnimalsGetterFromFile());
        
        Assert.That(await zooCalculator.CalculateTotalCost(
                @"C:\Users\Ilya\RiderProjects\ZooProject\OutputToConsole\Data\prices.txt",
                @"C:\Users\Ilya\RiderProjects\ZooProject\OutputToConsole\Data\animals.csv",
                @"C:\Users\Ilya\RiderProjects\ZooProject\OutputToConsole\Data\zoo.csv"), 
            Is.EqualTo(1609.00896m));
    }
}