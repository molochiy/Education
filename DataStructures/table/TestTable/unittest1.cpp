#include "stdafx.h"
#include "CppUnitTest.h"
#include "table.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace TestTable
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(AddElementAndFind)
		{
			Table<int, double> t;
			t.AddElement(1,2.5);
			Assert::AreEqual(t.Find(1),2.5);
		}

		TEST_METHOD(AddElement2)
		{
			Table<int, double> t;
			t.AddElement(1,1);
			t.AddElement(2,2);
			t.AddElement(3,3);
			Assert::IsTrue(t.Find(1) == 1 && t.Find(2) == 2 && t.Find(3) == 3);
		}

		TEST_METHOD(AddElement3)
		{
			Table<int, double> t;
			t.AddElement(1,1);
			t.AddElement(1,2);
			Assert::AreEqual(t.Find(1),1.0);
		}

		TEST_METHOD(Replace)
		{
			Table<int, double> t;
			t.AddElement(1,2.5);
			t.Replace(1,-2.5);
			Assert::AreEqual(t.Find(1),-2.5);
		}

		TEST_METHOD(Erase)
		{
			Table<int, double> t;
			t.AddElement(1,2.5);
			t.Replace(1,-2.5);
			Assert::AreEqual(t.Find(1),-2.5);
		}

		TEST_METHOD(Find)
		{
			Table<int, double> t;
			Assert::ExpectException<logic_error>
			(
				[&] 
				{
					t.AddElement(1, 1.0);
					t.Erase(1);
					t.Find(1);
				}
			);
		}

	};
}