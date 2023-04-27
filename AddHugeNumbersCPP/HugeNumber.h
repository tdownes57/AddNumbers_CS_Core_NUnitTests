#pragma once

class HugeNumber
{
private:

	const int capacity = 500;  
	char mod_array[]; // char(500); To store 0, 1, 2, 3, 4, 5, 6, 7, 8, 9.
	//    The number 1957 is stored as '7', '5', '9', '1', 
	//    (or the ASCII equivalents, 48, 49, 50, .... 57).
	int mod_numberOfDigits = 0; 


public: 

	HugeNumber()
	{
		mod_numberOfDigits = 0; 
		//Works. mod_array[500];
		mod_array = new char[capacity];

	}

	HugeNumber(int par_intToCopy)
	{
		int temp = par_intToCopy;
		int indexDigit = 0;  
		while (temp > 0)
		{
			//The number 1957 is stored as '7', '5', '9', '1'.
        	//    (or the ASCII equivalents, 48, 49, 50, .... 57).
			mod_array[indexDigit] = char(temp % 10);
			temp = (temp / 10);
		}


	}








};

