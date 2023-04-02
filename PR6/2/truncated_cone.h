#ifndef TRUNCATED_CONE_H
#define TRUNCATED_CONE_H

#include "cone.h"

class TruncatedCone : public Cone {
    double top_radius_;
public:
    TruncatedCone();
    TruncatedCone(double radius, double height, double top_radius);
    double SurfaceArea() const override;
    double Volume() const override;
    friend std::ostream& operator<<(std::ostream& os, const TruncatedCone& cone);
    friend std::istream& operator>>(std::istream& is, TruncatedCone& cone);
    bool operator==(const TruncatedCone& other) const;
    bool operator!=(const TruncatedCone& other) const;
};

#endif
