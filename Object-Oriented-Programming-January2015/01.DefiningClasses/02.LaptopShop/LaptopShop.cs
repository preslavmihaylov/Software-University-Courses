using System;
    class LaptopShop
    {
        static void Main()
        {
            Laptop lenovo = new Laptop("Lenovo Z50-75", 1000, "Lenovo Ltd.", "AMD", 8000);
            Console.WriteLine(lenovo.ToString());
        }
    }
