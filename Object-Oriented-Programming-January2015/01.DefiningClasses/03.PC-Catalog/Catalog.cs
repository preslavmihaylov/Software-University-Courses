using System;
using System.Text;
using System.Globalization;
using System.Linq;

class Catalog
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("bg-BG");

        Computer[] computers = new Computer[4];
        computers[0] = new Computer("Lenovo", new Component("Motherboard", 200), new Component("Video card", "Awesome!",120.55555555));
        computers[1] = new Computer("Asus", new Component("Motherboard", 120.66), 
            new Component("SATA Hard Disk", "Good old times", 160.55555555));
        computers[2] = new Computer("Acer", new Component("Motherboard", 60), new Component("Video card", 140.55555555));
        computers[3] = new Computer("Tushiba-Tunishiba", new Component("Motherboard", 459.555),
            new Component("Video card", "Awesome!", 150.55555555), new Component("SSD", "Fancy isn't it?", 562.55555555));

        computers = computers.OrderBy(pc => pc.Price).ToArray();
        foreach (Computer computer in computers)
        {
            Console.WriteLine(computer.ToString());
        }
    }
}
