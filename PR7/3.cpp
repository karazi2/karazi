#include <iostream>
#include "code.h"

using namespace std;

int main() {
    EquationType1 eq1(5);
    EquationType2 eq2(2);

    eq1.show();
    eq1.Get_answer();

    eq2.show();
    eq2.Get_answer();

    return 0;
}