using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
//
//Added 1/7/2019 thomas downes
//

// 2-13-2020 td // namespace AddSubtractHugeNumbersCS
// 2-24-2020 td // namespace AddingHugeNumbersCS 
namespace AddHugeNumbersNetCore
{
    //
    //Added 1/7/2019 thomas downes
    //
    public static class AddingDecimalStrings
    {
        //
        //Added 1/7/2019 thomas downes
        //
        //   Renamed "AddingDecs_Strings" on 9/11/2020.   
        //

        public static string AddAnyTwoDecStrings(string pstrDec1, string pstrDec2, 
                                  ref string pstrErrMessage, bool pbFormatIncludeCommas = false)
        {

            //    Public Function AddAnyTwoDecStrings(pstrDec1 As String, pstrDec2 As String,
            //                         pstrErrMessage As String) As String
            //    ''
            //    ''
            //    ''
            //    Dim strDec1_Padded As String
            //    Dim strDec2_Padded As String
            //    Dim intMaxLengthOfDec As Integer
            //    Dim intLength1 As Integer
            //    Dim intLength2 As Integer

            string strDec1_Padded = "";
            string strDec2_Padded = "";
            
            int intMaxLengthOfDec = 0;
            int intLength1 = 0;
            int intLength2 = 0;

            string strOutput = "";

            //    intLength1 = Len(Trim(pstrDec1))
            //    intLength2 = Len(Trim(pstrDec2))

            if (pstrDec1 == null) pstrErrMessage = "Parameter pstrDec1 is a null string.";
            if (pstrDec2 == null) pstrErrMessage = "Parameter pstrDec2 is a null string.";

            if (pstrDec1 == null) return "Parameter pstrDec1 is a null string.";
            if (pstrDec2 == null) return "Parameter pstrDec2 is a null string.";

            intLength1 = pstrDec1.Trim().Length;
            intLength2 = pstrDec2.Trim().Length;

            //    intMaxLengthOfDec = CType(IIf(intLength1 >= intLength2, intLength1, intLength2), Integer)

            intMaxLengthOfDec = (int)(intLength1 >= intLength2 ? intLength1 : intLength2);

            //    strDec1_Padded = PadLeft(Trim(pstrDec1), intMaxLengthOfDec)
            //    strDec2_Padded = PadLeft(Trim(pstrDec2), intMaxLengthOfDec)

            strDec1_Padded = PadLeft(pstrDec1.Trim(), intMaxLengthOfDec);
            strDec2_Padded = PadLeft(pstrDec2.Trim(), intMaxLengthOfDec);

            //    AddAnyTwoDecStrings = AddPaddedDecStrings(strDec1_Padded, strDec2_Padded,
            //                                          pstrErrMessage)

            // 4-7-2020 td //strOutput = AddPaddedDecStrings(strDec1_Padded, strDec2_Padded, ref pstrErrMessage);
            strOutput = AddPaddedDecStrings(strDec1_Padded, strDec2_Padded, ref pstrErrMessage, pbFormatIncludeCommas);

            //    ''Don't return any value if there's an error message.
            //    If(pstrErrMessage<> "") Then AddAnyTwoDecStrings = ""

            if (pstrErrMessage != "") return "";

            return strOutput;

            //End Function ''End of "Public Function AddAnyTwoDecStrings(pstrDec1 As String, pstrDec2 As String, ......"

        }

        private static string PadLeft(string paramString, int param_Length)
        {
            //Private Function PadLeft(paramString As String, param_Length As Integer) As String

            //Dim intLenOfInput As Integer
            int intLenOfInput = 0;
            string strOutput = "";

            //paramString = Trim(paramString)
            //intLenOfInput = Len(Trim(paramString))

            paramString = paramString.Trim();
            intLenOfInput = paramString.Length;

            //If(intLenOfInput < param_Length) Then
            if (intLenOfInput < param_Length)
            {
                //   PadLeft = Strings.Space(param_Length - intLenOfInput) & paramString
                strOutput = Strings.Space(param_Length - intLenOfInput) + paramString;
            }
            else
            {
                //Else

                //    PadLeft = paramString
                strOutput = paramString;  

                //End If ''End of "If (intLenOfInput < param_Length) Then ... Else ..."
            }

            //return paramString;
            return strOutput;

            //End Function ''End of "Private Function PadLeft(paramString As String, param_Length As Integer) As String"

         }

