#include <iostream>
#include "StackOnArray.h"
#include "StackOnList.h"
#include "CalculateExpression.h"
#include <vector>
#include <string>

using namespace std;

int main()
{
 try
 {
	 CalculateExpression c("(3-4)^2");
	 cout.precision(5);
	 cout << fixed << c.Calculation() << endl;
 }
 catch(exception e)
 {
	 cerr << e.what() << endl;
 }
 system("pause");
}