#include "cone.h"
#include <iostream>
void Cone::setCone(double x, double y, double z, double r, double h) {
    x_center = x;
    y_center = y;
    z_center = z;
    radius = r;
    height = h;
}
void Cone::getCoordinates()
{
    std::cout << x_center << " " << y_center << " " << z_center;
}
double Cone::getRadius() {
    return radius;
}
double Cone::getHeight() {
    return height;
}
double Cone::getArea() {
    return (pi * radius * radius) + (pi * radius * sqrt(radius * radius + height * height));
}
double Cone::getVolume() {
    return  pi * radius * radius * height / 3;
}