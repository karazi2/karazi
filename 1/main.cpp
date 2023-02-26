#include <iostream>
#include "Triangle.h"
using namespace std;
int main()
{
    setlocale(LC_ALL, "Russian");
    Triangle mas[3];
    double a, b, c;
    for (int i = 0; i < 3; i++) {
        
        cin >> a >> b >> c;
        mas[i].set(a, b, c);
        if (!(mas[i].exst_tr())) {
            mas[i].show();
            cout << "Треугольника с такими сторонами не существует, попробуйте ещё раз" << endl;
            i--;
        }
    }
    for (int i = 0; i < 3; i++) {
        mas[i].show();
        cout << "Периметр треугольника: " << mas[i].perimetr() << endl;
        cout << "Площадь треугольника: " << mas[i].square() << endl;
    }
    return 0;
}