/*#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <sstream>
#include <cstdio>
#include <cstdlib>
#include <cmath>
#include <cctype>
#include <cstring>
#include <vector>
#include <list>
#include <queue>
#include <deque>
#include <stack>
#include <map>
#include <set>
#include <algorithm>
#include <numeric>
#include <ctime>
#include <fstream>
#include <iomanip>
#include <stdexcept>
#include <functional>
#include <math.h>

#pragma comment(linker, "/STACK:133217728")

using namespace std;

int chToInt(char ch) {
	return ch - '0';
}
void Task2(string s, string w) {
	int len = s.length();
	int n = 1, m = len;
	for(int i=2; i<len; i++)
		if(!(len % i)) {
			int p = i;
			int q = len / i;
			if((p + 1) * (q + 1) < (n + 1) * (m + 1)) {
				n = p;
				m = q;
			}
		}

	if(n > m) swap(n, m);
	int rowS = 0;
	int colS = 0;
	string Code = "";
	for(int i=0; i<n; i++) {
		int res = 0;
		for(int j=0; j<m; j++) {
			res ^= chToInt(s[i * m + j]);
			cout << s[i * m + j] ;
			Code += s[i * m + j] ;
		}
		cout << "|" << res << endl;
		Code += char(res + '0');
		Code += " ";
		rowS ^= res;
	}
	for(int i=0; i<=m+1; i++) cout << "-"; cout << endl;
	for(int i=0; i<m; i++) {
		int res = 0;
		for(int j=0; j<n; j++)
			res ^= chToInt(s[j * m + i]);
		cout << res;
		Code += char(res + '0');
		colS ^= res;
	} cout << "|"; 
	if(colS != rowS) { cout << "WRONG!!!"; throw exception("COLS != ROWS"); };
	cout << colS << endl;
	Code += char(colS + '0');
	cout << "Code(X) = " << Code << endl;
	cout << "p_k = " << (n + 1) * (m + 1) - n * m << " / " << (n + 1) * (m + 1) 
		 << " = " << 1.*((n + 1) * (m + 1) - n * m)/((n + 1) * (m + 1)) << endl;

	int x[47][47];
	int c = 0; 
	int r = 0;
	for(int i=0; i<w.length(); i++)
		x[i / (m+1)][i % (m+1)] = chToInt(w[i]);
	for(int i=0; i<=n; i++) {
		int res = 0;
		for(int j=0; j<=m; j++) {
			res ^= x[i][j];
			cout << x[i][j] ;
		}
		cout << "|" << res << endl;
		c ^= res;
	} 
	for(int i=0; i<=m+2; i++) cout << "-"; cout << endl;
	for(int i=0; i<=m; i++) {
		int res = 0;
		for(int j=0; j<=n; j++)
			res ^= x[j][i];
		cout << res ;
		r ^= res;
	}
	if(c != r) { cout << "WRONG!!!"; throw exception("COLS != ROWS"); }
	cout << "|" << c << endl;
}

void Task3() {
	int x[33][33], xx[33][33];
	int n, m;
	cin >> n >> m;
	for(int i=1; i<=n; i++)
		for(int j=1; j<=m; j++)
			cin >> x[i][j];

	for(int i=1; i<=m; i++)
		for(int j=1; j<=n; j++)
			xx[i][j] = x[j][i];
	for(int p=0; p<3; p++) {
		string s;
		cin >> s;
		int y[33];

		for(int i=1; i<=s.length(); i++) y[i] = chToInt(s[i-1]);
		cout << p+1 << ") " ;
		bool wasOne = 0;
		for(int i=1; i<=1; i++)
			for(int j=1; j<=n; j++) {
				int res = 0;
				for(int k=1; k<=m; k++)
					res ^= y[k] * xx[k][j];

				cout << res ;
				if(res != 0) wasOne = 1;
			}
		
			cout << "   ";
			if(wasOne) cout << "Can not be coded."; else cout << "Can be coded";
			cout << endl;
	}

	for(int i=1; i<=m; i++) {
		for(int j=1; j<=n; j++)
			cout << x[j][i] << " "; cout << endl;
	}
		
}
int main() {  

    freopen("in2.txt", "r", stdin);
    freopen("out2.txt", "w", stdout);
    ios_base::sync_with_stdio(0);
	string s, w;
	//cin >> s >> w;
	//Task2(s, w);

	Task3();
    return 0;
}

*/

