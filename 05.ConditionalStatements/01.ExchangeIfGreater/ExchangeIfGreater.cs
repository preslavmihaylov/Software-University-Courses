using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExchangeIfGreater
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        if (b > a)
        {
            Console.WriteLine("{0} {1}", b, a); 
        }
        else
        {
            Console.WriteLine("{0} {1}", a, b);
        }
    }
}
