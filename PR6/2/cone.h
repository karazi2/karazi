#ifndef CONE_H
#define CONE_H

#include <iostream>
#include <cmath>

const double pi = 3.14159265359;

class Cone {
protected:
    double radius_;
    double height_;
public:
    Cone();
    Cone(double radius, double height);
    virtual double SurfaceArea() const;
    virtual double Volume() const;
    friend std::ostream& operator<<(std::ostream& os, const Cone& cone);
    friend std::istream& operator>>(std::istream& is, Cone& cone);
    bool operator==(const Cone& other) const;
    bool operator!=(const Cone& other) const;
};

#endif
