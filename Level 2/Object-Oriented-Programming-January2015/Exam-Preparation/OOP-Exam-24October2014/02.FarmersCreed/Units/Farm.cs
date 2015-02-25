namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Animals;
    using FarmersCreed.Interfaces;

    public class Farm : GameObject, IFarm
    {
        private List<Plant> plants = new List<Plant>();
        private List<Animal> animals = new List<Animal>();
        private List<Product> products = new List<Product>(); 

        public Farm(string id)
            : base(id)
        {
        }

        public List<Plant> Plants
        {
            get
            {
                return this.plants;
            }
        }

        public List<Animal> Animals
        {
            get
            {
                return this.animals;
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public void AddProduct(Product product)
        {
            var productWithSameId = this.Products.Where(p => p.Id == product.Id).Select(p => p).FirstOrDefault();
            if (productWithSameId != null)
            {
                productWithSameId.Quantity += product.Quantity;
            }
            else
            {
                this.Products.Add(product);
            }
        }

        public void Exploit(IProductProduceable productProducer)
        {
            Product product = productProducer.GetProduct();
            this.AddProduct(product);
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            if (edibleProduct.Quantity >= productQuantity)
            {
                animal.Eat(edibleProduct, productQuantity);
                edibleProduct.Quantity -= productQuantity;
            }
            else
            {
                throw new ArgumentException("There is not enough quantity of the specified product.");
            }
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            foreach (Plant plant in this.Plants)
            {
                if (plant.HasGrown)
                {
                    plant.Wither();
                }
                else
                {
                    plant.Grow();
                }
            }

            foreach (Animal animal in this.Animals)
            {
                animal.Starve();
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            var selectedAnimals = this.Animals.Where(a => a.IsAlive).OrderBy(a => a.Id);
            var selectedPlants = this.Plants.Where(p => p.IsAlive).OrderBy(p => p.Health).ThenBy(p => p.Id);
            var selectedProducts = this.Products.OrderBy(p => p.ProductType.ToString()).ThenByDescending(p => p.Quantity).ThenBy(p => p.Id);

            foreach (var animal in selectedAnimals)
            {
                output.Append(animal.ToString() + Environment.NewLine);
            }

            foreach (var plant in selectedPlants)
            {
                output.Append(plant.ToString() + Environment.NewLine);
            }

            foreach (var product in selectedProducts)
            {
                output.Append(product.ToString() + Environment.NewLine);
            }

            return base.ToString() + Environment.NewLine + output.ToString();
        }
    }
}
