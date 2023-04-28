#include "Digit.h"
#include <stdexcept>


Digit::Digit() : _char('0'), _beyond9(false), _under0(false)
{
	// _char = '0';
	// _beyond9 = false;  //Default value.
	// _under0 = false;  //Default value.
}


Digit::Digit(char par_char)
{
	_char = par_char;
	_beyond9 = false;  //Default value.
	_under0 = false;  //Default value.
}


Digit::Digit(int par_lessThan10)
{
	if (par_lessThan10 > 9) throw std::invalid_argument("Is 10 or more!");
	if (par_lessThan10 < 0) throw std::invalid_argument("Is less than 0!");

	_char = '0';
    while (par_lessThan10-- > 0) { _char++; }  
	_beyond9 = false;  //Default value.
	_under0 = false;  //Default value.
}


Digit::Digit(char par_char, bool par_beyond9)
{
	_char = par_char;
	_beyond9 = par_beyond9;
	_under0 = false;  //Default value.
}


Digit::Digit(char par_char, bool par_beyond9, bool par_under0)
{
	_char = par_char;
	_beyond9 = par_beyond9;
	_under0 = par_under0;
}


//
// Additive operator.
//
Digit Digit::operator+(const Digit& otherDigit) // Addition operator.  
{
	char tempCharA = _char; //         // We'll use A to calculate A + B.  
	char tempCharB = otherDigit._char; // We'll use B to calculate A + B.
	bool tempBeyond9 = false;

	while (tempCharB > '0')
	{
		--tempCharB; // One unit of value is being swapped from B...
		tempCharA++; //   to A. 
		if (tempCharA > '9') { tempCharA = '0'; tempBeyond9 = true; }
	}
	return Digit(tempCharA, tempBeyond9);

}


//
// Subtraction operator.
//
Digit Digit::operator-(const Digit& otherDigit) // Subtraction operator.  
{
	char tempCharA = _char; //         // We'll use A to calculate A - B.  
	char tempCharB = otherDigit._char; // We'll use B to calculate A - B.
	bool tempUnder0 = false;

	while (tempCharB > '0')
	{
		--tempCharB; // One unit of value is being swapped from B...
		--tempCharA; //   and reducing A by one unit of value. 
		if (tempCharA < '0') { tempCharA = '9'; tempUnder0 = true; }
	}
	return Digit(tempCharA, false, tempUnder0);

}


//
// Prefix operator.
//
Digit& Digit::operator++() // Prefix operator.  
{
	_char += 1;
	if (_char = ':' || _char > '9')
	{
		_char = '0';
		_beyond9 = true;
	}
	return *this;
}


//
// Postfix operator.
//
Digit Digit::operator++(int) // Postfix operator.
{
	Digit temp(_char);
	_char -= 1;
	if (_char = ':' || _char > '9')
	{
		_char = '0';
		_beyond9 = true;
	}
	return temp;
}


//
// Prefix operator, decrementing. 
//
Digit& Digit::operator--() // Prefix operator, decrementing.  
{
	_char += 1;
	if (_char = '/' || _char < '0')
	{
		_char = '9';
		_under0 = true;
	}
	return *this;
}

//
// Postfix operator, decrementing. 
//
Digit Digit::operator--(int) // Postfix operator, decrementing.
{
	Digit temp(_char);
	_char -= 1;
	if (_char = '/' || _char < '0')
	{
		_char = '9';
		_under0 = true;
	}
	return temp;
}


bool Digit::popBeyond9()
{
	bool temp = _beyond9;
	_beyond9 = false; // Reintialize.
	return temp;
}


bool Digit::popUnder0()
{
	bool temp = _under0;
	_under0 = false; // Reintialize.
	return temp;
}


bool Digit::isBeyond9()
{
	return _beyond9;
}


bool Digit::isUnder0()
{
	return _under0;
}


char Digit::getCharDigit()
{
	return _char;  // Should be '0' 
}



