#include <string>
#include <iostream>
using namespace std;

class Ocean {
private:
    string name;
    string location;
    double depth;
    double surface_area;
public:
    Ocean() {}
    Ocean(string n, string l, double d, double a) : name(n), location(l), depth(d), surface_area(a) {}
    friend ostream& operator<<(ostream& out, const Ocean& o);
    friend istream& operator>>(istream& in, Ocean& o);
};

class Sea : public Ocean {
private:
    string type;
    bool is_saltwater;
public:
    Sea() {}
    Sea(string n, string l, double d, double a, string t, bool sw) : Ocean(n, l, d, a), type(t), is_saltwater(sw) {}
    friend ostream& operator<<(ostream& out, const Sea& s);
    friend istream& operator>>(istream& in, Sea& s);
};

class Bay : public Sea {
private:
    string country;
    string nearest_city;
public:
    Bay() {}
    Bay(string n, string l, double d, double a, string t, bool sw, string c, string nc) : Sea(n, l, d, a, t, sw), country(c), nearest_city(nc) {}
    friend ostream& operator<<(ostream& out, const Bay& b);
    friend istream& operator>>(istream& in, Bay& b);
};
