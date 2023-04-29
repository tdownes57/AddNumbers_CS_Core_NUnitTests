#include "HugeLessThanOneDecimal.h"
#include "Digit.h"

class HugeLessThanOneDecimal 
{
private:

	const int capacity = 500;
	//char mod_array[]; // char(500); To store 0, 1, 2, 3, 4, 5, 6, 7, 8, 9.
	Digit mod_array[500]; // = {};

	//    The number 1957 is stored as '7', '5', '9', '1', 
	//    (or the ASCII equivalents, 48, 49, 50, .... 57).
	int mod_numDigits = 0;


public:

	HugeLessThanOneDecimal() : mod_numDigits(0)
	{
		//mod_numDigits = 0; 
		//Works. mod_array[500];
		//mod_array = new char[capacity];
		//mod_array = new Digit[capacity];
	}

	HugeLessThanOneDecimal(double par_doubToCopy)
	{
		//
		// E.g. for input value 0.1734, the array of digits will be:
		// 
		//      1, 7, 3, 4
		//
		double doubTemp = par_doubToCopy;
		int intTemp = 0; 
		int indexDigit = 0;
		while (doubTemp > 0)
		{
			//The number 0.1734 is stored as '1', '7', '3', '4'.
			//    (or the ASCII equivalents, 48, 49, 50, .... 57).
			// //
			//mod_array[indexDigit] = char(temp % 10);
			doubTemp *= 10.0;  //Times by 10 to place the first 
			//   decimal digit (closest digit to the right of the decimal point)
			//   into the "ones" place. --4/28/2023m 
			 
			intTemp = static_cast<int>(doubTemp);  // 1.734 will be cast to 1.
			mod_array[indexDigit] = Digit(intTemp);
			doubTemp -= static_cast<double>(intTemp);
		}


	}

};


