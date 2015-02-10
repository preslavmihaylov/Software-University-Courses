using System;
using System.Collections.Generic;

class CustomerDemo
{
    static void Main()
    {
        Customer first = new Customer("Gosho", "Goshev", "Todorov", "20", "Sofia", "0892323", "gosh@gosg.bg",
                        new List<Payment>(), CustomerType.Diamond);

        Customer second = new Customer("Gosho", "Goshev", "Todorov", "20", "Sofia", "0892323", "gosh@gosg.bg", 
                        new List<Payment>(), CustomerType.Diamond);

        Customer third = new Customer("Gosho", "Goshev", "Todoro", "20", "Sofia", "0892323", "gosh@gosg.bg",
                        new List<Payment>(), CustomerType.Diamond);

        Customer fourth = (Customer)first.Clone();

        Console.WriteLine(first == third);
        Console.WriteLine(first == fourth);
        Console.WriteLine(Object.ReferenceEquals(first, fourth));
    }
}
