using System;
using exFixInterface.Entities;
using exFixInterface.Services;

namespace exFixInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine());
            Console.Write("Enter the number of installments: ");
            int numberInstallments = int.Parse(Console.ReadLine());
            Contract contract = new Contract(number, date, contractValue, numberInstallments, new PaypalService());
            Console.WriteLine(contract.ToString());


        }
    }
}
