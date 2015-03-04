namespace RestaurantManager.Engine.Factories
{
    using Models.Restaurants;
    using Interfaces.Engine;

    public class RestaurantFactory : IRestaurantFactory
    {
        public Interfaces.IRestaurant CreateRestaurant(string name, string location)
        {
            return new Restaurant(name, location);
        }
    }
}