#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>

using namespace std;

int charToInt(char c)
{
	return c - '0';
}

string PrP(string x)
{
	int a = 0;
	for(int i = 0; i < x.length(); i++) a += charToInt(x[i]);
	if (a % 2 == 0) return x + "0";
	else return x + "1";
}

string PrN(string x)
{
	int a = 0;
	for(int i = 0; i < x.length(); i++) a += charToInt(x[i]);
	if (a % 2 != 0) return x + "0";
	else return x + "1";
}

string PP(string x)
{
	return x + x;
}

string IK(string x)
{
	int a = 0;
	string inversX = "";
	for(int i = 0; i < x.length(); i++) 
	{
		a += charToInt(x[i]);
		x[i] == '1' ? inversX += "0" : inversX += "1";
	}
	if (a % 2 == 0) return x + x;
	else return x + inversX;
}

void calcAndPrint(string x, string  code, string  y1, string  y2)
{
	if(code == "PrP")
	{
		cout << "Coded X with code " << code << ' ' << PrP(x) << endl;
		string tempY1 = "", tempY2 = "";
		for(int i = 0, j = 0; i < y1.length() - 1, j < y2.length() - 1; i++, j++)
		{
			tempY1 += y1[i];
			tempY2 += y2[j];
		}
		if(PrP(tempY1) == y1) cout << "Y1 coded good" << endl;
		else cout << "Y1 coded bad. It must be coded " << PrP(tempY1) << endl;

		if(PrP(tempY2) == y2) cout << "Y2 coded good" << endl;
		else cout << "Y2 coded bad. It must be coded " << PrP(tempY2) << endl;
	}
	else
	{
		if(code == "RrN")
		{
			cout << "Coded X with code " << code << ' ' << PrN(x) << endl;
			string tempY1 = "", tempY2 = "";
			for(int i = 0, j = 0; i < y1.length() - 1, j < y2.length() - 1; i++, j++)
			{
				tempY1 += y1[i];
				tempY2 += y2[j];
			}
			if(PrN(tempY1) == y1) cout << "Y1 coded good" << endl;
			else cout << "Y1 coded bad. It must be coded " << PrN(tempY1) << endl;

			if(PrN(tempY2) == y2) cout << "Y2 coded good" << endl;
			else cout << "Y2 coded bad. It must be coded " << PrN(tempY2) << endl;
		}
		else
		{
			if(code == "PP")
			{
				cout << "Coded X with code " << code << ' ' << PP(x) << endl;
				string tempY1 = "", tempY2 = "";
				for(int i = 0, j = 0; i < y1.length() / 2, j < y2.length() / 2; i++, j++)
				{
					tempY1 += y1[i];
					tempY2 += y2[j];
				}
				if(PP(tempY1) == y1) cout << "Y1 coded good" << endl;
				else cout << "Y1 coded bad. It must be coded " << PP(tempY1) << endl;

				if(PP(tempY2) == y2) cout << "Y2 coded good" << endl;
				else cout << "Y2 coded bad. It must be coded " << PP(tempY2) << endl;
			}
			else
			{
				cout << "Coded X with code " << code << ' ' << IK(x) << endl;
				string tempY1 = "", tempY2 = "";
				for(int i = 0, j = 0; i < y1.length() / 2, j < y2.length() / 2; i++, j++)
				{
					tempY1 += y1[i];
					tempY2 += y2[j];
				}
				if(IK(tempY1) == y1) cout << "Y1 coded good" << endl;
				else cout << "Y1 coded bad. It must be coded " << IK(tempY1) << endl;

				if(IK(tempY2) == y2) cout << "Y2 coded good" << endl;
				else cout << "Y2 coded bad. It must be coded " << IK(tempY2) << endl;
			}
		}
	}
}

void main()
{
	/*ifstream in("in.txt");
	ofstream out("out.txt");
	*/
	freopen("in.txt", "r", stdin);
    freopen("out.txt", "w", stdout);
	string x, y11, y12, y21, y22, code1, code2;
	cin >> x >> code1 >> code2 >> y11 >> y12 >> y21 >> y22;
	calcAndPrint(x, code1, y11, y12);
	calcAndPrint(x, code2, y21, y22);
	system("pause");
}