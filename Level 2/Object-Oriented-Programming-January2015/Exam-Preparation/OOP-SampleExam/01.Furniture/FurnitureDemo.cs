using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Interfaces.Engine;

class FurnitureDemo
{
    static void Main()
    {
        IFurnitureManufacturerEngine engine = FurnitureManufacturerEngine.Instance;
        engine.Start();
    }
}
