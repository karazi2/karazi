#include "code.h"
#include <iostream>

using namespace std;

EquationType1::EquationType1(double a) : A(a) {}

void EquationType1::Get_answer() {
    cout << "��������� ����� ������� x = ����� �����" << endl;
}

void EquationType1::show() {
    cout << "���������: " << A << "x = 0" << endl;
}

EquationType2::EquationType2(double a) : a1(a) {}

void EquationType2::Get_answer() {
    cout << "��������� ����� ������� x = 0" << endl;
}

void EquationType2::show() {
    cout << "���������: x^2 + " << a1 << " = 0" << endl;
}