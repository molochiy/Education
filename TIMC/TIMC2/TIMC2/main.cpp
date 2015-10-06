#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <iomanip>

using namespace std;

const int n = 6;
const double KsiKryt = 7.8;

void read(vector<pair<double,double>> &a, vector<int> &b, ifstream &stream)
{
	double rightInt, leftInt;
	int freq;
	stream >> leftInt;
	for(int i = 0; i < n; i++)
	{
		stream >> freq >> rightInt;
		a.push_back(make_pair(leftInt, rightInt));
		b.push_back(freq);
		leftInt = rightInt;
	}
}

void print(vector<pair<double,double>> a, vector<int> b)
{
	cout << "(x(i-1), x(i)]   ";
	for(int i = 0; i < n; i++)
	{
		cout << '(' << a[i].first << ", " << a[i].second << "]   ";
	}
	cout << endl << "n(i)\t\t";
	for(int i = 0; i < n; i++)
	{
		cout << setw(5)  << "     " << b[i] << "    ";
	}
	cout << endl << "x*(i)\t\t";
	for(int i = 0; i < n; i++)
	{
		cout << setw(5) << "     " << (a[i].first + a[i].second)/2.0 << "    ";
	}
	cout << endl;
}

double sumNi(vector<int> b)
{
	double sum = 0.0;
	for(int i = 0; i < n; i++)
	{
		sum += b[i];
	}
	return sum;
}


double mean(vector<pair<double,double>> a, vector<int> b)
{
	double arithMean = 0.0;
	for(int i = 0; i < n; i++)
	{
		arithMean += b[i]*(a[i].first + a[i].second)/2.0;
	}
	return arithMean / sumNi(b);
}

double dispersion(vector<pair<double,double>> a, vector<int> b)
{
	double arithMean = mean(a, b), sum = 0.0;
	for(int i = 0; i < n; i++)
	{
		sum += pow(((a[i].first + a[i].second)/2.0 - arithMean), 2.0) * b[i];
	}
	return sum/sumNi(b);
}

double sigma(vector<pair<double,double>> a, vector<int> b)
{
	return pow(dispersion(a, b), 0.5);
}

vector<double> nPi(vector<pair<double,double>> a, vector<int> b)
{
	double parameterA = mean(a, b) - sqrt(3.0) * sigma(a, b), parameterB = mean(a, b) + sqrt(3.0) * sigma(a, b);
	vector<double> c;
	double sumNI = sumNi(b), f = 1.0 / (parameterB - parameterA);
	c.push_back(sumNI * f * (a[0].second - parameterA));
	cout.precision(3);
	cout << "p(i)\t        ";
	string l = "", r = "  ";
	cout << fixed << setw(4) << l << f * (a[0].second - parameterA) << r;
	for(int i = 1; i < n - 1; i++)
	{
		c.push_back(sumNI * f * (a[i].second - a[i].first));
		cout << fixed << setw(4) << l << f * (a[i].second - a[i].first) << r;
	}
	c.push_back(sumNI * f * (parameterB - a[n-1].first));
	cout << fixed << setw(4) << l << f * (parameterB - a[n-1].first) << r << endl;

	return c;
}

double KsiEmpir(vector<pair<double,double>> a, vector<int> b)
{
	double sum = 0.0;
	vector<double> c = nPi(a, b);
	cout << "np(i)\t       ";
	string l = "", r = " ";
	for(int i = 0; i < n; i++)
	{
		cout << setw(4) << l << c[i] << r;
		sum += pow((b[i] - c[i]), 2.0) / c[i];
	}
	return sum;
}

void main()
{
	setlocale(LC_ALL, "Ukrainian");
	system("mode con cols=85 lines=25");
	ifstream in("in.txt");
	vector<pair<double,double>> intervals;
	vector<int> frequency;
	read(intervals, frequency, in);
	print(intervals, frequency);
	double ksiEmpir = KsiEmpir(intervals, frequency);
	if(abs(ksiEmpir) < KsiKryt)
	{
		cout << endl << endl << "|X_емпiричне| < Х_критичне\t" << ksiEmpir << " < " << KsiKryt << endl << "Гiпотезу приймаємо! Генеральна сукупнiсть керується рiвномiрним законом." << endl << endl;
	}
	else
	{
		cout << endl << endl << "|X_емпiричне| > Х_критичне\t" << ksiEmpir << " > " << KsiKryt << endl << "Гiпотезу не приймаємо! Генеральна сукупнiсть не керується рiвномiрним законом." << endl << endl;
	}
	vector<double> d = nPi(intervals, frequency);
	double sum = 0.0;
	for(int i = 0; i<n; i++) sum += d[i];
	cout << sum << endl;
	system("pause");
	
}