using System;
using System.Collections.Generic;
using System.Text;
//----using AddHugeNumbersNetCore; //Added 4/6/2020 thomas downes 

namespace AddHugeNumbersNetCore
{
    public static class FibonacciViaDP
    {
        //
        // Fibonacci processing via DP
        //      (Dynamic Programming)  
        //

        private static bool mod_bUserStoppedExecution = false; // Added 4/7/2020 thomas downes

        public static void Fibonacci_Choices()
        {
            //
            // Created 4/6/2020 td
            //
            bool bKeepLooping = true;
            bool bUserWantsToExit = false;

            // Establish an event handler to process key press events.
            //  https://docs.microsoft.com/en-us/dotnet/api/system.console.cancelkeypress?view=netframework-4.8
            //
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);

            do
            {
                Console.WriteLine("..........");
                Console.WriteLine("Enter 3 for 32-bit processing, 6 for 64-bit integers, H for huge numbers..........");
                Console.WriteLine("..........");
                var next_key = Console.ReadKey(true);

                switch (next_key.KeyChar)
                {
                    case ('3'): FibonacciViaDP.Fibonacci_Via32bit(ref bUserWantsToExit); break;
                    case ('6'): FibonacciViaDP.Fibonacci_Via64bit(ref bUserWantsToExit); break;
                    case ('H'): FibonacciViaDP.Fib_HugeNumbers(ref bUserWantsToExit); break;
                    case ('h'): FibonacciViaDP.Fib_HugeNumbers(ref bUserWantsToExit); break;
                }

                bKeepLooping = (false == bUserWantsToExit);

            } while (bKeepLooping);

        }

        public static void Fibonacci_Via32bit(ref bool pref_bUserTypesExit)
        {
            //
            // Created 4/6/2020 td
            //
            Console.WriteLine("............");
            Console.WriteLine("............");
            Console.WriteLine("Let's visit the Fibonacci Sequence, using 32-bit integers.");
            Console.WriteLine("............");
            Console.WriteLine("..........");
            Console.WriteLine("CTRL+C (or CTRL-BREAK) to interrupt the operation.");
            Console.WriteLine("..........");
            Console.WriteLine("..........");

            int intFibonacciN_minus1 = 0;
            int intFibonacciN_minus2 = 1;
            int intFinonacciN_latest;
            //int intTempStore;
            string strExitCode = "";
            int indexOfIteration = 0; 

            do {
                //
                // Count Fibonacci
                //
                intFibonacciN_minus1 = 0;
                intFibonacciN_minus2 = 1;

                try
                {
                    while (true)
                    {
                        indexOfIteration++;
                        intFinonacciN_latest = (intFibonacciN_minus1 + intFibonacciN_minus2);

                        if (intFinonacciN_latest < 0)
                        {
                            //System.Diagnostics.Debugger.Break();
                            throw new OverflowException("The number has reached the 32-bit (Int32) limit.");
                        }
                        else
                        {
                            Console.WriteLine(indexOfIteration.ToString() + ". " +
                                String.Format("{0:#,##0}", intFinonacciN_latest));
                        }

                        //Put a slight pause between numbers.  
                        System.Threading.Thread.Sleep(200);

                        //Console.WriteLine();
                        //Console.WriteLine();
                        //Console.WriteLine("Press the Enter key to re-run the first distance last.");
                        //Console.WriteLine("   (Enter EXIT to exit the loop.");
                        //strExitCode = Console.ReadLine();

                        //
                        //Prepare for next iteration.
                        //
                        intFibonacciN_minus2 = intFibonacciN_minus1;
                        intFibonacciN_minus1 = intFinonacciN_latest;

                    } //while (true);
                }
                catch (Exception ex_overflow)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("We have received the following overflow error.");
                    Console.WriteLine("   ");
                    Console.WriteLine(ex_overflow.Message);
                    Console.WriteLine();
                    Console.WriteLine("Please keep in mind, the limit of a 32-bit integer is: ");
                    Console.WriteLine("   ");
                    Console.WriteLine("MaxValue of Int32: " + Int32.MaxValue.ToString());

                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press the Enter key to re-run the Fibonacci Sequence.");
                Console.WriteLine("   (Enter EXIT to exit the loop.");
                strExitCode = Console.ReadLine();

            } while (false && strExitCode != "EXIT");

            //
            //Added 4/6/2020 thomas downes
            //
            pref_bUserTypesExit = (strExitCode == "EXIT");

        }