        public static string AddDecDigits_PaddedStrings(string pstrDecimalString1, string pstrDecimalString2, 
                                  ref string pstrErrMessage, bool pbFormatIncludeCommas = false)
        {
            //
            //New public member, for unit-testing.  ----2/26/2020 thomas downes
            //
            if (pstrDecimalString1 == null) throw new ArgumentException("No nulls allowed!!");
            if (pstrDecimalString2 == null) throw new ArgumentException("No nulls allowed!!");

            // 4/7/2020 td //return AddPaddedDecStrings(pstrDecimalString1, pstrDecimalString2, ref pstrErrMessage);
            return AddPaddedDecStrings(pstrDecimalString1, pstrDecimalString2, ref pstrErrMessage, pbFormatIncludeCommas);

        }

        private static string AddPaddedDecStrings(string pstrDecimalNum1, string pstrDecimalNum2, 
                                      ref string pstrErrMessage, bool pbFormatToIncludeCommas = false)
        {
            // private static string AddPaddedDecStrings(string pstrDec1, string pstrDec2, ref string pstrErrMessage)
            //
            //        Private Function AddPaddedDecStrings(pstrDec1 As String, pstrDec2 As String,
            //                              ByRef pstrErrMessage As String) As String

            //    Dim intCharIndex As Integer
            //    Dim strConcatenated As String = ""
            //    Dim boolUnequalLengths As Boolean
            //    Dim strNewDigit As String = ""
            //    '--'Dim boolCarryTheOne As String
            //    Dim strDecDigit1 As String
            //    Dim strDecDigit2 As String
            //    Dim boolCarryTheOne_Curr As Boolean
            //    Dim boolCarryTheOne_Next As Boolean
            //    Dim boolIsALeadingZero As Boolean ''Added 7/11/2016 Thomas Downes

            int intCharIndex = 0;
            // 4-7-2020 td//string strConcatenated = "";
            var strConcatenated = new System.Text.StringBuilder(1 + pstrDecimalNum1.Length);
            bool boolUnequalLengths = false;
            string strNewDigit = "";
            string strDecDigit1 = "";
            string strDecDigit2 = "";
            bool boolCarryTheOne_Curr = false;
            bool boolCarryTheOne_Next = false;
            bool boolIsALeadingZero = false; //Added 7/11/2016 thomas downes
            string strMostSignificantTriplet = ""; //Reinitialize.  
            bool bInsertNewComma = false; // Added 4/7/2020 td

            //    boolUnequalLengths = (Len(pstrDec1) <> Len(pstrDec2))

            boolUnequalLengths = (pstrDecimalNum1.Length != pstrDecimalNum2.Length);

            //    If(boolUnequalLengths) Then
            //       pstrErrMessage = "Dec strings are unequal in length."
            //        Exit Function
            //    End If

            if (boolUnequalLengths)
            {
                pstrErrMessage = "Dec strings are unequal in length.";
                return "";
            }

            //    For intCharIndex = Len(pstrDec1) To 1 Step -1
            for (intCharIndex = pstrDecimalNum1.Length; intCharIndex >= 1; intCharIndex--)
            {
                //strDecDigit1 = Mid$(pstrDec1, intCharIndex, 1)
                //strDecDigit2 = Mid$(pstrDec2, intCharIndex, 1)

                strDecDigit1 = pstrDecimalNum1.Substring(-1 + intCharIndex, 1);
                strDecDigit2 = pstrDecimalNum2.Substring(-1 + intCharIndex, 1);

                //strNewDigit = AddDecDigits_ThenAddOneIfRequested(strDecDigit1,
                //                                      strDecDigit2,
                //                                      boolCarryTheOne_Curr,
                //                                      boolCarryTheOne_Next,
                //                                      pstrErrMessage)

                //
                //Added 4/7/2020 thomas downes
                //
                //if (strDecDigit1 == "6" && strDecDigit2 == "3") System.Diagnostics.Debugger.Break();
                //if (strDecDigit1 == "3" && strDecDigit2 == "6") System.Diagnostics.Debugger.Break();

                strNewDigit = AddDecDigits_ThenAddOneIfRequested(strDecDigit1, 
                                                                 strDecDigit2, 
                                                                 boolCarryTheOne_Curr,
                                                                ref boolCarryTheOne_Next,
                                                                ref pstrErrMessage,
                                                                pbFormatToIncludeCommas);

                //If(pstrErrMessage<> "") Then Exit Function

                if (pstrErrMessage != "") return "";

                //strConcatenated = (strNewDigit & strConcatenated)

                // 4-7-2020 td//strConcatenated = (strNewDigit + strConcatenated);
                // 4-7-2020 td//strConcatenated.Append(strNewDigit);

                //
                //Format with commas, if needed.  ----Added 4/7/2020 thomas downes
                //
                if (pbFormatToIncludeCommas && bInsertNewComma) 
                {
                    // 4/7/2020 td //strConcatenated.Insert(0, ',');
                    if (strNewDigit != ",") strConcatenated.Insert(0, ',');
                    bInsertNewComma = false;  //Reinitialize.
                    strMostSignificantTriplet = ""; //Reinitialize.
                }

                //
                //Prepend the new digit, via insertion (so the new digit is in 
                //   the most significant decimal position).
                //      ----Added 4/6/2020 thomas downes
                //
                strConcatenated.Insert(0, strNewDigit);

                //
                //Format with commas, at the correct time.  ----Added 4/6/2020 thomas downes
                //
                string strDummy = pstrDecimalNum1; 
                if (pbFormatToIncludeCommas)
                {
                    if (strNewDigit == ",") strMostSignificantTriplet = ""; //Reinitialize. 
                    //---if (3 == strMostSignificantTriplet.Length) strConcatenated.Append(",");
                    else if (3 == strMostSignificantTriplet.Length) bInsertNewComma = true;
                    else if (3 > strMostSignificantTriplet.Length)
                    {
                        strMostSignificantTriplet = (strNewDigit + strMostSignificantTriplet);
                        //Added 4/7/2020 thomas downes
                        if (3 == strMostSignificantTriplet.Length) bInsertNewComma = true;
                    }
                }

                //''Prepare for next iteration.
                //----boolCarryTheOne_Curr = boolCarryTheOne_Next
                //----boolCarryTheOne_Next = False ''Reinitialize.

                //Testing for a bug. ---4/7/2020 td
                if (intCharIndex == 1)
                {
                    //if (strDecDigit1 == "6" && strDecDigit2 == "3") System.Diagnostics.Debugger.Break();
                    //if (strDecDigit1 == "3" && strDecDigit2 == "6") System.Diagnostics.Debugger.Break();
                }

                boolCarryTheOne_Curr = boolCarryTheOne_Next;
                boolCarryTheOne_Next = false; //''Reinitialize.

                //    Next intCharIndex
            }

            //''Added 7/11/2016 Thomas Downes
            //boolIsALeadingZero = (strNewDigit = "0" And (Not boolCarryTheOne_Curr))

            boolIsALeadingZero = ((strNewDigit == "0") && (!boolCarryTheOne_Curr));

            //---''Added 7/11/2016 Thomas Downes
            //---If(boolIsALeadingZero) Then
            //---     MsgBox("How strange!!  A leading zero!", vbExclamation)
            //---End If ''End of "If (strNewDigit = "0") Then"

            if (boolIsALeadingZero)
            {
                //MsgBox("How strange!!  A leading zero!", vbExclamation)
                pstrErrMessage = "How strange!!  A leading zero!";
            }

            //If(boolCarryTheOne_Curr) Then strConcatenated = ("1" & strConcatenated)

            // 4-7-2020 td // if (boolCarryTheOne_Curr) strConcatenated = ("1" + strConcatenated);
            if (boolCarryTheOne_Curr)
            {
                //---strConcatenated.Append("1");
                if (pbFormatToIncludeCommas)
                {
                    if (bInsertNewComma) strConcatenated.Insert(0, ',');
                    bInsertNewComma = false;  //Reinitialize. 
                }
                
                // We need to prefix a "1" when the sum of numbers 
                //   contains a greater order of magnitude than the 
                //   summands.  So, the "1" is carried into a new
                //   decimal place that wasn't being used before.
                //   ---4/7/2020 td
                //
                strConcatenated.Insert(0, '1');
            }

            //AddPaddedDecStrings = strConcatenated

            // 4-7-2020 td // return strConcatenated;
            return strConcatenated.ToString();

            //End Function ''End of Function AddPaddedDecStrings

        }

