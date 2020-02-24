'use strict';

console.log('Hello world');

//
//  https://stackoverflow.com/questions/7942398/nested-objects-in-javascript-best-practices
//
var DigitAndCarry = {
    //
    // Added 2/1/2020 
    //
    digit = "0",
    bCarry = false,
    bErrorOccurred_any = false,
    bErrorOccurred_ByArrays1 = false,
    bErrorOccurred_ByArrays2 = false,
    bErrorOccurred_AddOne = false,
    bErrorOccurred_AddZero = false

};

function AddDecDigits_AnyLengths(pstrDecimalString1, pstrDecimalString2) {
    //
    //Called by the following:
    //    [the user's behavior within the user interface]
    //
    if (pstrDecimalString1.length > pstrDecimalString2.length)
        pstrDecimalString2 = PadLeftToLength(pstrDecimalString2, len(pstrDecimalString1));

    if (pstrDecimalString2.length > pstrDecimalString1.length)
        pstrDecimalString1 = PadLeftToLength(pstrDecimalString1, len(pstrDecimalString2));

    strOutputValue = "";
    strOutputValue = AddDecDigits_PaddedDecimals(pstrDecimalString1, pstrDecimalString2);
    return strOutputValue;
}

function AddDecDigits_PaddedDecimals(pstrPaddedDecimal1, pstrPaddedDecimal2) {
    //
    //Called by the following:
    //    function AddDecDigits_AnyLengths(pstrDecimalString1, pstrDecimalString2) 
    //
    strOutputValue = "";
    bCarryTheTen_Curr = false;
    bCarryTheTen_Next = false;
    digit_carry = DigitAndCarry();
    strCurrentDigit1 = "";
    strCurrentDigit2 = "";
    intNegativeIndex = 0;
    intCharIndex = 0;

    //for x in range(0, len(pstrPaddedDecimal1))
    for (const x = 0; x <= pstrPaddedDecimal1.length; x++)
    {
        bCarryTheTen_Curr = bCarryTheTen_Next
        //#Major call!!
        //#  We multiply the character index by - 1 in order to go from right - hand - side "4" of "1234" to the left - hand "1".
        // ###digit_carry = AddDecDigits_ByArrays(pstrPaddedDecimal1[-1 * x], pstrPaddedDecimal2[-1 * x], bCarryTheTen_Curr)
        // #intNegativeIndex = (x * -1)
        // #strCurrentDigit1 = pstrPaddedDecimal1[intNegativeIndex : intNegativeIndex + 1]
        // #strCurrentDigit2 = pstrPaddedDecimal2[-1 * x : -1 * x + 1]
        intCharIndex = (-1 + len(pstrPaddedDecimal1) - x);
        strCurrentDigit1 = pstrPaddedDecimal1[intCharIndex];
        strCurrentDigit2 = pstrPaddedDecimal2[intCharIndex];
        digit_carry = AddDecDigits_ByArrays(strCurrentDigit1, strCurrentDigit2, bCarryTheTen_Curr);
        if (digit_carry.bErrorOccurred_any)
            return "Error occurred!!";
        bCarryTheTen_Next = digit_carry.bCarry;
        strOutputValue = (digit_carry.digit + strOutputValue);
    }

    //
    //Prepare to exit the function.
    //
    if (digit_carry.bCarry)
        strOutputValue = "1" + strOutputValue;
    return strOutputValue;
}

