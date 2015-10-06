#include "stdafx.h"
#include "CppUnitTest.h"
#include "matrix.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTestForSparseMatrix
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(TestMethodAddition)
		{
			double arrayA[3][3] = {{1,0,3}, {0,4,6}, {3,0,0}};
			double arrayB[3][3] = {{0,0,1}, {0,2,-3}, {3,0,1}};
			double arrayC[3][3] = {{1,0,4}, {0,6,3}, {6,0,1}};

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

			Assert::IsTrue(a.Addition(b) == c);
		}

		TEST_METHOD(TestMethodSubtraction)
		{
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

			Assert::IsTrue(a.Subtraction(b) == c);
		}

		TEST_METHOD(TestMethodMultiplication)
		{
			double arrayA[3][3] = {{1,0,3}, {0,4,6}, {3,0,0}};
			double arrayB[3][3] = {{0,0,1}, {0,2,-3}, {3,0,1}};
			double arrayC[3][3] = {{9,0,4}, {18,8,-6}, {0,0,3}};

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

			Assert::IsTrue(a.Multiplication(b) == c);
		}

	};
}