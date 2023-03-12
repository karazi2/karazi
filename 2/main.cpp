#include <iostream>
#include "rational.h"

using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	int size;
	cout << "Введите количество дробей: "; cin >> size;
	cout << "\n";
	rational* arr = new rational[size];
	int a, b;

	cout << "Вводите числитель и знаменатель через пробел \n";
	for (int i = 0; i < size; i++)
	{
		cout << "Дробь номер " << i + 1 << " : ";
		cin >> a >> b;
		(arr[i]).set(a, b);
	}
	cout << "\n";
	for (int i = 0; i < size; i++)
	{
		cout << "\nВывод дроби " << i + 1 << " : ";
		(arr[i]).show();
	}
	cout << "\n";

	delete[] arr;

	return 0;
}