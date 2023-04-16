#include "code.h"

using namespace std;

type3::type3(double c1)
{
    C = c1;
}

void type3::Get_answer()
{
    cout << "Корней нет" << endl;
}

void type3::show()
{
    cout << C << " = 0" << endl;
}

type4::type4(double a1, double c1)
{
    A = a1;
    C = c1;
}

void type4::Get_answer()
{
    double k = ((-1) * C) / A;
    if (k >= 0)
    {
        double x1 = sqrt(k);
        double x2 = sqrt(k) * (-1);
        cout << "Корни уравнения: " << endl << "X1 = " << x1 << endl << "X2 = " << x2 << endl;
    }
    else
    {
        cout << "Корней нет" << endl;
    }
}

void type4::show()
{
    cout << "Уравнение " << A << "*x^2 + " << C << " = 0" << endl;
}