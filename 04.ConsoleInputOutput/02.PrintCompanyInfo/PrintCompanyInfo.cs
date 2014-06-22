using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class PrintCompanyInfo
{
    static void Main()
    {
        Console.WriteLine("Input company name:");
        string companyName = Console.ReadLine();
        Console.WriteLine("Input company address:");
        string companyAddress = Console.ReadLine();
        Console.WriteLine("Input phone number:");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Input fax number:");
        string faxNumber = Console.ReadLine();

        if (faxNumber == "")
        {
            faxNumber = "(no fax)";
        }

        Console.WriteLine("Input website:");
        string website = Console.ReadLine();
        Console.WriteLine("Input manager first name:");
        string managerFirstName = Console.ReadLine();
        Console.WriteLine("Input manager last name:");
        string managerLastName = Console.ReadLine();
        Console.WriteLine("Input manager age:");
        string managerAge = Console.ReadLine();
               
        Console.WriteLine("Input manager phone number:");
        string managerPhone = Console.ReadLine();

        Console.WriteLine(@"
{0}
Address: {1}
Tel. {2}
Fax: {3}
Website: {4}
Manager: {5} {6}
(age: {7}, tel. {8})", companyName, companyAddress, phoneNumber, faxNumber, website, managerFirstName,
                     managerLastName, managerAge, managerPhone);
        
        
    }
}
