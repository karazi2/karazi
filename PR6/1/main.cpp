#include <iostream>
#include "cone.h"
using namespace std;

int main()
{
    setlocale(LC_ALL, "Russian");
    Cone c1(3, 7);
    Cone c2(1, 2, 3, 5, 10);
    cout << "Площадь первого конуса: " << c1.getArea() << "\n";
    cout << "Объём первого конуса: " << c1.getVolume() << "\n";
    cout << "Площадь второго конуса: " << c2.getArea() << "\n";
    cout << "Объём второго конуса: " << c2.getVolume() << "\n";
    cout << '\n';

    int size = 1;
    double x = 0, y = 0, z = 0, r = 0, h = 0;
    cout << "Введите количество конусов: ";
    cin >> size;
    Cone* cones = new Cone[size];
    cout << '\n';
    cout << "Вводите данные в виде x,y,z (центр основания), r (радиус), h (высота)";
    cout << '\n';
    for (int i = 0; i < size; i++) {
        cout << "Введите данные конуса номер " << i + 1 << " : ";
        cin >> x >> y >> z >> r >> h;
        cones[i].setCone(x, y, z, r, h);
    }
    cout << '\n';

    for (int i = 0; i < size; i++) {
        cout << "Данные конуса номер " << i + 1 << " : ";
        cout << '\n';
        cout << "X,Y,Z центра основания: ";
        cones[i].getCoordinates();
        cout << '\n';
        cout << "Радиус основания: " << cones[i].getRadius() << endl;
        cout << "Высота: " << cones[i].getHeight() << endl;
        cout << "Площадь поверхности: " << cones[i].getArea() << endl;
        cout << "Объем конуса: " << cones[i].getVolume() << endl;
        cout << '\n';
    }

    return 0;
}