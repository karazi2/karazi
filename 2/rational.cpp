#include "rational.h"
#include <iostream>

void rational::set(int a1, int b1)
{
	if (b1 == 0) { a = 0; b = 0; }
	if ((a1 > b1) and (b1 != 1)) {
		a = a1 % b1;
		double d = NOD(a1, b1);
		a = a / d;
		b = b1 / d;
	}
	else if ((a1 < b1) and (a1 != 0)) {
		double d = NOD(a1, b1);
		a = a1 / d;
		b = b1 / d;
	}
	else if ((a1 < b1) and (a1 == 0)) {
		a = a1;
		b = b1;
	}

}

void rational::show()
{
	std::cout << a << '/' << b;
}