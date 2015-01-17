using System;
class Laptop
{
    private string model;
    private string manufacturer;
    private int price;
    private string processor;
    private int ram;
    private string graphicsCard;
    private string storage;
    private string screen;
    private Battery battery;

    public string Model 
    {
        get
        {
            return this.model;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The model name cannot be empty.");
            }

            this.model = value;
        }
    }

    public int Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The price cannot be negative.");
            }

            this.price = value;
        }
    }

    public string Storage
    {
        get
        {
            return this.storage;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.storage = value;
        }
    }

    public string Screen
    {
        get
        {
            return this.screen;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.screen = value;
        }
    }

    public string GraphicsCard
    {
        get
        {
            return this.graphicsCard;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.graphicsCard = value;
        }
    }

    public string Manufacturer
    {
        get
        {
            return this.manufacturer;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.manufacturer = value;
        }
    }

    public string Processor
    {
        get
        {
            return this.processor;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }
            this.processor = value;
        }
    }

    public int Ram
    {
        get
        {
            return this.ram;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.ram = value;
        }
    }

    public Laptop(string model, int price, string manufacturer = "Not selected", string processor = "Not selected",
        int ram = 0, string graphicsCard = "Not selected", string storage = "Not selected", string screen = "Not selected",
        string battery = "Not selected", int batteryLife = 0)
    {
        this.Model = model;
        this.Price = price;
        this.Manufacturer = manufacturer;
        this.Processor = processor;
        this.Ram = ram;
        this.GraphicsCard = graphicsCard;
        this.Storage = storage;
        this.Screen = screen;
        this.battery = new Battery(battery, batteryLife);
    }

    public override string ToString()
    {
        string output = "";
        output += "Model: " + this.Model + Environment.NewLine;
        output += "Manufacturer: " + this.Manufacturer + Environment.NewLine;
        output += "Processor: " + this.Processor + Environment.NewLine;
        output += "RAM: " + this.Ram + Environment.NewLine;
        output += "Graphics Card: " + this.GraphicsCard + Environment.NewLine;
        output += "Storage device: " + this.Storage + Environment.NewLine;
        output += "Screen: " + this.Screen + Environment.NewLine;
        output += this.battery.ToString();
        return output;
    }
}
