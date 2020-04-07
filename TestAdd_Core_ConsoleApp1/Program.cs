using System;
using System.Collections.Generic; // Added 2/16/2020 thomas downes
using AddHugeNumbersNetCore;  //Added 4/7/2020 thomas downes 

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
                char keyPressed = Console.ReadKey(true).KeyChar;
                //Added 4/7/2020 thomas downes
                if (keyPressed == 'y' || keyPressed == 'Y')
                {
                    Console.WriteLine("__");
                    Console.WriteLine("__Enter huge decimal number 3:");
                    listOfNumbers.Add(Console.ReadLine());
                }
                else break;
            } while (true);

            //
            //Added 4/7/2020 thomas downes
            //
            string strErrorMessage = "";

            //Added 4/7/2020 thomas downes
            string strTotalSummed =
                AddingDecs.AddAnyTwoDecStrings(listOfNumbers[0], listOfNumbers[1], ref strErrorMessage);

            if ("" != strErrorMessage) throw new Exception("Problem adding: " + strErrorMessage);

            if (listOfNumbers.Count == 3)
            {
                //
                // Include the 3rd number. 
                //
                strTotalSummed =
                AddingDecs.AddAnyTwoDecStrings(strTotalSummed, listOfNumbers[2], ref strErrorMessage);

                if ("" != strErrorMessage) throw new Exception("Problem adding: " + strErrorMessage); 

            }



        }
    }
}
