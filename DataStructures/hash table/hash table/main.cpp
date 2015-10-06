#include <iostream>
#include "hashTable.h"

using namespace std;

void main()
{
	HashTable<int, double> t;
	t.AddElement(1, 2.5);
	t.AddElement(10, 3.5);
	t.AddElement(10, 4.5);
	t.AddElement(-5, 5.5);
	t.AddElement(-100, 6.5);
	cout << t << endl;
	t.Replace(1, 10);
	cout << endl << endl << t << endl;
	t.Remove(10);
	cout << endl << endl << t << endl << endl << t.Find(1) << endl;
	system("pause");
}