        private static string AddDecDigits_ThenAddOneIfRequested(string pstrDecDigit1, string pstrDecDigit2,
                                                          bool pboolThenAdd1_ForPriorOperation,
                                                          ref bool pref_bCarryThe1_ForNextOperation,
                                                          ref string pstrErrMessage,
                                                          bool pbFormatIncludesCommas)
        {
            //        Private Function AddDecDigits_ThenAddOneIfRequested(ByVal pstrDecDigit1 As String,
            //                        ByVal pstrDecDigit2 As String,
            //                        ByVal pboolThenAdd1_ForPriorOperation As Boolean,
            //                        ByRef pboolCarryThe1_ForNextOperation As Boolean,
            //                        ByRef pstrErrMessage As String) As String
            //        ''
            //        ''1/8 td''Private Function AddDecDigits_AddOne(.....
            //        ''
            //        ''Minor refactoring 1/8/2020
            //        ''
            //        Dim strDecDigit_Temp As String
            //        Dim strDecDigit_Final As String
            //        Dim boolCarryThe1_Temp1 As Boolean = False
            //        Dim boolCarryThe1_Temp2 As Boolean = False

            string strDecDigit_Temp; // = ""; 
            string strDecDigit_Final = "";
            bool boolCarryThe1_Temp1 = false;
            bool boolCarryThe1_Temp2 = false;

            //--strDecDigit_Temp = AddDecDigits_ByArrays(pstrDecDigit1, pstrDecDigit2, boolCarryThe1_Temp1, pstrErrMessage)
             
            strDecDigit_Temp = AddDecDigits_ByArrays(pstrDecDigit1, pstrDecDigit2, ref boolCarryThe1_Temp1, ref pstrErrMessage);

            //        If (pstrErrMessage<> "") Then Exit Function

            if (pstrErrMessage != "") return null;

            //       If (pboolThenAdd1_ForPriorOperation) Then

            //Added 4/7/2020 thomas downes
            bool bCarryThe1_DespiteComma = (pbFormatIncludesCommas &&
                      ((strDecDigit_Temp == ",") && pboolThenAdd1_ForPriorOperation));

            if (pbFormatIncludesCommas && bCarryThe1_DespiteComma)
            {
                //
                //Special processing for commas. ---4.7.2020 td
                //  Don't let's drop the "Add 1" (Carry) simply because
                //  we have encountered commas.  ---4/7/2020 td 
                //
                pref_bCarryThe1_ForNextOperation = pboolThenAdd1_ForPriorOperation;
                return strDecDigit_Temp;  

            }
            else if (pboolThenAdd1_ForPriorOperation)
            {
                //      ''
                //      ''We've been requested to add an extra "1" due to a prior operation (for an adjacent pair of digits)
                //      ''    necessitating that the tens unit be "carried" to the current operation.
                //      ''
                //      pref_bCarryThe1_ForNextOperation = False ''Reinitialize.
                //      ''1/8/2020 td''strDecDigit_Final = AddDecDigits_ByArrays(strDecDigit_Temp, "1", boolCarryThe1_Temp2, pstrErrMessage)
                //      strDecDigit_Final = Add1_ForPriorOperation(strDecDigit_Temp, pstrErrMessage)

                pref_bCarryThe1_ForNextOperation = false; //Reinitialize.
                strDecDigit_Final = Add1_ForPriorOperation(strDecDigit_Temp, ref boolCarryThe1_Temp2, ref pstrErrMessage);
                
                // 4-7-2020 thomas downes----boolCarryThe1_Temp2 = false; //This sort of operation is highly 
                //   unlikely to trigger any additional "carry" procedures, since (9 + 9) + 1 = 18 + 1 = 19, 
                //   and 18 & 19 both have "1" as the tens unit.   Oh, wait, what about (4 + 5) + 1 = 9 + 1 = 10 ??
                //   Oops..... ---1/20/2020   

                //            ''
                //            ''Determine whether the subsequent operation (i.e.perhaps the next 
                //            ''  call to this procedure) needs to include an extra "1" to account for the 
                //            ''  the current operation(e.g.pstrDecDigit1 = "4", pstrDecDigit2 = "6"). 
                //            ''
                //            pboolCarryThe1_ForNextOperation = (boolCarryThe1_Temp1 Or boolCarryThe1_Temp2)
                //            If(pstrErrMessage<> "") Then Exit Function

                pref_bCarryThe1_ForNextOperation = (boolCarryThe1_Temp1 || boolCarryThe1_Temp2);
                if (pstrErrMessage != "") return "See error message.";

            }
            else
            {
                //      Else
                //            ''
                //            ''There is no request to "carry" the 1 from a prior operation.
                //            ''
                //            strDecDigit_Final = strDecDigit_Temp
                strDecDigit_Final = strDecDigit_Temp;
                
                //            ''
                //            ''Specify whether the subsequent operation (i.e.perhaps the next 
                //            ''  call to this procedure) needs to include an extra "1" to account for the 
                //            ''  the current operation(e.g.pstrDecDigit1 = "4", pstrDecDigit2 = "6"). 
                //            ''
                //            pboolCarryThe1_ForNextOperation = boolCarryThe1_Temp1

                pref_bCarryThe1_ForNextOperation = boolCarryThe1_Temp1;

                //        End If ''End of "If (pboolThenAdd1) Then ..... Else...."
            }

            //ExitHandler:
            //        AddDecDigits_ThenAddOneIfRequested = strDecDigit_Final

            //    End Function ''end of "Private Function AddDecDigits_ThenAddOneIfRequested"

            return strDecDigit_Final;  

        }

