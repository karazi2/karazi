#include "code.h"
#include <iostream>

using namespace std;

EquationType1::EquationType1(double a) : A(a) {}

void EquationType1::Get_answer() {
    cout << "Уравнение имеет решение x = любое число" << endl;
}

void EquationType1::show() {
    cout << "Уравнение: " << A << "x = 0" << endl;
}

EquationType2::EquationType2(double a) : a1(a) {}

void EquationType2::Get_answer() {
    cout << "Уравнение имеет решение x = 0" << endl;
}

void EquationType2::show() {
    cout << "Уравнение: x^2 + " << a1 << " = 0" << endl;
}