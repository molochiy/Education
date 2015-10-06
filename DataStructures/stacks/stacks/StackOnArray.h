#pragma once
#include <iostream>

using namespace std;

//stack implemented on the list
template <typename T>
class StackOnArray
{
private:
	int size;
	T *elements;
public:

	//default constructor
	StackOnArray():size(0), elements(new T[size]){}

	//copy constructor
	StackOnArray(StackOnArray &S):size(S.size), elements(new T[S.size])
	{
		for(int i = 0; i < S.size; i++)
		elements[i] = S.elements[i];
	}

	//destructor
	~StackOnArray()
	{
		delete []elements;
	}

	//method returns true when the stack is empty, otherwise - false
	bool Empty()
	{
		return this->size == 0;
	}

	//method add element to stack
	void Push(T element)
	{
		this->size++;
		T* temp = new T[this->size];
		for(int i = 0; i < this->size-1; i++) temp[i] = this->elements[i];
		temp[this->size-1] = element;
		delete this->elements;
		this->elements = temp;
	}

	//method delete last elemment in stack and return it
	T Pop()
	{
			if ( this->size == 0 ) throw range_error("Stack is empty!"); 
			return this->elements[--(this->size)];
	}
};