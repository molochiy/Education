#include <iostream>

using namespace std;

template <typename TypeKey, typename TypeBody>
struct ElementInfo
{
	// key of element
	TypeKey key;

	// body of element
	TypeBody body;

	// pointer to next element
	ElementInfo *next;

	// default constructor
	ElementInfo():
		key(NULL), 
		body(NULL), 
		next(this)
	{
	}

	// Constructor with parameters
	ElementInfo(TypeKey newKey, TypeBody newBody, ElementInfo *newNext):
		key(newKey),
		body(newBody),
		next(newNext)
	{
	}

	// Copy costructor
	ElementInfo(const ElementInfo& newElementInfo):
		key(newElementInfo.key),
		body(newElementInfo.body),
		next(newElementInfo.next)
	{
	}
};

template <typename TypeKey, typename TypeBody>
class Table
{
private:
	// elements of table
	ElementInfo<TypeKey, TypeBody>* pElements;

public:
	// default constructor
	Table()
	{
		this->pElements = new ElementInfo<TypeKey, TypeBody>();
	}

	// destructor
	~Table()
	{
		ElementInfo<TypeKey, TypeBody>* currPointer = pElements->next;
		ElementInfo<TypeKey, TypeBody>* prevPointer = pElements->next;
		while(currPointer != pElements)
		{
			currPointer = currPointer->next;
			delete prevPointer;
			prevPointer = currPointer;
		}
		delete currPointer;
	}

	// add element to table
	void AddElement(TypeKey key, TypeBody body)
	{
		bool exist = false;
		ElementInfo<TypeKey, TypeBody>* p = pElements;
		while(p->next != pElements)
		{
			p = p->next;
			if(p->key == key)
			{
				exist = true;
			}
		}
		if(!exist)
		{
			ElementInfo<TypeKey, TypeBody>* element = new ElementInfo<TypeKey, TypeBody>(key, body, pElements);
			p->next = element;
		}
	}

	// overloading operator>>
	friend istream& operator>>(istream& in, Table& table)
	{
		int amount;
		in >> amount;
		for(int i = 1; i <= amount; i++)
		{
			TypeKey tempKey;
			TypeBody tempBody;
			in >> tempKey >> tempBody;
			table.AddElement(tempKey, tempBody);
		}
		return in;
	}

	// overloading operator<<
	friend ostream& operator<<(ostream& out, Table& table)
	{
		ElementInfo<TypeKey, TypeBody>* p = table.pElements->next;
		while(p != table.pElements)
		{
			out << p->key << ' ' << p->body << endl;
			p = p->next;
		}
		return out;
	}

	// replace element in table with key if it exist
	void Replace(TypeKey key, TypeBody body)
	{
		ElementInfo<TypeKey, TypeBody>* p = pElements->next;
		while(p != pElements)
		{
			if( p->key == key )
			{
				p->body = body;
				break;
			}
			p = p->next;
		}
	}

	// erase element from table with key
	void Erase(TypeKey key)
	{
		ElementInfo<TypeKey, TypeBody>* p = pElements;
		do
		{
			if( p->next->key == key )
			{
				p->next = p->next->next;
				break;
			}
			p = p->next;
		}
		while(p != pElements);
	}

	// find element in table with key, if it exist - returt its body
	TypeBody Find(TypeKey key)
	{
		bool exist = false;
		ElementInfo<TypeKey, TypeBody>* p = pElements;
		while(p->next != pElements)
		{
			p = p->next;
			if(p->key == key)
			{
				exist = true;
				return p->body;
				break;
			}
		}
		if(!exist)
		{
			throw logic_error("Element with this key not exist.");
		}
	}
};