#include <iostream>
#include <sstream>
#include <bitset>
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

vector <int> x, y, c;
vector <int> result;
void read()
{
	string s;
	cin >> s;
	for(int i=0; i<s.length(); i++)
		if(s[i] == '0')
			x.push_back(0); else
			x.push_back(1);

	cin >> s;
	for(int i=0; i<s.length(); i++)
		if(s[i] == '0')
			y.push_back(0); else
			y.push_back(1);
}
vector <int>& divide(vector <int>& a, vector<int>& b, vector<int>& c) {
	bool ok = 1;
	//for(int i=0; i<a.size(); i++) cout << a[i] ; cout << endl;
	//for(int i=0; i<b.size(); i++) cout << b[i] ; cout << endl;
	for(int i=0; i<a.size(); i++) result.push_back(0);
	c.clear();
	for(int i=0; i<a.size()-b.size() + 1; i++) c.push_back(0);
	while(ok)
	{		
		ok = 0;
		int ind;
		for(int i=b.size()-1; i<a.size(); i++)
			if(a[i]) ok = 1, ind = i;
		if(!ok) break;
		
		int deg = ind + 1 - b.size();
		c[ind - b.size() +1] = 1;
		//for(int i=0; i<a.size(); i++) cout << a[i] ; cout << endl;
		//cout << deg << endl; cout << endl;
		for(int i=0; i<b.size(); i++)
			if(b[i])
				a[i + deg] ^= 1;
		result[deg] ^= 1;
	}

	return a;
}

void work(vector <int>&x, vector <int>& y)
{
	bool ost = 1;
	int ind = -1;
	vector <int> add;
	for(int i=0; i<x.size(); i++)
		add.push_back(0);

	while(ost)
	{
		ost = 0;
		for(int i=0; i<x.size(); i++)
			x[i] ^= add[i];

		auto res = divide(x, y, c);
		for(int i=0; i<res.size(); i++)
			if(res[i]) ost = 1;
		
		////////////////////////////////////
		for(int i=0; i<res.size(); i++) 
			if(res[i]) 
			{
				cout << "x" << "^" << i << " + ";
			} cout << endl;
		for(int i=0; i<add.size(); i++) cout << add[i]; cout << endl; 
		for(int i=result.size()-1; i>=0; i--) 
			if(result[i]) 
			{
				cout << "x" << "^" << i << " + ";
			} cout << endl;
		cout << endl;
		
		if(!ost) break;
		for(int i=0; i<x.size(); i++)
			x[i] ^= add[i];
		ind++;
		if(ind) add[ind-1] = 0; add[ind] = 1;


	}
}

void buildMatrix1(int l, int r)
{
 string tt[55] ;
 string s;
 cin >> s;
 //cout << s << endl;
 for(int i=0; i<s.length(); i++)
  if(s[i] == '0') y.push_back(0); else y.push_back(1);
 for(int i=0; i<=r; i++) x.push_back(0);
 for(int ind = l; ind <= r; ind++) {
  for(int i=0; i<=r; i++) x[i] = 0;
  x[ind] = 1;
  cout << ind << ": ";

  auto res = divide(x, y,c);
  for(int i=res.size()-1; i>=0; i--) 
  if(res[i]) 
  {
   cout << "x" << "^" << i << " + "; 
  } 
  
  cout << " ::: " ;tt[ind-l] = ""; for(int i=0; i<=y.size()-2; i++) { cout << res[i]; tt[ind-l].push_back(char(res[i] + '0'));} 
  cout << endl;
  cout << endl;
 }
 cout << endl << endl << endl;
  int n = 9;
  int m = 13;
  for(int i=1; i<=n; i++) 
  {
   for(int j=0; j<tt[i-1].size(); j++) cout << tt[i-1][j] << "\t"; cout << "|\t";
   for(int j=1; j<=n; j++)
    if(i == j) cout << 1 << "\t"; else cout << 0 << "\t"; cout << endl; 
  }
}


void buildMatrix2(int l, int r)
{
 string tt[55] ;
 string s;
 cin >> s;
 //cout << s << endl;
 for(int i=0; i<s.length(); i++)
  if(s[i] == '0') y.push_back(0); else y.push_back(1);
 for(int i=0; i<=r; i++) x.push_back(0), tt[i] = "";
 for(int ind = l; ind <= r; ind++) {
  for(int i=0; i<=r; i++) x[i] = 0;
  x[ind] = 1;
  cout << ind << ": ";

  auto res = divide(x, y, c);
  for(int i=res.size()-1; i>=0; i--) 
  if(res[i]) 
  {
   cout << "x" << "^" << i << " + "; 
  } 
  
  cout << " ::: " ;for(int i=0; i<=y.size()-2; i++) { cout << res[i]; tt[i].push_back(char(res[i] + '0'));} 
  cout << endl;
  cout << endl;
 }
 cout << endl << endl << endl;
  int n = 5;
  int m = 17;
  for(int i=1; i<=n; i++) 
  {   
   for(int j=1; j<=n; j++)
    if(i == j) cout << 1 << "\t"; else cout << 0 << "\t"; 
   cout << "|\t"; 
   for(int j=0; j<tt[i-1].size(); j++) cout << tt[i-1][j] << "\t"; 
   cout << endl;
  }
}

void multiply()
{
 int n;
 cin >> n;
 int res[5555] = {};
 res[0] = 1;
 for(int i=0; i<n; i++) {
  string s;
  cin >> s;
  int cur[5555] = {};
  for(int ii=0; ii<s.length(); ii++)
   if(s[ii] == '1')
    for(int j=0; j<55; j++)
     if(res[j])
      cur[ii+j] ^= 1;

  for(int k=0; k<55; k++) res[k] = cur[k];
 }

 for(int i=0; i<=55; i++) 
  if(res[i]) 
  {
   cout << "x" << "^" << i << " + ";
  } cout << endl;
 for(int i=0; i<=30; i++)  cout << res[i] ;
}



int main() {  
    //freopen("in.txt", "r", stdin);
    //freopen("out.txt", "w", stdout);
    ios_base::sync_with_stdio(0);
	//multiply();
	/*read();
	c.clear();
	auto res = divide(x, y, c);
		for(int i=res.size()-1; i>=0; i--) 
		if(res[i]) 
		{
			cout << "x" << "^" << i << " + ";
		} cout << endl;
		cout << endl;
		for(int i=c.size()-1; i>=0; i--) 
		if(c[i]) 
		{
			cout << "x" << "^" << i << " + ";
		} cout << endl;*/
	double a = .5;//0.327979410399929;
	cout << bitset<60>(a) ;
	system("pause");
//	work(x, y);
	//buildMatrix1(4, 12);
	//buildMatrix2(5, 16);
    return 0;
}