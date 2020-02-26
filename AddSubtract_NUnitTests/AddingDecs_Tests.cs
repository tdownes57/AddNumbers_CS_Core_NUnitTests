using NUnit.Framework;
//using AddSubtractHugeNumbers_CS; //Added 1-0 8-2019 thomas downes 
// Added 2/26/2020 td //using AddingHugeNumbersCS;  //Added 2/13/2020 thomas downes
using AddHugeNumbers_NetCore; //Refreshed 2/26/2020 td 

namespace AddSubtract_NUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(" ", "0")]
        [TestCase("0", " ")]
        [TestCase("0", "0")]
        [TestCase("0", " ")]
        [TestCase("5", "5")]
        [TestCase("6", "4")]
        [TestCase("7", "3")]
        [TestCase("8", "2")]
        [TestCase("9", "1")]
        [TestCase("4", "6")]
        [TestCase("3", "7")]
        [TestCase("2", "8")]
        [TestCase("1", "9")]
        public void AddingDecimals_Equals0(string psDecDigit1, string psDecDigit2)
        {
            bool boolCarry = false;
            string strErrMessage = "";
            
            //var result = AddingDecs.AddDecDigits_ByArrays(" ", " ", boolCarry, strErrMessage);
            string strResult = AddingDecs.AddDecDigits_ByArrays(psDecDigit1, psDecDigit2, 
                 ref boolCarry, ref strErrMessage);

            bool bMatchesExpectation = (strResult == "0");

            Assert.IsTrue(bMatchesExpectation, 
                $"Added {psDecDigit1} and {psDecDigit2} should be equal to \"0\" not \"{strResult}\".  " + strErrMessage);

        }
         

        [TestCase(" ", "1")]
        [TestCase("1", " ")]
        [TestCase("0", "1")]
        [TestCase("1", "0")]
        [TestCase("2", "9")]
        [TestCase("3", "8")]
        [TestCase("4", "7")]
        [TestCase("5", "6")]
        [TestCase("6", "5")]
        [TestCase("7", "4")] 
        [TestCase("8", "3")]
        [TestCase("9", "2")]
        public void AddingDecimals_Equals1(string psDecDigit1, string psDecDigit2)
        {
            bool boolCarry = false;
            string strErrMessage = "";

            //var result = AddingDecs.AddDecDigits_ByArrays(" ", " ", boolCarry, strErrMessage);
            string strResult = AddingDecs.AddDecDigits_ByArrays(psDecDigit1, psDecDigit2,
                 ref boolCarry, ref strErrMessage);

            bool bMatchesExpectation = (strResult == "1");

            Assert.IsTrue(bMatchesExpectation,
                $"Added {psDecDigit1} and {psDecDigit2} should be equal to \"1\" not \"{strResult}\".  " + strErrMessage);

        }


        [TestCase(" ", "2")]
        [TestCase("2", " ")]
        [TestCase("0", "2")]
        [TestCase("1", "1")]
        [TestCase("2", "0")]
        [TestCase("3", "9")]
        [TestCase("4", "8")]
        [TestCase("5", "7")]
        [TestCase("6", "6")]
        [TestCase("7", "5")]
        [TestCase("8", "4")]
        [TestCase("9", "3")]
        public void AddingDecimals_Equals2(string psDecDigit1, string psDecDigit2)
        {
            bool boolCarry = false;
            string strErrMessage = "";

            //var result = AddingDecs.AddDecDigits_ByArrays(" ", " ", boolCarry, strErrMessage);
            string strResult = AddingDecs.AddDecDigits_ByArrays(psDecDigit1, psDecDigit2,
                 ref boolCarry, ref strErrMessage);

            bool bMatchesExpectation = (strResult == "2");

            Assert.IsTrue(bMatchesExpectation,
                $"Added {psDecDigit1} and {psDecDigit2} should be equal to \"2\" not \"{strResult}\".  " + strErrMessage);

        }


        [TestCase(" ", "3")]
        [TestCase("3", " ")]
        [TestCase("0", "3")]
        [TestCase("1", "2")]
        [TestCase("2", "1")]
        [TestCase("3", "0")]
        [TestCase("4", "9")]
        [TestCase("5", "8")]
        [TestCase("6", "7")]
        [TestCase("7", "6")]
        [TestCase("8", "5")]
        [TestCase("9", "4")]
        public void AddingDecimals_Equals3(string psDecDigit1, string psDecDigit2)
        {
            bool boolCarry = false;
            string strErrMessage = "";

            //var result = AddingDecs.AddDecDigits_ByArrays(" ", " ", boolCarry, strErrMessage);
            string strResult = AddingDecs.AddDecDigits_ByArrays(psDecDigit1, psDecDigit2,
                 ref boolCarry, ref strErrMessage);

            bool bMatchesExpectation = (strResult == "3");

            Assert.IsTrue(bMatchesExpectation,
                $"Added {psDecDigit1} and {psDecDigit2} should be equal to \"3\" not \"{strResult}\".  " + strErrMessage);

        }


        [TestCase("-1", "-1")]
        [TestCase("-1", "1")]
        [TestCase("-2", "2")]
        [TestCase("2", "-2")]
        public void AddingNegatives_Equals0(string psDecDigit1, string psDecDigit2)
        {
            //
            //What happens when one of the numbers is negative?   
            //
            bool boolCarry = false;
            string strErrMessage = "";

            string strResult = AddingDecs.AddDecDigits_ByArrays(psDecDigit1, psDecDigit2,
                 ref boolCarry, ref strErrMessage);

            bool bMatchesExpectation = (strResult == "0");

            Assert.IsTrue(bMatchesExpectation,
                $"Added {psDecDigit1} and {psDecDigit2} should be equal to \"0 \" not \"{strResult}\".  " + strErrMessage);

        }


        [TestCase(" ", "20")]
        [TestCase("20", " ")]
        [TestCase("0", "20")]
        [TestCase("1", "19")]
        [TestCase(" 1", "19")]
        [TestCase("2", "18")]
        [TestCase(" 2", "18")]
        [TestCase("   3", "17")]
        [TestCase("     4", "16")]
        [TestCase("5", "15")]
        [TestCase("  6", "14")]
        [TestCase("7", "13")]
        [TestCase("  8", "12")]
        [TestCase("9", "11")]
        [TestCase("10", "10")]
        [TestCase("  10", "    10")]
        public void AddingDecimals_Equals20(string psDecimalString1, string psDecimalString2)
        {
            //
            //Added 2/26/2020 thomas downes  
            //
            //bool boolCarry = false;
            string strErrMessage = "";

            //var result = AddingDecs.AddDecDigits_ByArrays(" ", " ", boolCarry, strErrMessage);
            //string strResult = AddingDecs.AddDecDigits_ByArrays(psDecDigit1, psDecDigit2,
            //     ref boolCarry, ref strErrMessage);

            //Added 2/26/2020 thomas downes  
            string strResult = AddingDecs.AddDecDigits_PaddedStrings(psDecimalString1, psDecimalString2, ref strErrMessage);

            bool bMatchesExpectation = (strResult == "3");

            //Added 2/26/2020 thomas downes  
            Assert.IsTrue(bMatchesExpectation,
                $"Added {psDecimalString1} and {psDecimalString2} should be equal to \"20\" not \"{strResult}\".  " + strErrMessage);

        }



        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}