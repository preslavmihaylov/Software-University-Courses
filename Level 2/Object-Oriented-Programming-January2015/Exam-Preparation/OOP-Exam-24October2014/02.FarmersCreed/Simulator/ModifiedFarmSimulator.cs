namespace FarmersCreed.Simulator
{
    using System;
    using Enumerations;
    using Interfaces;
    using Units;
    using Units.Animals;
    using Units.Plants;
    using Units.Plants.FoodPlants;
    using Units.Products;

    class ModifiedFarmSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "create":
                    string farmId = inputCommands[1];
                    this.farm = new Farm(farmId);
                    break;
                case "add":
                    this.AddObjectToFarm(inputCommands);
                    break;
                case "status":
                    this.PrintObjectStatus(inputCommands);
                    break;
                case "feed":
                    this.FeedAnimalById(inputCommands);
                    break;
                case "water":
                    this.WaterPlantById(inputCommands);
                    break;
                case "exploit":
                    this.ExploitFarmUnit(inputCommands);
                    break;
                default:
                    break;
            }   
        }

        private void ExploitFarmUnit(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            if (type == "animal")
            {
                Animal animal = this.GetAnimalById(id);
                this.farm.Exploit(animal);
            }
            else if (type == "plant")
            {
                Plant plant = this.GetPlantById(id);
                this.farm.Exploit(plant);
            }
        }

        private void WaterPlantById(string[] inputCommands)
        {
            var plantId = inputCommands[1];

            Plant plant = this.GetPlantById(plantId);
            this.farm.Water(plant);
        }

        private void FeedAnimalById(string[] inputCommands)
        {
            string animalId = inputCommands[1];
            string foodId = inputCommands[2];
            int quantity = int.Parse(inputCommands[3]);

            Animal animal = this.GetAnimalById(animalId);
            Product food = this.GetProductById(foodId);

            if (!(food is IEdible))
            {
                return;
            }

            this.farm.Feed(animal, food as IEdible, quantity);
        }

        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "Grain":
                    var food = new Food(id, ProductType.Grain, FoodType.Organic, 10, 2);
                    this.farm.AddProduct(food);
                    break;
                case "CherryTree":
                    var cherryTree = new CherryTree(id);
                    this.farm.Plants.Add(cherryTree);
                    break;
                case "TobaccoPlant":
                    var tobaccoPlant = new TobaccoPlant(id);
                    this.farm.Plants.Add(tobaccoPlant);
                    break;
                case "Cow":
                    var cow = new Cow(id);
                    this.farm.Animals.Add(cow);
                    break;
                case "Swine":
                    var swine = new Swine(id);
                    this.farm.Animals.Add(swine);
                    break;
                default:
                    break;
            }
        }
    }
}
