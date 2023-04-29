#pragma once
#include "Digit.h"

//
//  ASCII table  https://www.asc.ohio-state.edu/demarneffe.1/LING5050/material/characters.html
//  48   0
//  49   1
//  50   2
//  51   3
//  52   4
//  53   5
//  54   6
//  55   7
//  56   8
//  57   9
//
class Digit_NotUsed
{
private:
	char _char;
public:



};




class HugeNumber
{
private:

	const int capacity = 500;  
	//char mod_array[]; // char(500); To store 0, 1, 2, 3, 4, 5, 6, 7, 8, 9.
	Digit mod_array[500]; // = {};

	//    The number 1957 is stored as '7', '5', '9', '1', 
	//    (or the ASCII equivalents, 48, 49, 50, .... 57).
	int mod_numDigits = 0; 


public: 

	HugeNumber() : mod_numDigits(0)
	{
		//mod_numDigits = 0; 
		//Works. mod_array[500];
		//mod_array = new char[capacity];
		//mod_array = new Digit[capacity];
	}

	HugeNumber(int par_intToCopy)
	{
		int temp = par_intToCopy;
		int indexDigit = 0;  
		while (temp > 0)
		{
			//The number 1957 is stored as '7', '5', '9', '1'.
        	//    (or the ASCII equivalents, 48, 49, 50, .... 57).
			// //
			//mod_array[indexDigit] = char(temp % 10);
			mod_array[indexDigit] = Digit(temp % 10);
			temp = (temp / 10);
		}


	}

	HugeNumber AddNumber(HugeNumber otherNumber)
	{
		int indexDigit = 0;
		HugeNumber output;
		bool bEnteredInnerLoop = false;
		int intMaxDigits = (mod_numDigits > otherNumber.mod_numDigits ? mod_numDigits :
			otherNumber.mod_numDigits);

		while (indexDigit < intMaxDigits)
		{



		}



	}


	Digit GetDigit_OrZero(int par_index)
	{
		if (par_index >= mod_numDigits)
		{
			return Digit();   //The default digit is '0'.
		}
		else return mod_array[par_index];
	}








};

