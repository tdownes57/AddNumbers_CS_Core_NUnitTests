using System;
using System.Collections.Generic; // Added 2/16/2020 thomas downes
using AddHugeNumbersNetCore;  //Added 4/7/2020 thomas downes 

namespace TestAdd_Core_ConsoleApp1
{
    class Program
    {
        private static bool mod_bUserStoppedExecution = false; // Added 4/12/2020 thomas downes

        static void Main(string[] args)
        {
            //
            // Encapsulated 4/12/2020 thomas  
            //
            Console.WriteLine("_________________________________________________________________________");
            Console.WriteLine("____                                                              _______");
            Console.WriteLine("____  Adding Huge Numbers / Fibonacci / Incrmenting to a Trillion _______");
            Console.WriteLine("____                                                              _______");
            Console.WriteLine("_________________________________________________________________________");

            // Establish an event handler to process key press events.
            //  https://docs.microsoft.com/en-us/dotnet/api/system.console.cancelkeypress?view=netframework-4.8
            //
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);

            //bool boolAdding;
            //bool boolFibonacci;
            //bool boolIncrementing;  
            bool bUserWantsToExit = false;

            do
            {
                //Added 4/12/2020 thomas downes
                Console.WriteLine("__");
                Console.WriteLine("Which: Adding (A), Fibonacci (F), Incrementing (I) ? ");
                Console.WriteLine("__");
                Console.WriteLine("__ (Press X to exit the program.)");
                Console.WriteLine("__");
                //char keyPressed = Console.ReadKey(true).KeyChar;
                var keyPressedInfo = Console.ReadKey(true);

                switch (keyPressedInfo.Key)
                {
                    case (ConsoleKey.A): Main_AddingHugeNumbers(); break;
                    case (ConsoleKey.F): FibonacciViaDP.Fibonacci_Choices(); break;
                    case (ConsoleKey.I): Main_Incrementing(); break;

                    //
                    // Allow the user to exit the program. 
                    //
                    case (ConsoleKey.X): bUserWantsToExit = true; break;

                }

                if (bUserWantsToExit) break;
                if (mod_bUserStoppedExecution) break; 

            } while (true);






        }


        static void Main_AddingHugeNumbers()
        {
            //
            //Added 4/12/2020 Thomas Downes
            //
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
            listOfNumbers.Add(Console.ReadLine());
            Console.WriteLine("__");
            Console.WriteLine("__Enter huge decimal number #2:");
            listOfNumbers.Add(Console.ReadLine());

            do
            {
                if (mod_bUserStoppedExecution) break;  // Added 4/12/2020 td
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

            //
            // Output the sum. 
            //
            Console.WriteLine("...");
            Console.WriteLine("The sum of the numbers is as follows: ");
            Console.WriteLine("...");
            Console.WriteLine(strTotalSummed);
            Console.WriteLine("...");
            Console.WriteLine("...");
            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();

        }


        static void Main_Incrementing()
        {
            //
            //Added 4/12/2020 Thomas Downes
            //
            string strNumber = "1";
            int intSleepMS = 100;
            bool boolSleepActivated = false;

            do //while (true)
            {
                //if (mod_bUserStoppedExecution) break; 
                if (mod_bUserStoppedExecution)
                {
                    Console.WriteLine(".....");
                    Console.WriteLine("Want to stop/terminate the sequence?  (For termination, press Y.)");
                    Console.WriteLine(".....");
                    if (Console.ReadKey(true).Key == ConsoleKey.Y) break;
                    Console.WriteLine(".....");
                    Console.WriteLine("Want to slow down the sequence, to a reasonable speed?  (For slowness, press Y.)");
                    Console.WriteLine(".....");
                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    {
                        // Added 4/12/2020 thomas downes 
                        boolSleepActivated = true;  
                        intSleepMS *= 100;
                    }
                }

                Console.WriteLine(strNumber);

                //
                // Major call !!  
                //
                strNumber = AddHugeNumbersNetCore.IncrementingNumbers.Increment(strNumber);  

                if (boolSleepActivated) System.Threading.Thread.Sleep(intSleepMS);  

            } while (true);

        }


        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            //
            //  https://docs.microsoft.com/en-us/dotnet/api/system.console.cancelkeypress?view=netframework-4.8
            //
            mod_bUserStoppedExecution = true;
            args.Cancel = true;  //Suppress the default behavior caused by CTRL-C.  
        }


    }

}
