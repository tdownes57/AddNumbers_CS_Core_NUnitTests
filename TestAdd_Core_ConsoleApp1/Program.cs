using System;
using System.Collections.Generic; // Added 2/16/2020 thomas downes

namespace TestAdd_Core_ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfNumbers = new List<string>();
            //Console.WriteLine("Hello World!");
            //
            Console.WriteLine("_________________________________");
            Console.WriteLine("____                      _______");
            Console.WriteLine("____  Adding Huge Numbers _______");
            Console.WriteLine("____                      _______");
            Console.WriteLine("_________________________________");
            Console.WriteLine("__");
            Console.WriteLine("__Enter huge decimal number #1:");
            listOfNumbers.Add( Console.ReadLine());
            Console.WriteLine("__");
            Console.WriteLine("__Enter huge decimal number #2:");
            listOfNumbers.Add(Console.ReadLine());

            do
            {
                Console.WriteLine("__");
                Console.WriteLine("Enter another huge decimal number?  (Y/N) ");
                Console.WriteLine("__");
                Console.WriteLine("__Enter huge decimal number #2:");
                listOfNumbers.Add(Console.ReadLine());
            } while (true);






        }
    }
}
