#include <iostream>
#include "water.h"
using namespace std;

int main()
{
    Ocean o1("Pacific", "North/South America, Asia", 3238, 63000000);
    Ocean o2;
    cout << "Enter data for ocean:\n";
    cin >> o2;
    Sea s1("Mediterranean", "Europe, Africa, Asia", 512, 2500000, "Enclosed", true);
    Sea s2;
    cout << endl;
    cout << "Enter data for sea:\n";
    cin >> s2;
    Bay b1("Chesapeake Bay", "USA", 8, 11646, "Estuary", true, "United States", "Washington, D.C.");
    Bay b2;
    cout << endl;
    cout << "Enter data for bay:\n";
    cin >> b2;
    cout << o1 << endl;
    cout << o2 << endl;
    cout << s1 << endl;
    cout << s2 << endl;
    cout << b1 << endl;
    cout << b2 << endl;
    return 0;
}