        public static void Fibonacci_Via64bit(ref bool pref_bUserTypesExit)
        {
            //
            // Created 4/6/2020 td
            //
            Console.WriteLine("............");
            Console.WriteLine("............");
            Console.WriteLine("Let's visit the Fibonacci Sequence, using 64-bit integers.");
            Console.WriteLine("............");
            Console.WriteLine("..........");
            Console.WriteLine("CTRL+C (or CTRL-BREAK) to interrupt the operation.");
            Console.WriteLine("..........");
            Console.WriteLine("..........");

            long longFibonacciN_minus1 = 0;
            long longFibonacciN_minus2 = 1;
            long longFinonacciN_latest;
            //int intTempStore;
            string strExitCode = "";
            int indexOfIteration = 0; 

            do
            {
                //
                // Count Fibonacci
                //
                longFibonacciN_minus1 = 0;
                longFibonacciN_minus2 = 1;

                try
                {
                    while (true)
                    {
                        indexOfIteration++;
                        longFinonacciN_latest = (longFibonacciN_minus1 + longFibonacciN_minus2);

                        if (longFinonacciN_latest < 0)
                        {
                            //System.Diagnostics.Debugger.Break();
                            throw new OverflowException("The number has reached the 64-bit (Int64) limit.");
                        }
                        else
                        {
                            //---Console.WriteLine(longFinonacciN_latest);
                            Console.WriteLine(indexOfIteration.ToString() + ". " +
                                String.Format("{0:#,##0}", longFinonacciN_latest));
                        }

                        System.Threading.Thread.Sleep(200);

                        //Console.WriteLine();
                        //Console.WriteLine();
                        //Console.WriteLine("Press the Enter key to re-run the first distance last.");
                        //Console.WriteLine("   (Enter EXIT to exit the loop.");
                        //strExitCode = Console.ReadLine();

                        //
                        //Prepare for next iteration.
                        //
                        longFibonacciN_minus2 = longFibonacciN_minus1;
                        longFibonacciN_minus1 = longFinonacciN_latest;

                    } //while (true);
                }
                catch (Exception ex_overflow)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("We have received the following overflow error.");
                    Console.WriteLine("   ");
                    Console.WriteLine(ex_overflow.Message);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Please keep in mind, the limit of a 64-bit integer is: ");
                    Console.WriteLine("   ");
                    Console.WriteLine("MaxValue of Int64: " + Int64.MaxValue.ToString());

                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press the Enter key to re-run the Fibonacci Sequence.");
                Console.WriteLine("   (Enter EXIT to exit the loop.");
                strExitCode = Console.ReadLine();

            } while (false);  // (strExitCode != "EXIT");

            //
            //Added 4/6/2020 thomas downes
            //
            pref_bUserTypesExit = (strExitCode == "EXIT");

        }