        private static string Add1_ForPriorOperation(string pstrDecDigit, ref bool pref_bCarry1, ref string pstrErrMessage)
        {
            //Private Function Add1_ForPriorOperation(ByVal pstrDecDigit As String,
            //                          ByRef pstrErrMessage As String) As String
            //    ''
            //    ''Added 1/8/2019 thomas downes
            //    ''
            //    ''There's a need to add an extra "1" due to a prior operation (for an adjacent pair of digits)
            //    ''    necessitating that a single tens unit be "carried" to the current operation.
            //    ''
            //    Dim boolCarryThe1 As Boolean = False
            //    Dim strDigitResult As String = ""

            //bool boolCarryThe1 = false;
            string strDigitResult = "";

            //    If (pstrDecDigit = "9") Then Throw New Exception("Program error. The sum of two digits (e.g. 9 & 9) " &
            //              "will never result in a value of 9 in the ones place.")

            //if (pstrDecDigit == "9") throw new Exception("Program error. The sum of two digits (e.g. 9 & 9) " +
            //              "will never result in a value of 9 in the ones place.");

            //    ''
            //    ''Major call.
            //    ''
            //    Const c_strDigitOne As String = "1"
            //    strDigitResult = AddDecDigits_ByArrays(pstrDecDigit, c_strDigitOne, boolCarryThe1, pstrErrMessage)

            const string c_strDigitOne = "1";
            strDigitResult = AddDecDigits_ByArrays(pstrDecDigit, c_strDigitOne, ref pref_bCarry1, ref pstrErrMessage);

            //If (boolCarryThe1) Then Throw New Exception("Program error. Adding a 1 to the ones place, after a sum of two digits (e.g. 9 & 9) " &
            //                                                "will never result in a value of 9 becoming a value of 10.")
            
            //---$----Oops, I forgot about (4+5)+1 becoming 10.  ----1/20/2020 td
            //---&-if (boolCarryThe1) throw new Exception("Program error. Adding a 1 to the ones place, after a sum of two digits (e.g. 9 & 9) " +
            //---&-                    "will never result in a value of 9 becoming a value of 10.");

            //    Return strDigitResult

            return strDigitResult;  

            //End Function ''End of "Private Function Add1_ForPriorOperation"

        }



