#include "truncated_cone.h"

TruncatedCone::TruncatedCone() : Cone(), top_radius_(0) {}

TruncatedCone::TruncatedCone(double radius, double height, double top_radius) : Cone(radius, height), top_radius_(top_radius) {}

double TruncatedCone::SurfaceArea() const {
    double L = sqrt(pow(height_, 2)+pow(radius_ - top_radius_, 2));
    double S = pi * (radius_ + top_radius_) * L;
    return S + pi * pow(radius_, 2) + pi * pow(top_radius_, 2);
}
double TruncatedCone::Volume() const {
    return (pi * height_ / 3) * (pow(radius_, 2) + pow(top_radius_, 2) + radius_ * top_radius_);
}

std::ostream& operator<<(std::ostream& os, const TruncatedCone& cone) {
    os << "Truncated Cone (r1 = " << cone.radius_ << ", r2 = " << cone.top_radius_ << ", h = " << cone.height_ << ")";
    return os;
}

std::istream& operator>>(std::istream& is, TruncatedCone& cone) {
    std::cout << "Enter the bottom radius: ";
    is >> cone.radius_;
    std::cout << "Enter the top radius: ";
    is >> cone.top_radius_;
    std::cout << "Enter the height: ";
    is >> cone.height_;
    return is;
}

bool TruncatedCone::operator==(const TruncatedCone& other) const {
    return (radius_ == other.radius_ && height_ == other.height_ && top_radius_ == other.top_radius_);
}

bool TruncatedCone::operator!=(const TruncatedCone& other) const {
    return !(*this == other);
}