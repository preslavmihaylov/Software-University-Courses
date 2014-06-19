using System;

//Problem 4.	Rectangles
//Write an expression that calculates rectangle’s perimeter and area by given width and height. 

    class Rectangles
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("The perimeter is {0}", (2 * width) + (2 * height));
            Console.WriteLine("The area is {0}", width * height);
            
            
        }
    }
