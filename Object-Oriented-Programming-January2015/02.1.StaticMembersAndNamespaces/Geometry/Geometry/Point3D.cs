using System;

namespace Geometry
{
    public class Point3D
    {
        private static readonly Point3D start = new Point3D(0, 0, 0);
        private double x;
        private double y;
        private double z;

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public double Z
        {
            get
            {
                return this.z;
            }

            set
            {
                this.z = value;
            }
        }

        public static Point3D StartingPoint
        {
            get
            {
                return Point3D.start;
            }
        }

        public Point3D(double x = 0, double y = 0, double z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }



        public override string ToString()
        {
            return "{" + this.X + ", " + this.Y + ", " + this.Z + "}";
        }
    }
}