        public static string AddDecDigits_ByArrays(string pstrDecDigit1, string pstrDecDigit2, 
                           ref bool pref_bCarryTheOne,
                          ref string pref_sErrorMessage)
        {
            //Private Function AddDecDigits_ByArrays(ByVal pstrDecDigit1 As String,
            //                      ByVal pstrDecDigit2 As String,
            //                      ByRef pboolCarryThe1 As Boolean,
            //                      ByRef pstrErrMessage As String) As String
            //
            //    Dim intIndex1 As Integer
            //    Dim intIndex2 As Integer
            //    Dim arrayDecDigs() As String
            //    Dim boolMatched1 As Boolean
            //    Dim boolMatched2 As Boolean
            //    Dim intIndexCombined As Integer
            //
            int intIndex1 = 0, intIndex2 = 0, intIndexCombined = 0;
            string[] arrayDecDigs;
            bool boolMatched1 = false, boolMatched2 = false;

            //Added 4/7/2020 td
            if (pstrDecDigit1 == null) throw new ArgumentNullException();
            if (pstrDecDigit2 == null) throw new ArgumentNullException();

            //    If(pstrDecDigit1 = " " Or pstrDecDigit2 = " ") Then
            //       If(pstrDecDigit1 = " ") Then AddDecDigits_ByArrays = pstrDecDigit2
            //        If(pstrDecDigit2 = " ") Then AddDecDigits_ByArrays = pstrDecDigit1
            //        Exit Function
            //    End If

            if (pstrDecDigit1 == " " || pstrDecDigit2 == " ")
            {
                if (pstrDecDigit1 == " ") return pstrDecDigit2;
                if (pstrDecDigit2 == " ") return pstrDecDigit1;
            }

            //Added 4/7/2020 thomas downes
            if (pstrDecDigit1 == "," && pstrDecDigit2 == ",")
            {
                return ",";
            }

            //Added 4/7/2020 thomas downes
            if (pstrDecDigit1 == "," && pstrDecDigit2[0] >= '0' && pstrDecDigit2[0] <= '9')
            {
                //Added 4/7/2020 thomas downes
                throw new InvalidOperationException("There is a comma-discrepancy in the two numbers being added.");
            }

            //    arrayDecDigs(0) = "0"
            //    arrayDecDigs(1) = "1"
            //    arrayDecDigs(2) = "2"
            //    arrayDecDigs(3) = "3"
            //    arrayDecDigs(4) = "4"
            //    arrayDecDigs(5) = "5"
            //    arrayDecDigs(6) = "6"
            //    arrayDecDigs(7) = "7"
            //    arrayDecDigs(8) = "8"
            //    arrayDecDigs(9) = "9"
            //
            arrayDecDigs = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            //    For intIndex1 = 0 To 9
            //        boolMatched1 = (pstrDecDigit1 = arrayDecDigs(intIndex1))
            //        If boolMatched1 Then Exit For
            //    Next intIndex1

            for (intIndex1 = 0; intIndex1 <= 9; intIndex1++)
            {
                boolMatched1 = (pstrDecDigit1 == arrayDecDigs[intIndex1]);
                if (boolMatched1) break;
            }

            //    If(Not boolMatched1) Then
            //       Beep()
            //        pstrErrMessage = "#1 The digit """ & pstrDecDigit1 & """ is not recognized. (AddDecDigits_ByArrays)  "
            //        Exit Function
            //    End If ''End of "If (Not boolMatched1) Then"
            //

            if (!(boolMatched1))
            {
                Microsoft.VisualBasic.Interaction.Beep();
                pref_sErrorMessage = "#1 The digit \"" + pstrDecDigit1 + "\" is not recognized. (AddDecDigits_ByArrays)  ";
                return "";
            }

            intIndexCombined = intIndex1; //Initialize.

            //For intIndex2 = 0 To 9
            //    boolMatched2 = (pstrDecDigit2 = arrayDecDigs(intIndex2))
            //    If boolMatched2 Then
            //        Exit For
            //    Else
            //        ''Increment the combined index.
            //        intIndexCombined = (1 + intIndexCombined)
            //        If(intIndexCombined >= 10) Then
            //           pboolCarryThe1 = True
            //            intIndexCombined = 0
            //        End If ''End of "If (intIndexCombined >= 10) Then"
            //    End If
            //Next intIndex2

            for (intIndex2 = 0; intIndex2 <= 9; intIndex2++)
            {
                boolMatched2 = (pstrDecDigit2 == arrayDecDigs[intIndex2]);
                if (boolMatched2) break;
                //Increment the combined index.
                intIndexCombined++;
                if (intIndexCombined >= 10)
                {
                    pref_bCarryTheOne = true;
                    intIndexCombined = 0; 
                }
            }

            //    If(Not boolMatched2) Then
            //       Beep()
            //        pstrErrMessage = "#2 The digit """ & pstrDecDigit2 & """ is not recognized. (AddDecDigits_ByArrays)  "
            //        Exit Function
            //    End If ''End of "If (Not boolMatched2) Then"
            //

            if (!(boolMatched2))
            {
                Microsoft.VisualBasic.Interaction.Beep();
                pref_sErrorMessage = "#2 The digit \"" + pstrDecDigit2 + "\" is not recognized. (AddDecDigits_ByArrays)  ";
                return "";
            }

            //    ''
            //''Return the Dec digit to which the 2nd loop has "pushed us"
            //''   incrementally.So, the calculation is effectively as follows:
            //''
            //''   "6" + "7" = "6" + "1 + 1 + 1 + 1 + 1 + 1 + 1"
            //''                      7   8   9   0   1   2   3
            //''
            //AddDecDigits_ByArrays = arrayDecDigs(intIndexCombined)

            return arrayDecDigs[intIndexCombined];
            //return 0; 
        }

