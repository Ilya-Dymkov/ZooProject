using OwnImplementationGetters.OwnGetters;
using ZooLibrary.Getters;
using ZooLibrary.ZooMethods;

var zoo = new ZooCalculator(new FoodPriceGetter(), new AnimalTypesGetter(), new AnimalsGetter());

zoo.CalculateTotalCost(getter => getter.GetFoodPriceFromDb());