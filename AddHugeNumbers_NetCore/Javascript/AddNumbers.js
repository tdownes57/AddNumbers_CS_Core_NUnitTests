
/*

    Added 1/31/2019 Thomas Downes
 
*/


//class DigitAndCarry:
//digit = "0"
//bCarry = false
//bErrorOccurred_any = false
//bErrorOccurred_ByArrays1 = false
//bErrorOccurred_ByArrays2 = false
//bErrorOccurred_AddOne = false
//bErrorOccurred_AddZero = false

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

function AddDecDigits_AnyLengths(pstrDecimalString1, pstrDecimalString2)
{
    if (len(pstrDecimalString1) > len(pstrDecimalString2))
        pstrDecimalString2 = PadLeftToLength(pstrDecimalString2, len(pstrDecimalString1));
    if (len(pstrDecimalString2) > len(pstrDecimalString1))
        pstrDecimalString1 = PadLeftToLength(pstrDecimalString1, len(pstrDecimalString2));
    strOutputValue = "";
    strOutputValue = AddDecDigits_PaddedDecimals(pstrDecimalString1, pstrDecimalString2);
    return strOutputValue;
}

function AddDecDigits_PaddedDecimals(pstrPaddedDecimal1, pstrPaddedDecimal2) {
    strOutputValue = "";
    bCarryTheTen_Curr = false;
    bCarryTheTen_Next = false;
    digit_carry = DigitAndCarry();
    strCurrentDigit1 = "";
    strCurrentDigit2 = "";
    intNegativeIndex = 0;
    intCharIndex = 0;

    for x in range(0, len(pstrPaddedDecimal1))
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
    if (digit_carry.bCarry)
        strOutputValue = "1" + strOutputValue;
    return strOutputValue
}

function AddDecDigits_ByArrays(pstrDecDigit1, pstrDecDigit2, pbCarry1_ForPriorOperation)
{
    decDigits_blank0to9 = [" ", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]
    output_value = DigitAndCarry()
    if (pstrDecDigit1 not in decDigits_blank0to9):
    output_value.bErrorOccurred_any = True
    output_value.bErrorOccurred_ByArrays1 = True #Indicate an error.
    return output_value #Indicate an error.
        if(pstrDecDigit2 not in decDigits_blank0to9):
    output_value.bErrorOccurred_any = True
    output_value.bErrorOccurred_ByArrays2 = True #Indicate an error.
    return output_value #Indicate an error.
    #Moved up. 1 / 30 / 2020 td#output_value = DigitAndCarry()
    if (pbCarry1_ForPriorOperation):
    #Add 1 for prior operation.
        if pstrDecDigit1 == " ":
            return Add_One(pstrDecDigit2) #Add 1 for prior operation.
        if pstrDecDigit2 == " ":
            return Add_One(pstrDecDigit1) #Add 1 for prior operation.
        if pstrDecDigit1 == "0":
            return Add_One(pstrDecDigit2) #Add 1 for prior operation.
        if pstrDecDigit2 == "0":
            return Add_One(pstrDecDigit1) #Add 1 for prior operation.
    //#if pstrDecDigit1 == "1" and pstrDecDigit2 == "0":
    //#    return AddOne("1") #Add 1 for prior operation.
        else:
    //#Add zero(i.e.No prior operation need be addressed).
    if pstrDecDigit1 == " ":
    //#Add zero(i.e.No prior operation need be addressed).
    return AddZero(pstrDecDigit2)
    if pstrDecDigit2 == " ":
    //#Add zero(i.e.No prior operation need be addressed).
    return AddZero(pstrDecDigit1)
    if pstrDecDigit1 == "0":
    //#Add zero(i.e.No prior operation need be addressed).
    return AddZero(pstrDecDigit2)
    if pstrDecDigit2 == "0":
    //#Add zero(i.e.No prior operation need be addressed).
    return AddZero(pstrDecDigit1)
    //#if (pstrDecDigit1 == "1" and pstrDecDigit2 == "0"):
    //#    #Add zero(i.e.No prior operation need be addressed).
    //#    return AddZero("1")
    //#if pstrDecDigit1 == "1" and pstrDecDigit2 == "1":
    //#    return "2"
    //#if pstrDecDigit1 == "1" and pstrDecDigit2 == "2":
    //#    return "3"
    //#if pstrDecDigit1 == "1" and pstrDecDigit2 == "3":
    //#    return "4"
    flag_bCarry = false
    decDigits_1to9 = ["1", "2", "3", "4", "5", "6", "7", "8", "9"]
    decDigits___0to9 = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]
    xFinalIndex = 0
    boolDigit1Found = false
    x = 0
    for d1 in decDigits_1to9:
        x = x + 1 #This is the final index, a value from 0 through 9.
    if (d1 == pstrDecDigit1):
        for d2 in decDigits_1to9:
            x = x + 1
    if (x > 9):
        output_value.bCarry = True
    flag_bCarry = True #Store the Carry - Ten boolean flag.
        x = 0
    if (d2 == pstrDecDigit2):
        output_value.digit = decDigits___0to9[x]
    if (pbCarry1_ForPriorOperation):
    // #
    // # Add one to carry the 1 from a prior operation!!
    // #   (Without losing the boolean value in member.bCarry.)
    // #
    output_value = Add_One(output_value.digit)
    output_value.bCarry = (flag_bCarry | output_value.bCarry)
    return output_value
}

