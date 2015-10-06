#include <iostream>
#include <vector>
#include <string>
#include "matrix.h"

using namespace std;

int main()
{
 try
 {
	 /*cout.precision(5);
	 cout << fixed << endl;
	double arrayA[3][3] = {{1,0,3}, {0,4,6}, {3,0,0}};
			double arrayB[3][3] = {{0,0,1}, {0,2,-3}, {3,0,1}};
			double arrayC[3][3] = {{1,0,2}, {0,2,9}, {0,0,-1}};

			vector<vector<double>> vA(3);
			vector<vector<double>> vB(3);
			vector<vector<double>> vC(3);

			for(int i = 0; i < 3; i++)
			{
				vA[i] = vector<double> (arrayA[i], arrayA[i] + 3);
				vB[i] = vector<double> (arrayB[i], arrayB[i] + 3);
				vC[i] = vector<double> (arrayC[i], arrayC[i] + 3);
			}
			SparseMatrix a(vA);
			SparseMatrix b(vB);
			SparseMatrix c(vC);

			cout << a << endl << endl << b << endl << endl << a.Subtraction(b) << endl << endl << c << endl;*/

 }
 catch(exception e)
 {
	 cerr << e.what() << endl;
 }
 system("pause");
}