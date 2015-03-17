using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            // Console.WriteLine(FilenameUtils.GetFileExtension("example")); - Won't compile
            Console.WriteLine(FilenameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FilenameUtils.GetFileExtension("example.new.pdf"));

            // Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example")); - Won't compile
            Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Geometry2D.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Geometry3D.CalcDistance3D(5, 2, -1, 3, -6, 4));

            const double width = 3;
            const double height = 4;
            const double depth = 5;
            Console.WriteLine("Volume = {0:f2}", Geometry3D.CalcVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry3D.CalcDistance3D(0, width, 0, height, 0, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry2D.CalcDistance2D(0, width, 0, height));
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry2D.CalcDistance2D(0, width, 0, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry2D.CalcDistance2D(0, height, 0, depth));
        }
    }
}
