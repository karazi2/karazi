#include "cone.h"

Cone::Cone() : radius_(0), height_(0) {}

Cone::Cone(double radius, double height) : radius_(radius), height_(height) {}

double Cone::SurfaceArea() const {
    double L = sqrt(pow(height_, 2) + pow(radius_, 2));
    double S = pi * radius_ * L;
    return S + pi * pow(radius_, 2);
}

double Cone::Volume() const {
    return (pi * pow(radius_, 2) * height_) / 3;
}

std::ostream& operator<<(std::ostream& os, const Cone& cone) {
    os << "Cone (r = " << cone.radius_ << ", h = " << cone.height_ << ")";
    return os;
}

std::istream& operator>>(std::istream& is, Cone& cone) {
    std::cout << "Enter the radius: ";
    is >> cone.radius_;
    std::cout << "Enter the height: ";
    is >> cone.height_;
    return is;
}

bool Cone::operator==(const Cone& other) const {
    return (radius_ == other.radius_ && height_ == other.height_);
}

bool Cone::operator!=(const Cone& other) const {
    return !(*this == other);
}