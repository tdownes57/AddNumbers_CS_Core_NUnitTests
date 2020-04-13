using System;
using System.Collections.Generic;
using System.Text;

namespace AddHugeNumbersNetCore
{
    public class IncrementAnyNumber
    {
        public static string IncrementAnyString(string pstrInputNumber, ref string pref_sErrorMessage, bool pbFormatCommas)
        {
            //
            //Added 4/9/2020 thomas downes
            //
            //  Let's make this very fast. 
            //
            char charCurrDigit = ' ';
            //pstrInputNumber = pstrInputNumber.Trim();

            if (pstrInputNumber == null) throw new ArgumentException("Please don't give me Null values.");

            //
            //https://stackoverflow.com/questions/8987141/how-to-change-1-char-in-the-string
            //
            //-----var stringBuild = new System.Text.StringBuilder(1 + pstrInputNumber.Length);
            var stringBuild = new System.Text.StringBuilder(pstrInputNumber.Trim());
            string sErrorMessage = "";
            char charIncremented = ' ';
            bool bCarryTheOne_NextOperation = false;
            int intIndexOfBiggestComma = -1;
            bool bCarryTheOne_CurrentOperation = false;  // Added 4/13/2020 td 
            bool bSubsequentIteration = false; // Added 4/13/2020 td 
            bool bInvalidIteration = false;  // Added 4/13/2020 td

            //
            // Process the right-most digit, and if a "9" becomes "0" then we continue
            //   the looping (so that the next-more-significant digit is incremented as
            //   well).   If the number is "9999" then we will have to loop 4 times.
            //     ---4/13/2020 Thomas Downes
            //
            for (int intCharIndex = -1 + pstrInputNumber.Length; intCharIndex >= 0; intCharIndex--)
            {
                //Added 4/13/2020 thomas d. 
                bInvalidIteration = (bSubsequentIteration && (false == bCarryTheOne_CurrentOperation));
                if (bInvalidIteration) throw new Exception("Invalid iteration.");

                charCurrDigit = stringBuild[intCharIndex];
                bCarryTheOne_NextOperation = false;  //Reinitialize.  

                charIncremented = IncrementDigit(charCurrDigit, ref bCarryTheOne_NextOperation, ref sErrorMessage);

                stringBuild[intCharIndex] = charIncremented;

                if (pbFormatCommas && charCurrDigit == ',') intIndexOfBiggestComma = intCharIndex;

                if (false == bCarryTheOne_NextOperation) break;

                //Prepare for next iteration.  (This is for programmer comprehension.)
                bSubsequentIteration = true;  
                bCarryTheOne_CurrentOperation = bCarryTheOne_NextOperation;

            }

            //
            // If we are incrementing a sequence of 9's (e.g. 99 or 999) then we need to put 
            //     a single digit of 1 right in front of all the 0s (e.g. 00 or 000). 
            //
            if (bCarryTheOne_NextOperation)
            {
                // Insert a comma, if needed. 
                if (intIndexOfBiggestComma == 3) stringBuild.Insert(0, ',');
                if ("999" == stringBuild.ToString()) stringBuild.Insert(0, ',');
                stringBuild.Insert(0, '1');
            }

            return stringBuild.ToString();

        }

        public static char IncrementDigit(char pstrDecDigit1, ref bool pref_bCarryTheOne,
            ref string pref_sErrorMessage)
        {
            //
            //Added 4/9/2020 thomas downes
            //
            //  Let's make this very fast. 
            //
            if (pstrDecDigit1 == ' ') return ' ';
            if (pstrDecDigit1 == '0') return '1';
            if (pstrDecDigit1 == '1') return '2';
            if (pstrDecDigit1 == '2') return '3';
            if (pstrDecDigit1 == '3') return '4';
            if (pstrDecDigit1 == '4') return '5';
            if (pstrDecDigit1 == '5') return '6';
            if (pstrDecDigit1 == '6') return '7';
            if (pstrDecDigit1 == '7') return '8';
            if (pstrDecDigit1 == '8') return '9';
            if (pstrDecDigit1 == '9')
            {
                pref_bCarryTheOne = true;
                return '0';
            }
            if (pstrDecDigit1 == ',')
            {
                pref_bCarryTheOne = true; // We will increment the next decimal position. 
                return ',';
            }

            throw new ArgumentException("The character is not recognized. ");

        }

    }
}
