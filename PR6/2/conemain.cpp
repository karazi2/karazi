#include <iostream>
#include "truncated_cone.h"

int main() {
    TruncatedCone cone1(2, 4, 1);
    std::cout << cone1 << std::endl;
    std::cout << "Surface Area: " << cone1.SurfaceArea() << std::endl;
    std::cout << "Volume: " << cone1.Volume() << std::endl;

    TruncatedCone cone2;
    std::cin >> cone2;
    std::cout << cone2 << std::endl;
    std::cout << "Surface Area: " << cone2.SurfaceArea() << std::endl;
    std::cout << "Volume: " << cone2.Volume() << std::endl;

    if (cone1 == cone2) {
        std::cout << "cone1 is equal to cone2" << std::endl;
    }
    else {
        std::cout << "cone1 is not equal to cone2" << std::endl;
    }

    TruncatedCone cone3(cone1);
    std::cout << "cone3 (copy of cone1): " << cone3 << std::endl;

    return 0;
}