function AddZero(pstrDecDigit) {
    output_value = DigitAndCarry()
    decDigits_1to9 = ["1", "2", "3", "4", "5", "6", "7", "8", "9"]
    decDigits___0to9 = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]
    if (pstrDecDigit not in decDigits___0to9):
    output_value.bErrorOccurred_any = True
    output_value.bErrorOccurred_AddZero = True // #Indicate an error.
    return output_value // #Indicate an error.
        x = -1 // #Start below zero.
    #for d1 in decDigits_1to9:
        for d1 in decDigits___0to9:
            x = x + 1 // #This is the final index, a value from 0 through 9.
    if (d1 == pstrDecDigit):
        output_value.digit = decDigits___0to9[x]
    return output_value
}

function Add_One(pstrDecDigit) {
    output_value = DigitAndCarry()
    decDigits_1to9 = ["1", "2", "3", "4", "5", "6", "7", "8", "9"]
    decDigits___0to9 = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]
    if (pstrDecDigit not in decDigits___0to9):
    output_value.bEbErrorOccurred_any = True
    output_value.bErrorOccurred_AddOne = True #Indicate an error.
    return output_value // #Indicate an error.
        x = -1 // #Start below zero.This is the final index, a value from 0 through 9.
    flag_carry = false
    #for d1 in decDigits_1to9:
        for d1 in decDigits___0to9:
            x = x + 1 //#Increment, due to interation of loop.
                if(d1 == pstrDecDigit):
    if (x == 9):
        flag_carry = True
    x = -1 // # Value is - 1 since we will add 1(" + 1") below.
        output_value.digit = decDigits___0to9[x + 1] //# We add + 1 here, because we
    // # ....need to select the "next" item in the list(since the name of the
    // # current function is "Add_One"(vs. "AddZero").
    output_value.bCarry = flag_carry
    return output_value
}

//def PadLeftToLength(pstrDecimalString, pintLength):
function PadLeftToLength(pstrDecimalString, pintLength)
{
    for x in range((len(pstrDecimalString) + 1), (pintLength + 1)):
    #The range ends in an "exclusive" endpoint, i.e. (pintLength) will
    #  be the last included value, __NOT___(pintLength + 1).
        pstrDecimalString = (" " + pstrDecimalString)
    return pstrDecimalString
}


print("The numbers 1234 + 1234 are equal to " + AddDecDigits_AnyLengths("1234", "1234"))
print("The numbers  234 + 1234 are equal to " + AddDecDigits_AnyLengths("234", "1234"))
print("The numbers  500 +  500 are equal to " + AddDecDigits_AnyLengths("500", "500"))
print("The numbers  999 +  1 are equal to " + AddDecDigits_AnyLengths("999", "1"))








