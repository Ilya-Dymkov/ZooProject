using ZooLibrary.Getters;
using ZooLibrary.ZooMethods;

namespace UnitTests;

public class Tests
{
    private ZooCalculator _zooCalculator;
    
    [SetUp]
    public void Setup()
    {
        _zooCalculator = new ZooCalculator(new FoodPriceGetter(), new AnimalTypesGetter(), new AnimalsGetter());
    }

    [Test]
    public async Task TestZooCalculator()
    {
        Assert.That(await _zooCalculator.CalculateTotalCost(
            getter => getter.GetFoodPricesFromFile(
                @"C:\Users\Ilya\RiderProjects\ZooProject\OutputToConsole\prices.txt"),
            getter => getter.GetAnimalTypesFromFile(
                @"C:\Users\Ilya\RiderProjects\ZooProject\OutputToConsole\animals.csv"),
            getter => getter.GetAnimalsFromFile(
                @"C:\Users\Ilya\RiderProjects\ZooProject\OutputToConsole\zoo.csv")),
            Is.EqualTo(1609.00896m));
    }
}