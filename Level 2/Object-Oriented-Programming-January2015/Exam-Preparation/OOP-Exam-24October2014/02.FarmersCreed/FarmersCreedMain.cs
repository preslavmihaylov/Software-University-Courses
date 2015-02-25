namespace FarmersCreed
{
    using System;
    using Enumerations;
    using Interfaces;
    using Simulator;
    using Units;
    using Units.Animals;
    using Units.Products;

    class FarmersCreedMain
    {
        static void Main()
        {
            // Farm farm = new Farm("pesho");
            // farm.AddProduct(new Food("jito", ProductType.Grain, FoodType.Organic, 2, 5));
            // farm.Animals.Add(new Swine("gosho"));
            // farm.Feed(farm.Animals[0], farm.Products[0] as IEdible, 2);
            // farm.Feed(farm.Animals[0], farm.Products[0] as IEdible, 2);
            // Console.WriteLine(farm);
            ModifiedFarmSimulator simulator = new ModifiedFarmSimulator();
            simulator.Run();
        }
    }
}