        public static void Fib_HugeNumbers(ref bool pref_bUserTypesExit)
        {
            //
            // Created 4/6/2020 td
            //
            bool bFormatToIncludeCommas = false; //Added 4/7/2020 thomas d.
            bool bIncludeMicrosecondPauses = true;  //Added 4/7/2020 thomas d. 
            bool bPressedYorN = false;
            bool bWorkToExcludeCommas;  

            Console.WriteLine("............");
            Console.WriteLine("............");
            Console.WriteLine("Let's visit the Fibonacci Sequence, using integers of any size.");
            Console.WriteLine("............");

            
            //
            // Formatting with commas ??
            //
            Console.WriteLine("Should we include commas to format the numbers? (Y/N)");
            Console.WriteLine("..........");

            do
            {
                var next_key = Console.ReadKey(false);
                switch (next_key.Key)
                {
                    case (ConsoleKey.Y): bFormatToIncludeCommas = true; bPressedYorN = true; break;
                    case (ConsoleKey.N): bFormatToIncludeCommas = false; bPressedYorN = true; break;
                }
            } while (false == bPressedYorN);  // (true);

            //
            // Include pausing ??
            //
            Console.WriteLine("Should we include microsecond pauses for readability? (Y/N)");
            Console.WriteLine("..........");

            do
            {
                var next_key = Console.ReadKey(false);
                switch (next_key.Key)
                {
                    case (ConsoleKey.Y): bIncludeMicrosecondPauses = true; bPressedYorN = true; break;
                    case (ConsoleKey.N): bIncludeMicrosecondPauses = false; bPressedYorN = true; break;
                }
            } while (false == bPressedYorN);  // (true);

            Console.WriteLine("..........");
            Console.WriteLine("CTRL+C (or CTRL-BREAK) to interrupt the operation.");

            Console.WriteLine("..........");
            Console.WriteLine("..........");

            string strFibonacciN_minus1 = "0";
            string strFibonacciN_minus2 = "1";
            string strFibonacciN_latest;
            string strExitCode = "";
            int indexOfIteration = 0;    // Added 4/7/2020 td
            string strGiveCountOfDigits = ""; // Added 4/7/2020 td
            int intCurrentDigitCount = 0;  // Added 4/7/2020 td
            bool boolNewDigitCount = false;  // Added 4/7/2020 td

            mod_bUserStoppedExecution = false; //Reinitialize this value. ---4

            do
            {
                //
                // Count Fibonacci
                //
                strFibonacciN_minus1 = "0";
                strFibonacciN_minus2 = "1";
                string strErrMessage = "";  

                try
                {
                    while (true)
                    {
                        if (mod_bUserStoppedExecution) break; //Added 4/7/2020 thomas downes
                        indexOfIteration++; 
                        //longFinonacciN_latest = (longFibonacciN_minus1 + longFibonacciN_minus2);
                        strFibonacciN_latest = AddingDecs.AddAnyTwoDecStrings(strFibonacciN_minus1, strFibonacciN_minus2, ref strErrMessage, bFormatToIncludeCommas);

                        if (strErrMessage != "")
                        {
                            throw new OverflowException("Error, like so: " + strErrMessage);
                        }
                        else
                        {
                            //Added 4/7/2020 td
                            strGiveCountOfDigits = "";  //Reinitialize. 
                            //boolNewDigitCount = (intCurrentDigitCount < strFibonacciN_latest.Length);  // Added 4/7/2020 td
                            bWorkToExcludeCommas = bFormatToIncludeCommas;
                            //Check to see if the newest Fibonacci number has
                            //  more digits than the previous. ----4/7/2020 td
                            int intTemporaryCount = CountDigitsOnly(strFibonacciN_latest, bWorkToExcludeCommas);
                            boolNewDigitCount = (intCurrentDigitCount < intTemporaryCount);  // Added 4/7/2020 td

                            if (boolNewDigitCount)
                            {
                                //intCurrentDigitCount = strFibonacciN_latest.Length;
                                //if (bIncludeCommas && strFibonacciN_latest.Contains(','))
                                //{
                                //    //intCurrentDigitCount = (int)(0.75 * (intCurrentDigitCount - (intCurrentDigitCount % 4))); //Ignore the commas.
                                //    int intDividedBy4 = (int)Math.Floor(intCurrentDigitCount / 4d);
                                //    int intModulo4 = (intCurrentDigitCount % 4);
                                //    intCurrentDigitCount = (int)(0.75 * (intCurrentDigitCount - intModulo4)); //Ignore the commas.
                                //}

                                bWorkToExcludeCommas = bFormatToIncludeCommas;
                                intCurrentDigitCount = intTemporaryCount; //CountDigitsOnly(strFibonacciN_latest, bWorkToExcludeCommas);

                                //Added 4/7/2020 td
                                strGiveCountOfDigits = "   <=== Digit-length of " + intCurrentDigitCount.ToString();
                            }

                            //-----Console.WriteLine(strFinonacciN_latest);
                            //-----Console.WriteLine(indexOfIteration.ToString() + ". " + strFinonacciN_latest);
                            Console.WriteLine(indexOfIteration.ToString() + ". " + strFibonacciN_latest + strGiveCountOfDigits);

                            //
                            //Added 4/7/2020 td
                            //
                            //---if (101 <= strFibonacciN_latest.Length) Console.WriteLine("*******************************************************");
                            if (101 <= intCurrentDigitCount)
                            {
                                Console.WriteLine("*************************************************************************");
                                Console.WriteLine("************************** Fibonacci(" + indexOfIteration + ") > googol = 10^100 **************");
                                Console.WriteLine("**************************************************************************");
                                break;  // Exit the looping. 
                            }

                        }

                        //System.Threading.Thread.Sleep(200);
                        //System.Threading.Thread.Sleep(1200);
                        if (bIncludeMicrosecondPauses)
                               System.Threading.Thread.Sleep(100);

                        //Console.WriteLine();
                        //Console.WriteLine();
                        //Console.WriteLine("Press the Enter key to re-run the first distance last.");
                        //Console.WriteLine("   (Enter EXIT to exit the loop.");
                        //strExitCode = Console.ReadLine();

                        //
                        //Prepare for next iteration.
                        //
                        strFibonacciN_minus2 = strFibonacciN_minus1;
                        strFibonacciN_minus1 = strFibonacciN_latest;

                    } //while (true);
                }
                catch (Exception ex_overflow)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("We have received the following overflow error.");
                    Console.WriteLine("   ");
                    Console.WriteLine(ex_overflow.Message);
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press the Enter key to re-run the Fibonacci Sequence.");
                Console.WriteLine("   (Enter EXIT to exit the loop.");
                strExitCode = Console.ReadLine();

            } while (false && strExitCode != "EXIT");

            //
            //Added 4/6/2020 thomas downes
            //
            pref_bUserTypesExit = (strExitCode == "EXIT");

        }


