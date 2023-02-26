#include <iostream>
#include "Triangle.h"
#include <cmath>
using namespace std;

bool Triangle::exst_tr() {
	return ((a < (c + b)) && (b < (a + c)) && (c < (a + b)));
}
void Triangle::set(double a1, double b1, double c1)
{
	a = a1;
	b = b1;
	c = c1;
}
void Triangle::show()
{
	cout << a << " " << b << " " << c << endl;
}
double Triangle::perimetr()
{
	return a + b + c;
}
double Triangle::square()
{
	double per = (a + b + c) / 2;
	return sqrt((per - a) * (per - b) * (per - c) * per);
};
