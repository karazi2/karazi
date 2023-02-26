#include "circle.h"
#include <cmath>

circle::circle(float r, float x, float y) {
	radius = r;
	x_center = x;
	y_center = y;
}

void circle::set_circle(float r, float x, float y) {
	radius = r;
	x_center = x;
	y_center = y;
}
float circle::square() {
	return 3.1415926 * radius * radius;
}
bool circle::triangle_around(float a, float b, float c) {
	double p = (a + b + c) / 2;
	double S = sqrt(p * (p - a) * (p - b) * (p - c));
	return (radius >= ((a + b + c) / (4 * S)));
}

bool circle::triangle_in(float a, float b, float c) {
	double p = (a + b + c) / 2;
	double S = sqrt(p * (p - a) * (p - b) * (p - c));
	return (radius <= S / p);
}
bool circle::check_circle(float r, float x_cntr, float y_cntr) {
	float dist = sqrt(pow((x_cntr - x_center), 2) + pow((y_cntr - y_center), 2));
	return (radius + r <= dist);
}