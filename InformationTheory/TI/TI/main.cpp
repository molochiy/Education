#include <iostream>
#include <fstream>
#include <string>

using namespace std;

const double HYx1 = -0.83*(log(0.83)/log(2)) - 0.17*(log(0.17)/log(2));
const double HYx2 = -0.04*(log(0.04)/log(2)) - 0.96*(log(0.96)/log(2));

double X2(double x1)
{
	return 1 - x1;
}

double Y1(double x1)
{
	return x1*0.83+X2(x1)*0.04;
}

double HY(double x1)
{
	return -Y1(x1)*(log(Y1(x1))/log(2))-(1-Y1(x1))*(log(1-Y1(x1))/log(2));
}

double HYX(double x1)
{
	return HYx1*x1 + HYx2*X2(x1);
}

double I(double x1)
{
	return HY(x1) -  HYX(x1);
}

void main()
{
	ofstream out("D:\out.txt");
	out << "p(x1) \t p(y1) \t\t H(Y) \t\t H(Y/X) \t I(Y,X)" << endl;
	out.precision(5);
	for(double i = 0.65; i <= 0.75; i += 0.0005)
	{
		out << fixed << i <<" \t " << Y1(i) << " \t " << HY(i) << " \t " << HYX(i) << " \t " << I(i) << endl;
	}
	system("pause");
}