        public static char AddDecDigits_ByArrays_NotInUse(char pstrDecDigit1, char pstrDecDigit2,
                   ref bool pref_bCarryTheOne,
                   ref string pref_sErrorMessage)
        {
            //
            //Added 1/9/2019 thomas downes
            //
            //   C++ is more likely to use characters ("char") than
            //   strings of length one (1). 
            //
            int intIndex1 = 0, intIndex2 = 0, intIndexCombined = 0;
            char[] arrayDecDigs;
            bool boolMatched1 = false;
            bool boolMatched2 = false;

            if (pstrDecDigit1 == ' ' || pstrDecDigit2 == ' ')
            {
                if (pstrDecDigit1 == ' ') return pstrDecDigit2;
                if (pstrDecDigit2 == ' ') return pstrDecDigit1;
            }

            arrayDecDigs = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (intIndex1 = 0; intIndex1 <= 9; intIndex1++)
            {
                boolMatched1 = (pstrDecDigit1 == arrayDecDigs[intIndex1]);
                if (boolMatched1) break;
            }

            //    If(Not boolMatched1) Then
            //       Beep()
            //        pstrErrMessage = "#1 The digit """ & pstrDecDigit1 & """ is not recognized. (AddDecDigits_ByArrays)  "
            //        Exit Function
            //    End If ''End of "If (Not boolMatched1) Then"
            //

            if (!(boolMatched1))
            {
                Microsoft.VisualBasic.Interaction.Beep();
                pref_sErrorMessage = "#1 The digit \"" + pstrDecDigit1 + "\" is not recognized. (AddDecDigits_ByArrays)  ";
                return '?';
            }

            intIndexCombined = intIndex1; //Initialize.

            //For intIndex2 = 0 To 9
            //    boolMatched2 = (pstrDecDigit2 = arrayDecDigs(intIndex2))
            //    If boolMatched2 Then
            //        Exit For
            //    Else
            //        ''Increment the combined index.
            //        intIndexCombined = (1 + intIndexCombined)
            //        If(intIndexCombined >= 10) Then
            //           pboolCarryThe1 = True
            //            intIndexCombined = 0
            //        End If ''End of "If (intIndexCombined >= 10) Then"
            //    End If
            //Next intIndex2

            for (intIndex2 = 0; intIndex2 <= 9; intIndex2++)
            {
                boolMatched2 = (pstrDecDigit2 == arrayDecDigs[intIndex2]);
                if (boolMatched2) break;
                //Increment the combined index.
                intIndexCombined++;
                if (intIndexCombined >= 10)
                {
                    pref_bCarryTheOne = true;  //Indicate that we have exceeded the array. 
                    intIndexCombined = 0;  //Go back to the beginning of the array. 
                }
            }

            //    If(Not boolMatched2) Then
            //       Beep()
            //        pstrErrMessage = "#2 The digit """ & pstrDecDigit2 & """ is not recognized. (AddDecDigits_ByArrays)  "
            //        Exit Function
            //    End If ''End of "If (Not boolMatched2) Then"
            //

            if (!(boolMatched2))
            {
                Microsoft.VisualBasic.Interaction.Beep();
                pref_sErrorMessage = "#2 The digit \"" + pstrDecDigit2 + "\" is not recognized. (AddDecDigits_ByArrays)  ";
                return '?';
            }

            //''
            //''Return the Dec digit to which the 2nd loop has "pushed us"
            //''   incrementally.So, the calculation is effectively as follows:
            //''
            //''   "6" + "7" = "6" + "1 + 1 + 1 + 1 + 1 + 1 + 1"
            //''                      7   8   9   0   1   2   3
            //''
            //AddDecDigits_ByArrays = arrayDecDigs(intIndexCombined)

            return arrayDecDigs[intIndexCombined];
            //return 0; 

        }

