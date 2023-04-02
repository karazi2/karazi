#include <cmath>
const double pi = 3.14159265358;

class Cone {
private:
    double x_center, y_center, z_center, radius, height;
public:
    Cone() { x_center = y_center = z_center = radius = height = 0; }
    Cone(double h, double r) {
        x_center = y_center = z_center = 0.0;
        height = h;
        radius = r;
    }
    Cone(double x, double y, double z, double r, double h) {
        x_center = x;
        y_center = y;
        z_center = z;
        radius = r;
        height = h;
    }
    void setCone(double x, double y, double z, double r, double h);
    void getCoordinates();
    double getRadius();
    double getHeight();
    double getArea();
    double getVolume();
};