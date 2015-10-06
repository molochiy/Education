#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void main()
{
	ofstream out("os2.txt");

	string a = "BCCCBCCBCBCCBCCCCCCB", b = "", c = "" , d = "01";
	for(int i=0; i<a.length() ; i++)
	{
		if(a[i]=='B'){ b+="01";  }
		if(a[i]=='C'){ b+="1"; }
	}

	for(int i=0; i<a.length() ; i+=2)
	{
		if(a[i]=='B'&&a[i+1]=='B'){ c+="000"; }
		if(a[i]=='B'&&a[i+1]=='C'){ c+="01"; }

		if(a[i]=='C'&&a[i+1]=='B'){ c+="001"; }
		if(a[i]=='C'&&a[i+1]=='C'){ c+="1"; }
	}

	for(int i=1; i<a.length() ; i++)
	{
		if(a[i-1]=='B'&&a[i]=='B'){ d+="01";  }
		if(a[i-1]=='B'&&a[i]=='C'){ d+="1";  }
		if(a[i-1]=='C'&&a[i]=='B'){ d+="01";  }
		if(a[i-1]=='C'&&a[i]=='C'){ d+="1";  }
	}

	out<< b << ' ' << b.length() << endl << c << ' '<< c.length() << endl << d << ' '<< d.length() << endl;
	system("pause");
}