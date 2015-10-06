#include "stdafx.h"
#include "CppUnitTest.h"
#include "StackOnArray.h"
#include "StackOnList.h"
#include "CalculateExpression.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTestsForStackOnList
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		/*TEST_METHOD(TestDefaultConstructorInStackOnArray)
		{
			StackOnArray<int> testStack;
			Assert::IsTrue(testStack.Empty());
		}

		TEST_METHOD(TestCopyConstructorInStackOnArray)
		{
			StackOnArray<int> testStack;
			testStack.Push(1);
			testStack.Push(2);
			testStack.Push(3);
			StackOnArray<int> testStack2 = testStack;
			Assert::AreEqual(testStack, testStack2);
		}*/

		TEST_METHOD(TestMethodIsEmptyInStackOnArray)
		{
			StackOnArray<int> testStack;
			Assert::IsTrue(testStack.Empty());
		}

		TEST_METHOD(TestMethodPushInStackOnArray)
		{
			StackOnArray<int> testStack;
			testStack.Push(1);
			Assert::IsFalse(testStack.Empty());
		}

		TEST_METHOD(TestMethodPopInStackOnArray)
		{
			StackOnArray<int> testStack;
			testStack.Push(1);
			testStack.Pop();
			Assert::IsTrue(testStack.Empty());
		}

		TEST_METHOD(TestMethodPopInStackOnArray2)
		{
			StackOnArray<int> testStack;
			testStack.Push(1);
			Assert::AreEqual(testStack.Pop(), 1);
		}

		/*******************************************************************/

		TEST_METHOD(TestMethodIsEmptyInStackOnList)
		{
			StackOnList<int> testStack;
			Assert::IsTrue(testStack.Empty());
		}

		TEST_METHOD(TestMethodPushInStackOnList)
		{
			StackOnList<int> testStack;
			testStack.Push(1);
			Assert::IsFalse(testStack.Empty());
		}

		TEST_METHOD(TestMethodPopInStackOnList)
		{
			StackOnList<int> testStack;
			testStack.Push(1);
			testStack.Pop();
			Assert::IsTrue(testStack.Empty());
		}

		TEST_METHOD(TestMethodPopInStackOnList2)
		{
			StackOnList<int> testStack;
			testStack.Push(1);
			Assert::AreEqual(testStack.Pop(), 1);
		}

		/*************************************************/

		TEST_METHOD(TestMethodStringToDoubleInCalculateExpression)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.StringToDouble("-1.5"),-1.5);
		}

		TEST_METHOD(TestMethodPriorityInCalculateExpression)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.Priority('+'),1);
		}

		TEST_METHOD(TestMethodPriorityInCalculateExpression2)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.Priority('-'),1);
		}

		TEST_METHOD(TestMethodPriorityInCalculateExpression3)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.Priority('*'),2);
		}

		TEST_METHOD(TestMethodPriorityInCalculateExpression4)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.Priority('/'),2);
		}

		TEST_METHOD(TestMethodPriorityInCalculateExpression5)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.Priority('^'),3);
		}
		
		TEST_METHOD(TestMethodIsOperationInCalculateExpression)
		{
			CalculateExpression testCE;
			Assert::IsTrue(testCE.IsOperation('+'));
		}

		TEST_METHOD(TestMethodIsOperationInCalculateExpression2)
		{
			CalculateExpression testCE;
			Assert::IsTrue(testCE.IsOperation('-'));
		}

		TEST_METHOD(TestMethodIsOperationInCalculateExpression3)
		{
			CalculateExpression testCE;
			Assert::IsTrue(testCE.IsOperation('*'));
		}

		TEST_METHOD(TestMethodIsOperationInCalculateExpression4)
		{
			CalculateExpression testCE;
			Assert::IsTrue(testCE.IsOperation('/'));
		}

		TEST_METHOD(TestMethodIsOperationInCalculateExpression5)
		{
			CalculateExpression testCE;
			Assert::IsTrue(testCE.IsOperation('^'));
		}

		TEST_METHOD(TestMethodIsOperationInCalculateExpression6)
		{
			CalculateExpression testCE;
			Assert::IsFalse(testCE.IsOperation('0'));
		}

		TEST_METHOD(TestMethodIsNumberInCalculateExpression)
		{
			CalculateExpression testCE;
			Assert::IsFalse(testCE.IsNumber("+"));
		}

		TEST_METHOD(TestMethodIsNumberInCalculateExpression2)
		{
			CalculateExpression testCE;
			Assert::IsTrue(testCE.IsNumber("1"));
		}

		TEST_METHOD(TestMethodIsNumberInCalculateExpression3)
		{
			CalculateExpression testCE;
			Assert::IsTrue(testCE.IsNumber("-1.25"));
		}
		
		TEST_METHOD(TestMethodProcessOpInCalculateExpression)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.ProcessOp('+', 3, 2), 5.0);
		}

		TEST_METHOD(TestMethodProcessOpInCalculateExpression2)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.ProcessOp('-', 3, 2), 1.0);
		}

		TEST_METHOD(TestMethodProcessOpInCalculateExpression3)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.ProcessOp('*', 3, 2), 6.0);
		}

		TEST_METHOD(TestMethodProcessOpInCalculateExpression4)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.ProcessOp('/', 3, 2), 1.5);
		}

		TEST_METHOD(TestMethodProcessOpInCalculateExpression5)
		{
			CalculateExpression testCE;
			Assert::AreEqual(testCE.ProcessOp('^', 3, 2), 9.0);
		}

		
		/*TEST_METHOD(TestMethodParseInCalculateExpression)
		{
			CalculateExpression testCE("-1+2*3-(-1.25^3+7*11)+12^2");
			string arr[19] = {"-1", "+", "2", "*", "3", "-", "(", "-1.25", "^", "3", "+", "7", "*", "11", ")", "+", "12", "^", "2"};
			vector<string> forCompare(arr, arr+20);
			Assert::AreEqual(testCE.Parse(), forCompare);
		}*/
		
		TEST_METHOD(TestMethodCalculationInCalculateExpression)
		{
			CalculateExpression testCE("-1+2*3-(-1.25^3+7*11)+12^2");
			Assert::AreEqual(testCE.Calculation(), 73.953125);
		}

	};
}