function AddDecDigits_ByArrays(pstrDecDigit1, pstrDecDigit2, pbCarry1_ForPriorOperation) {
    //
    //Called by the following:
    //    function AddDecDigits_PaddedDecimals(pstrDecimalString1, pstrDecimalString2) 
    //
    decDigits_blank0to9 = [" ", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
    output_value = new DigitAndCarry();

    //if (pstrDecDigit1 not in decDigits_blank0to9)
    let boolNotFound1 = (-1 == decDigits_blank0to9.indexOf(pstrDecDigit1));
    if (boolNotFound1) 
    {
        output_value.bErrorOccurred_any = true;
        output_value.bErrorOccurred_ByArrays1 = true; //#Indicate an error.
        return output_value //#Indicate an error.
    }

    //if (pstrDecDigit2 not in decDigits_blank0to9):
    let boolNotFound2 = (-1 == decDigits_blank0to9.indexOf(pstrDecDigit2));
    if (boolNotFound2) 
    {
        output_value.bErrorOccurred_any = True
        output_value.bErrorOccurred_ByArrays2 = True //#Indicate an error.
        return output_value //#Indicate an error.
    }
        //#Moved up. ---1/30/2020 td#output_value = DigitAndCarry()
    if (pbCarry1_ForPriorOperation)
    {
        //#Add 1 for prior operation.
        if (pstrDecDigit1 == " ")
            return Add_One(pstrDecDigit2); //#Add 1 for prior operation.
        if (pstrDecDigit2 == " ")
            return Add_One(pstrDecDigit1); //#Add 1 for prior operation.
        if (pstrDecDigit1 == "0")
            return Add_One(pstrDecDigit2); //#Add 1 for prior operation.
        if (pstrDecDigit2 == "0")
            return Add_One(pstrDecDigit1); //#Add 1 for prior operation.
        //#if pstrDecDigit1 == "1" and pstrDecDigit2 == "0":
        //#    return AddOne("1") #Add 1 for prior operation.
    }
    else
    {
        //#Add zero(i.e.No prior operation need be addressed).
        if (pstrDecDigit1 == " ")
            //#Add zero(i.e.No prior operation need be addressed).
            return AddZero(pstrDecDigit2);
        if (pstrDecDigit2 == " ")
            //#Add zero(i.e.No prior operation need be addressed).
            return AddZero(pstrDecDigit1);
        if (pstrDecDigit1 == "0")
            //#Add zero(i.e.No prior operation need be addressed).
            return AddZero(pstrDecDigit2);
        if (pstrDecDigit2 == "0")
            //#Add zero(i.e.No prior operation need be addressed).
            return AddZero(pstrDecDigit1);
    }
    //#if (pstrDecDigit1 == "1" and pstrDecDigit2 == "0"):
    //#    #Add zero(i.e.No prior operation need be addressed).
    //#    return AddZero("1")
    //#if pstrDecDigit1 == "1" and pstrDecDigit2 == "1":
    //#    return "2"
    //#if pstrDecDigit1 == "1" and pstrDecDigit2 == "2":
    //#    return "3"
    //#if pstrDecDigit1 == "1" and pstrDecDigit2 == "3":
    //#    return "4"
    flag_bCarry = false;
    decDigits_1to9 = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
    decDigits___0to9 = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
    xFinalIndex = 0;
    boolDigit1Found = false;
    x = 0;
    for (d1 of decDigits_1to9) {
        x = x + 1 //#This is the final index, a value from 0 through 9.
        if (d1 == pstrDecDigit1) {
            for (d2 of decDigits_1to9) {
                x = x + 1
                if (x > 9) {
                    output_value.bCarry = true
                    flag_bCarry = true; //#Store the Carry - Ten boolean flag.
                    x = 0;
                }
                if (d2 == pstrDecDigit2) {
                    output_value.digit = decDigits___0to9[x]
                    if (pbCarry1_ForPriorOperation) {
                        // #
                        // # Add one to carry the 1 from a prior operation!!
                        // #   (Without losing the boolean value in member.bCarry.)
                        // #
                        output_value = Add_One(output_value.digit)
                        output_value.bCarry = (flag_bCarry | output_value.bCarry)
                        return output_value
                    }
                }
            }
        }
    }
}

function AddZero(pstrDecDigit) {
    //
    //Increment the digit. 
    //
    output_value = DigitAndCarry();
    decDigits_1to9 = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
    decDigits___0to9 = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    //if (pstrDecDigit not in decDigits___0to9):
    let boolNotFound = (-1 == decDigits___0to9.indexOf(pstrDecDigit));
    if (boolNotFound) {
        output_value.bErrorOccurred_any = true;
        output_value.bErrorOccurred_AddZero = true;  // #Indicate an error.
        return output_value // #Indicate an error.
    }

    let x_digitIndex = -1; // #Start below zero.
    //#for d1 in decDigits_1to9:
    for (d1 of decDigits___0to9)
    {
        x_digitIndex = x_digitIndex + 1;  // #This is the final index, a value from 0 through 9.
        if (d1 == pstrDecDigit) {
            output_value.digit = decDigits___0to9[x_digitIndex];
            return output_value;
        }
    }
}

function Add_One(pstrDecDigit) {
    //
    //Increment the digit. 
    //
    output_value = new DigitAndCarry();
    decDigits_1to9 = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
    decDigits___0to9 = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    //if (pstrDecDigit not in decDigits___0to9)
    let boolNotFound = (-1 == decDigits___0to9.indexOf(pstrDecDigit));
    if (boolNotFound)
    {
        output_value.bEbErrorOccurred_any = true;
        output_value.bErrorOccurred_AddOne = true;  //#Indicate an error.
        return output_value;  // #Indicate an error.
    }

    x = -1;  // #Start below zero.This is the final index, a value from 0 through 9.
    flag_carry = false;

    //#for d1 in decDigits_1to9:
    for (d1 of decDigits___0to9)
    {
        x = x + 1; //#Increment, due to interation of loop.

        if (d1 == pstrDecDigit) {
            if (x == 9) {
                flag_carry = true;
                x = -1 // # Value is - 1 since we will add 1(" + 1") below.
            }
            output_value.digit = decDigits___0to9[x + 1] //# We add + 1 here, because we
            // # ....need to select the "next" item in the list(since the name of the
            // # current function is "Add_One"(vs. "AddZero").
            output_value.bCarry = flag_carry
            return output_value
        }
    }

}

//def PadLeftToLength(pstrDecimalString, pintLength):
function PadLeftToLength(pstrDecimalString, pintLength) {
    //
    // Pad the input string with blank space characters (on the left side of the input number).
    //
    let strPadding = "";
    //for x in range((len(pstrDecimalString) + 1), (pintLength + 1))
    for (const x = (len(pstrDecimalString)); x <= (pintLength + 1); x++)
    {
        //#The range ends in an "exclusive" endpoint, i.e. (pintLength) will
        //#  be the last included value, __NOT___(pintLength + 1).
        //pstrDecimalString = (" " + pstrDecimalString);
        strPadding = (" " + strPadding);
    }
    //Add the padding. 
    pstrDecimalString = (strPadding + pstrDecimalString);
    return pstrDecimalString;
}

function main() {
    console.log("The numbers 1234 + 1234 are equal to " + AddDecDigits_AnyLengths("1234", "1234"));
    console.log("The numbers  234 + 1234 are equal to " + AddDecDigits_AnyLengths("234", "1234"));
    console.log("The numbers  500 +  500 are equal to " + AddDecDigits_AnyLengths("500", "500"));
    console.log("The numbers  999 +  1 are equal to " + AddDecDigits_AnyLengths("999", "1"));
    //console.
}