        //Private Function AddDecDigits_ByArrays(ByVal pstrDecDigit1 As String,
        //                      ByVal pstrDecDigit2 As String,
        //                      ByRef pboolCarryThe1 As Boolean,
        //                      ByRef pstrErrMessage As String) As String
        //
        //    Dim intIndex1 As Integer
        //    Dim intIndex2 As Integer
        //    Dim arrayDecDigs() As String
        //    Dim boolMatched1 As Boolean
        //    Dim boolMatched2 As Boolean
        //    Dim intIndexCombined As Integer
        //
        //    If(pstrDecDigit1 = " " Or pstrDecDigit2 = " ") Then
        //       If(pstrDecDigit1 = " ") Then AddDecDigits_ByArrays = pstrDecDigit2
        //        If(pstrDecDigit2 = " ") Then AddDecDigits_ByArrays = pstrDecDigit1
        //        Exit Function
        //    End If
        //
        //    ReDim arrayDecDigs(0 To 9)
        //
        //    arrayDecDigs(0) = "0"
        //    arrayDecDigs(1) = "1"
        //    arrayDecDigs(2) = "2"
        //    arrayDecDigs(3) = "3"
        //    arrayDecDigs(4) = "4"
        //    arrayDecDigs(5) = "5"
        //    arrayDecDigs(6) = "6"
        //    arrayDecDigs(7) = "7"
        //    arrayDecDigs(8) = "8"
        //    arrayDecDigs(9) = "9"
        //
        //    For intIndex1 = 0 To 9
        //        boolMatched1 = (pstrDecDigit1 = arrayDecDigs(intIndex1))
        //        If boolMatched1 Then Exit For
        //    Next intIndex1
        //
        //    If(Not boolMatched1) Then
        //       Beep()
        //        pstrErrMessage = "#1 The digit """ & pstrDecDigit1 & """ is not recognized. (AddDecDigits_ByArrays)  "
        //        Exit Function
        //    End If ''End of "If (Not boolMatched1) Then"
        //
        //    intIndexCombined = intIndex1 ''Initialize.
        //
        //    For intIndex2 = 0 To 9
        //        boolMatched2 = (pstrDecDigit2 = arrayDecDigs(intIndex2))
        //        If boolMatched2 Then
        //            Exit For
        //        Else
        //            ''Increment the combined index.
        //            intIndexCombined = (1 + intIndexCombined)
        //            If(intIndexCombined >= 10) Then
        //               pboolCarryThe1 = True
        //                intIndexCombined = 0
        //            End If ''End of "If (intIndexCombined >= 10) Then"
        //        End If
        //    Next intIndex2
        //
        //    If(Not boolMatched2) Then
        //       Beep()
        //        pstrErrMessage = "The digit """ & pstrDecDigit2 & """ is not recognized."
        //        Exit Function
        //    End If ''End of "If (Not boolMatched2) Then"
        //
        //    ''
        //    ''Return the Dec digit to which the 2nd loop has "pushed us"
        //    ''   incrementally.So, the calculation is effectively as follows:
        //    ''
        //    ''   "6" + "7" = "6" + "1 + 1 + 1 + 1 + 1 + 1 + 1"
        //    ''                      7   8   9   0   1   2   3
        //    ''
        //    AddDecDigits_ByArrays = arrayDecDigs(intIndexCombined)
        //
        //End Function //End of "Private Function AddDecDigits_ByArrays(ByVal pstrDecDigit1 As String, ..."

    }
}
