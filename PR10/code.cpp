#include "code.h"

type5::type5(double b1, double c1) {
    B = b1;
    C = c1;
}

void type5::Get_answer() {
    cout << "Корень уравнения: " << (-1) * (C / B) << endl;
}

void type5::show() {
    cout << "Уравнение " << B << "*x + " << C << " = 0" << endl;
}

type6::type6(double a1, double b1, double c1) {
    A = a1;
    B = b1;
    C = c1;
}

void type6::Get_answer() {
    double D = B * B - 4 * A * C;
    if (D < 0) {
        cout << "Уравнение не имеет действительных корней" << endl;
    }
    else {
        if (D == 0) {
            double x = ((-1) * B - sqrt(D)) / (2 * A);
            cout << "Корень уравнения: " << x << endl;
        }
        else {
            double x1 = ((-1) * B - sqrt(D)) / (2 * A);
            double x2 = ((-1) * B + sqrt(D)) / (2 * A);
            cout << "Корни уравнения: " << endl;
            cout << "X1 = " << x1 << endl << "X2 = " << x2 << endl;
        }
    }
}

void type6::show() {
    cout << "Уравнение " << A << "*x^2 + " << B << "*x + " << C << " = 0" << endl;
}
