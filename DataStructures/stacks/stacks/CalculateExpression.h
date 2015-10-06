#include <iostream>
#include "StackOnArray.h"
#include "StackOnList.h"
#include <vector>
#include <string>

using namespace std;

class CalculateExpression
{
private:
	string expression;
public:

	//default constructor
	CalculateExpression():expression(""){}

	//constructor conversion
	CalculateExpression(string e):expression(e){}

	//copy constructor
	CalculateExpression(CalculateExpression &e):expression(e.expression){}

	//method converts string to number and return it
	double StringToDouble(string s)
	{
		double number = 0.0;
		int grade = 0, i = s.length() - 1, k = 1;
		bool f = false;
		while(i >= 0)
		{
			if (s[i] == '.') 
			{
					grade = s.length() - i - 1;
					i--;
			}
			else if (s[i] == '-')
				 {
					f = true;
					i--;
				 }
			else 
			{
					number += (s[i] - 48) * k;
					i--; 
					k *= 10;
			}
		}
		if (f) return - number / pow(10, grade);
		else return number / pow(10.0, grade);
	}

	//method return priority of operation
	int Priority(char op)
	{
		return op == '+' || op == '-' ? 1 :
			   op == '*' || op == '/' ? 2 :
			   op == '^' ? 3 : -1;
	}

	//method return true when symbol is operation, otherwise - false
	bool IsOperation(char c)
	{
		return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
	}

	//method return true when string is number, otherwise - false
	bool IsNumber(string s)
	{
		return s.length() > 1 ? true :
			   s[0] >= '0' && s[0] <= '9' ? true : false;
	}

	//method returns the result of the operation op on numbers a and b
	double ProcessOp(char op, double a, double b)
	{
		switch (op) 
		{
			case '+':  return a + b;  break;
			case '-':  return a - b;  break;
			case '*':  return a * b;  break;
			case '/':  return a / b;  break;
			case '^':  return pow(a, b);  break;
		}
	}

	//method that parse mathematical expression 
	vector<string> Parse()
	{
		vector<string> result;
		string temp = "";
		int i = 0;
		while(i < this->expression.length())
		{
			if ((this->expression[i] == '-') && (((i == 0) || ((this->expression[i+1] < '0' || this->expression[i-1] > '9') && this->expression[i+1] >= '0' && this->expression[i+1] <= '9')) || (this->expression[i-1] == '('))) 
			{
					temp += this->expression[i];
					i++;
					while((this->expression[i] >= '0' && this->expression[i] <= '9') || this->expression[i] == '.') 
					{
							temp += this->expression[i];
							i++;
					}
					result.push_back(temp);
					temp = "";
			}
			else
			{
				if (this->expression[i] >= '0' && this->expression[i] <= '9') 
				{
					temp += this->expression[i];
					i++;
					while(this->expression[i] >= '0' && this->expression[i] <= '9' || this->expression[i] == '.') 
					{
							temp += this->expression[i];
							i++;
					}
					result.push_back(temp);
					temp = "";
				}
				else if (IsOperation(this->expression[i]) || this->expression[i] == '(' || this->expression[i] == ')')
				{
						temp += this->expression[i];
						result.push_back(temp);
						i++;
						temp = "";
				}
			}
		}
//for( int i = 0; i < result.size(); i++) cout << result[i] << endl;	cout << endl;
		return result;
	}

	//method calculates mathematical expression and retur result
	double Calculation()
	{
		vector<string> vectorWithExpression = this->Parse();
		StackOnList<char> operations;
		StackOnList<double> numbers;
		char tempOperation;
		double number1 = 0.0, number2 = 0.0;
		for(int i = 0; i < vectorWithExpression.size(); i++)
		{
			if (this->IsNumber(vectorWithExpression[i])) numbers.Push(this->StringToDouble(vectorWithExpression[i]));
			else
			{
				if (this->IsOperation(vectorWithExpression[i][0]))
				{
					if (operations.Empty()) operations.Push(vectorWithExpression[i][0]);
					else
					{
						tempOperation = operations.Pop();
						if ((this->Priority(vectorWithExpression[i][0]) > this->Priority(tempOperation)) || (tempOperation == '(')) 
						{
							operations.Push(tempOperation);
							operations.Push(vectorWithExpression[i][0]);
						}
						else
						{
							do
							{
								number2 = numbers.Pop();
								number1 = numbers.Pop();
//cerr << "1.\t" << number1 << tempOperation << number2 << endl;
								numbers.Push(this->ProcessOp(tempOperation, number1, number2));
								tempOperation = operations.Pop();
							} 
							while(this->Priority(vectorWithExpression[i][0]) <= this->Priority(tempOperation) && (!operations.Empty()));
							operations.Push(tempOperation);
							operations.Push(vectorWithExpression[i][0]);
						}
					}
				}
				else
				{
					if (vectorWithExpression[i][0] == '(') 
					{
						operations.Push(vectorWithExpression[i][0]);
					}
					if (vectorWithExpression[i][0] == ')')
					{
						tempOperation = operations.Pop();
						while (tempOperation != '(')
						{							
							number2 = numbers.Pop();
							number1 = numbers.Pop();
//cerr << "2.\t" <<  number1 << tempOperation << number2 << endl;
							numbers.Push(this->ProcessOp(tempOperation, number1, number2));
							tempOperation = operations.Pop();
						}					
					}
				}
			}
		}
		do
		{
			number1 = numbers.Pop();
			if(numbers.Empty())
			{
				tempOperation = operations.Pop();
				if((operations.Empty()) && (tempOperation == '-'))
				{
					numbers.Push(-1*number1);
				}
				else
				{
					operations.Push(tempOperation);
					numbers.Push(number1);
				}
			}
			else
			{
				numbers.Push(number1);
				tempOperation = operations.Pop();
				number2 = numbers.Pop();
				number1 = numbers.Pop();
//cerr << "3.\t" <<  number1 << tempOperation << number2 << endl;
				numbers.Push(this->ProcessOp(tempOperation, number1, number2));
			}
		}
		while (!operations.Empty());

		return numbers.Pop();
	}
};