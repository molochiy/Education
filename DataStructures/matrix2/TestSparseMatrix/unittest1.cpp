#include "stdafx.h"
#include "CppUnitTest.h"
#include <fstream>
#include <matrix.h>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace TestSparseMatrix
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(TestAdd)
		{
			Matrix a, b, c;
			ifstream in("Add.txt");
			in >> a >> b >> c;
			Assert::IsTrue(a.Add(b).IsEqual(c));
		}

		TEST_METHOD(TestMultiplyOnScalar)
		{
			Matrix a, b;
			ifstream in("MultiplyOnScalar.txt");
			in >> a >> b;
			Assert::IsTrue(a.MultiplyOnScalar(0.5).IsEqual(b));
		}

		TEST_METHOD(TestSubtract)
		{
			Matrix a, b, c;
			ifstream in("Subtract.txt");
			in >> a >> b >> c;
			Assert::IsTrue(a.Subtract(b).IsEqual(c));
		}
		
		TEST_METHOD(TestMultiply)
		{
			Matrix a, b, c;
			ifstream in("Multiply.txt");
			in >> a >> b >> c;
			Assert::IsTrue(a.Multiply(b).IsEqual(c));
		}
	};
}