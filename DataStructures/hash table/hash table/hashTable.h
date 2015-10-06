#include <iostream>
#include <string>
#include <sstream>

using namespace std;

template <typename TypeKey, typename TypeBody>
struct ElementInfo
{
	// key of element
	TypeKey key;

	// body of element
	TypeBody body;

	// pointer to next element
	ElementInfo* next;

	// default constructor
	ElementInfo():
		key(), 
		body(), 
		next(this)
	{
	}

	// Constructor with parameters
	ElementInfo(TypeKey newKey, TypeBody newBody, ElementInfo* newNext):
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
class HashTable
{
private:
	// elements of HashTable
	ElementInfo<TypeKey, TypeBody>** elementsOfHashTable;

	// amount of hash values
	static const int N = 100;

public:
	// default constructor
	HashTable()
	{
		this->elementsOfHashTable = new ElementInfo<TypeKey, TypeBody>* [N];
		for(int i = 0; i < N; i++)
		{
			this->elementsOfHashTable[i] = new ElementInfo<TypeKey, TypeBody>();
		}
	}

	// destructor
	~HashTable()
	{
		for(int i = 0; i < N; i++)
		{
			ElementInfo<TypeKey, TypeBody>* prevPointer = this->elementsOfHashTable[i]->next;
			ElementInfo<TypeKey, TypeBody>* currPointer = this->elementsOfHashTable[i]->next;
			while(currPointer != this->elementsOfHashTable[i])
			{
				currPointer = currPointer->next;
				delete prevPointer;
				prevPointer = currPointer;
			}
			delete currPointer;
		}
		delete[] this->elementsOfHashTable;
	}

	// converting TypeKey to String
	string toString(TypeKey key)
	{
		stringstream ss;
		string result;
		ss << key;
		ss >> result;
		return result;
	}

	// obtain hash from key
	int getHash(TypeKey key)
	{
		string stringKey = toString(key);
		int hash = 10;
		for(int i = 0 ; i < stringKey.length(); i++)
		{
			hash = ((hash << 3) + hash) + stringKey[i];
		}
		return hash;
	}

	// add element to HashTable
	void AddElement(TypeKey key, TypeBody body)
	{
		int index = getHash(key) % N;
		ElementInfo<TypeKey, TypeBody>* currPointer = elementsOfHashTable[index];
		bool exist = false;
		while (currPointer->next != elementsOfHashTable[index])
		{
			currPointer = currPointer->next;
			if(currPointer->key == key)
			{
				exist = true;
			}
		}
		if(!exist)
		{
			ElementInfo<TypeKey, TypeBody>* element = new ElementInfo<TypeKey, TypeBody>(key, body, elementsOfHashTable[index]);
			currPointer->next = element;
		}
	}

	// overloading operator>>
	friend istream& operator>>(istream& in, HashTable& HashTable)
	{
		int amount;
		in >> amount;
		for(int i = 1; i <= amount; i++)
		{
			TypeKey tempKey;
			TypeBody tempBody;
			in >> tempKey >> tempBody;
			HashTable.AddElement(tempKey, tempBody);
		}
		return in;
	}

	// overloading operator<<
	friend ostream& operator<<(ostream& out, HashTable& HashTable)
	{
		for(int i = 0; i < N; i++)
		{
			ElementInfo<TypeKey, TypeBody>* currPointer = HashTable.elementsOfHashTable[i];
			if(currPointer->next != HashTable.elementsOfHashTable[i])
			{
				out << i << ".\t";
			}
			while(currPointer->next != HashTable.elementsOfHashTable[i])
			{
				currPointer = currPointer->next;
				out << currPointer->key << ' ' << currPointer->body << endl;
				//currPointer = currPointer->next;
			}
		}
		return out;
	}

	// replace element in HashTable with key if it exist
	void Replace(TypeKey key, TypeBody body)
	{
		int index = getHash(key) % N;
		ElementInfo<TypeKey, TypeBody>* currPointer = elementsOfHashTable[index];
		while (currPointer->next != elementsOfHashTable[index])
		{
			currPointer = currPointer->next;
			if(currPointer->key == key)
			{
				currPointer->body = body;
				break;
			}
		}
	}

	// erase element from HashTable with key
	void Remove(TypeKey key)
	{
		int index = getHash(key) % N;
		ElementInfo<TypeKey, TypeBody>* currPointer = elementsOfHashTable[index];
		do
		{
			if(currPointer->next->key == key)
			{
				ElementInfo<TypeKey, TypeBody>* tempPointer = currPointer->next;
				currPointer->next = currPointer->next->next;
				delete tempPointer;
				break;
			}
			currPointer = currPointer->next;
		}
		while (currPointer != elementsOfHashTable[index]);
	}

	// find element in HashTable with key, if it exist - returt its body
	TypeBody Find(TypeKey key)
	{
		int index = getHash(key) % N;
		ElementInfo<TypeKey, TypeBody>* currPointer = elementsOfHashTable[index];
		bool exist = false;
		while (currPointer->next != elementsOfHashTable[index])
		{
			currPointer = currPointer->next;
			if(currPointer->key == key)
			{
				exist = true;
				return currPointer->body;
			}
		}
		if(!exist)
		{
			throw logic_error("Element with this key not exist.");
		}
	}
};