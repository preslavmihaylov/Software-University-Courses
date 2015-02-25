namespace FarmersCreed.Interfaces
{
    using Enumerations;
    using FarmersCreed.Units;

    public interface IEdible : IProduct 
    {
        FoodType FoodType { get; set; }

        int HealthEffect { get; set; }
    }
}
