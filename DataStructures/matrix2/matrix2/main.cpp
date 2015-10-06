#include <iostream>
#include <fstream>
#include "matrix.h"

using namespace std;

void main()
{
	Matrix a, b, c;
	ifstream in("in.txt");
	in >> a >> b >> c;
	auto d = a.Add(b);
	cout << d.IsEqual(c) << endl;
	system("pause");
}