        private static int CountDigitsOnly(string pstrNumberWithCommas, bool pbUseMathToOmitCommaCount)
        {
            //
            //Created 4/7/2020 thomas d
            //
            //intCurrentDigitCount = (int)(0.75 * (intCurrentDigitCount - (intCurrentDigitCount % 4))); //Ignore the commas.
            int intDigitCount = pstrNumberWithCommas.Length;

            if (pbUseMathToOmitCommaCount && (intDigitCount > 3))
            {
                //int intDividedBy4 = (int)Math.Floor(intDigitCount / 4d);
                int intModulo4 = (intDigitCount % 4);
                //----intDigitCount = (int)(0.75 * (intDigitCount - intModulo4)) + intModulo4;
                int intDivide4 = (intDigitCount / 4); // ? 15 / 4 = 3   (we don't have to worry about rounding up)
                intDigitCount = (3 * intDivide4 + intModulo4);  //Multiply the triplets by 3 and add the modulo value. 
                return intDigitCount;
            }
            else return intDigitCount;
        }


        //public static void PascalsTriangle_SubsetEnumeration()
        //{ 
        //    //
        //    // Stubbed 4/6/2020 td
        //    //



        //}

        //public static void RobotMoves_CountPaths()
        //{
        //    //
        //    // Stubbed 4/6/2020 td
        //    //



        //}

        static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            //
            //  https://docs.microsoft.com/en-us/dotnet/api/system.console.cancelkeypress?view=netframework-4.8
            //
            mod_bUserStoppedExecution = true;
            args.Cancel = true;  //Suppress the default behavior caused by CTRL-C.  
        }
 
    }
 }
