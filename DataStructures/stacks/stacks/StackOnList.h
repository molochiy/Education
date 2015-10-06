#pragma once
#include <iostream>
#include <list>

using namespace std;

//stack implemented on the list
template <typename T>
class StackOnList
{
private:
	list<T> elements;

public:

	//method returns true when the stack is empty, otherwise - false
	bool Empty()
	{
		return this->elements.empty();
	}

	//method add element to stack
	void Push(T element)
	{
		this->elements.push_back(element);
	}

	//method delete last elemment in stack and return it
	T Pop()
	{
		if (this->elements.empty()) throw range_error("Stack is Empty!");
		T temp = this->elements.back();
		this->elements.pop_back();
		return temp;
	}
};