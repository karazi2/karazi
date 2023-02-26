#include <iostream>
#include "figure.h"

using namespace std;

int main()
{
	figure A;
	figure B;
	figure C;

	float X1, X2, X3, X4, Y1, Y2, Y3, Y4;

	cout << "Enter coordinates of figure A ([x1,y1],[x2,y2],[x3,y3],[x4,y4])\n";
	cin >> X1 >> Y1 >> X2 >> Y2 >> X3 >> Y3 >> X4 >> Y4;
	A.define(X1, X2, X3, X4, Y1, Y2, Y3, Y4);

	cout << "Enter coordinates of figure B ([x1,y1],[x2,y2],[x3,y3],[x4,y4])\n";
	cin >> X1 >> Y1 >> X2 >> Y2 >> X3 >> Y3 >> X4 >> Y4;
	B.define(X1, X2, X3, X4, Y1, Y2, Y3, Y4);

	cout << "Enter coordinates of figure C ([x1,y1],[x2,y2],[x3,y3],[x4,y4])\n";
	cin >> X1 >> Y1 >> X2 >> Y2 >> X3 >> Y3 >> X4 >> Y4;
	C.define(X1, X2, X3, X4, Y1, Y2, Y3, Y4);

	cout << "Parametrs of figure A: "; A.show();
	cout << "Parametrs of figure B: "; B.show();
	cout << "Parametrs of figure C: "; C.show();

	cout << "\n";

	if (A.is_prug()) cout << "figure A is rectangle\n";
	if (B.is_prug()) cout << "figure B is rectangle\n";
	if (C.is_prug()) cout << "figure C is rectangle\n";

	cout << "\n";

	if (A.is_square()) cout << "figure A is square\n";
	if (B.is_square()) cout << "figure B is square\n";
	if (C.is_square()) cout << "figure C is square\n";

	cout << "\n";

	if (A.is_romb()) cout << "figure A is romb\n";
	if (B.is_romb()) cout << "figure B is romb\n";
	if (C.is_romb()) cout << "figure C is romb\n";

	cout << "\n";

	if (A.is_in_circle()) cout << "circle can be described around the figure A\n";
	if (B.is_in_circle()) cout << "circle can be described around the figure B\n";
	if (C.is_in_circle()) cout << "circle can be described around the figure C\n";

	cout << "\n";

	if (A.is_out_circle()) cout << "figure A can be inscribed with a circle\n";
	if (B.is_out_circle()) cout << "figure B can be inscribed with a circle\n;
		if (C.is_out_circle()) cout << "figure C can be inscribed with a circle\n";
}