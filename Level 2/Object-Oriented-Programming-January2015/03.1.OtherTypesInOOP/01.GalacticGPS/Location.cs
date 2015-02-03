using System;

struct Location
{
    private double latitude;
    private double longtitude;
    private Planet planet;

    public double Latitude
    {
        get
        {
            return this.latitude;
        }
        set
        {
            this.latitude = value;    
        } 
    }
    public double Longtitude
    {
        get
        {
            return this.longtitude;
        }
        set
        {
            this.longtitude = value;
        }
    }

    public Planet Planet
    {
        get
        {
            return this.planet;
        }
        set
        {
            if ((int)value < 0 || (int)value > 7)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.planet = value;
        }
    }

    public Location(double latitude, double longtitude, Planet planet)
    {
        this.latitude = 0;
        this.longtitude = 0;
        this.planet = 0;

        this.Latitude = latitude;
        this.Longtitude = longtitude;
        this.Planet = planet;
    }

    public override string ToString()
    {
        return this.Latitude + ", " + this.Longtitude + ", " + this.Planet;
    }
}
