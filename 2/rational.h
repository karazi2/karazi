class rational
{
private:
	int a, b;
	int NOD(int a1, int b1)
	{
		if (a1 == b1) return a1;
		else
		{
			if (a1 > b1) return NOD(a1 - b1, b1);
			else return NOD(a1, b1 - a1);
		}
	}
public:
	rational()
	{
		a = 0; b = 0;
	}
	rational(int a1, int b1) {
		if (b1 == 0) { a = 0; b = 0; }
		if ((a1 > b1) and (b1 != 1)) {
			a = a1 % b1;
			double d = NOD(a1, b1);
			a = a / d;
			b = b1 / d;
		}
		else if ((a1 < b1) and (a1 != 0)) {
			double d = NOD(a1, b1);
			a = a1 / d;
			b = b1 / d;
		}
		else if ((a1 < b1) and (a1 == 0)) {
			a = a1;
			b = b1;
		}

	}
	void set(int a1, int b1);
	void show();
};
