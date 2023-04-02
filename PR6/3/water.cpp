#include "water.h"
#include <iostream>

ostream& operator<<(ostream& out, const Ocean& o)
{
	out << "Name: " << o.name << endl;
	out << "Location: " << o.location << endl;
	out << "Depth: " << o.depth << " m" << endl;
	out << "Surface area: " << o.surface_area << " sq km" << endl;
	return out;
}

istream& operator>>(istream& in, Ocean& o)
{
	cout << "Enter name: ";
	in >> o.name;
	cout << "Enter location: ";
	in >> o.location;
	cout << "Enter depth (m): ";
	in >> o.depth;
	cout << "Enter surface area (sq km): ";
	in >> o.surface_area;
	return in;
}

ostream& operator<<(ostream& out, const Sea& s)
{
	out << static_cast<const Ocean&>(s);
	out << "Type: " << s.type << endl;
	out << "Is saltwater: " << s.is_saltwater << endl;
	return out;
}

istream& operator>>(istream& in, Sea& s)
{
	in >> static_cast<Ocean&>(s);
	cout << "Enter type: ";
	in >> s.type;
	cout << "Is saltwater (1 for yes, 0 for no): ";
	in >> s.is_saltwater;
	return in;
}

ostream& operator<<(ostream& out, const Bay& b)
{
	out << static_cast<const Sea&>(b);
	out << "Country: " << b.country << endl;
	out << "Nearest city: " << b.nearest_city << endl;
	return out;
}

istream& operator>>(istream& in, Bay& b)
{
	in >> static_cast<Sea&>(b);
	cout << "Enter country: ";
	in >> b.country;
	cout << "Enter nearest city: ";
	in >> b.nearest_city;
	return in;
}