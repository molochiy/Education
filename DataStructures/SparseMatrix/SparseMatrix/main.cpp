#include <iostream>
#include <algorithm>
#include <fstream>

using namespace std;

struct Node
{
	int value;
	int row;
	int column;

	Node* nextRight;
	Node* nextDown;

	Node(int elementRow, int elementColumn, int elementValue, Node* elementNextRight, Node* elementNextDown)
		:
		row(elementRow),
		column(elementColumn),
		value(elementValue),
		nextRight(elementNextRight),
		nextDown(elementNextDown)
	{
	}

	Node()
		:
		row(-1),
		column(-1),
		value(-1),
		nextDown(this),
		nextRight(this)
	{
	}

	bool IsEqualByIndexes(const Node& element)
	{
		return 
			this->row == element.row
			&& this->column == element.column;
	}
	bool IsLessByIndexes(const Node& element)
	{
		if(this->row < element.row) 
		{
				return true;
		}
		if(this->row == element.row && this->column < element.column) 
		{
			return true;
		}
		return false;
	}
};

class SparseMatrix
{
	int numberOfRows;
	int numberOfColumns;
	Node** pRows;
	Node** pColumns;

	void addElement(int row, int column, int value)
	{
		if(value != 0) 
		{
			Node* pRow = pRows[row];
			while(pRow->nextRight != pRows[row]) 
			{
				pRow = pRow->nextRight;
			}
			Node* pColumn = pColumns[column];
			while(pColumn->nextDown!= pColumns[column]) 
			{
				pColumn = pColumn->nextDown;
			}
			Node* element = new Node (row, column, value, pRows[row], pColumns[column]);
			pRow->nextRight = element;
			pColumn->nextDown = element;			
		}
	}

public:
	SparseMatrix(int row, int column)
		:
		numberOfRows(row),
		numberOfColumns(column)
	{
		pRows = new Node* [numberOfRows + 1];
		pColumns = new Node* [numberOfColumns + 1];
		for(int i=1; i <= numberOfRows; i++)
		{
			pRows[i] = new Node(); 
		}
		for(int i=1; i <= numberOfColumns; i++)
		{
			pColumns[i] = new Node();
		}
	}
	SparseMatrix()
		:
		numberOfRows(0),
		numberOfColumns(0)
	{
	}
	friend istream& operator>>(istream& in, SparseMatrix& sparseMatrix)
	{
		in >> sparseMatrix.numberOfRows >> sparseMatrix.numberOfColumns ;
		//allocate memory!!!
		sparseMatrix.pRows = new Node* [sparseMatrix.numberOfRows + 1];
		sparseMatrix.pColumns = new Node* [sparseMatrix.numberOfColumns + 1];
		for(int i=1; i <= sparseMatrix.numberOfRows; i++)
		{
			sparseMatrix.pRows[i] = new Node(); 
		}
		for(int i=1; i <= sparseMatrix.numberOfColumns; i++)
		{
			sparseMatrix.pColumns[i] = new Node();
		}
			
		for(int row=1; row <= sparseMatrix.numberOfRows; row++)
		{
			for(int column=1; column <= sparseMatrix.numberOfColumns; column++) 
			{
				int tempValue;				
				in >> tempValue;				
				sparseMatrix.addElement(row, column, tempValue);				
			}

		}
		return in;
	}

	friend ostream& operator<<(ostream& out, SparseMatrix& sparseMatrix)
	{
		for(int i=1; i <= sparseMatrix.numberOfRows; i++) 
		{
			auto it = sparseMatrix.pRows[i]->nextRight;

			while(it != sparseMatrix.pRows[i]) 
			{
				out << it->row << " " << it->column << " " << it->value << endl;
				it = it->nextRight;
			}
		}

		out << endl;
		for(int i=1; i <= sparseMatrix.numberOfColumns; i++) 
		{
			auto it = sparseMatrix.pColumns[i]->nextDown;
			while(it != sparseMatrix.pColumns[i])
			{
				out << it->row << " " << it->column << " " << it->value << endl;
				it = it->nextDown;
			}
		}
		return out;
	}

	SparseMatrix add(const SparseMatrix& sparseMatrix)
	{
		SparseMatrix result = SparseMatrix(max(this->numberOfRows, sparseMatrix.numberOfRows),
			max(this->numberOfColumns, sparseMatrix.numberOfColumns));

		for(int row = 1; row <= result.numberOfRows; row++)
		{
			if(row > this->numberOfRows)
			{
				auto pointerToRowOFSecondMatrix = sparseMatrix.pRows[row]->nextRight;
				while(pointerToRowOFSecondMatrix != sparseMatrix.pRows[row])
				{
					result.addElement(
						pointerToRowOFSecondMatrix->row,
						pointerToRowOFSecondMatrix->column,
						pointerToRowOFSecondMatrix->value
						);
					pointerToRowOFSecondMatrix = pointerToRowOFSecondMatrix->nextRight;
				}
			}
			else
				if(row > sparseMatrix.numberOfRows)
				{
					auto pointerToRowOfFirstMatrix = this->pRows[row]->nextRight;
					while(pointerToRowOfFirstMatrix != this->pRows[row])
					{
						result.addElement(
							pointerToRowOfFirstMatrix->row,
							pointerToRowOfFirstMatrix->column,
							pointerToRowOfFirstMatrix->value
							);
						pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->nextRight;
					}
				}
				else
				{
					auto pointerToRowOfFirstMatrix = this->pRows[row]->nextRight;
					auto pointerToRowOfSecondMatrix = sparseMatrix.pRows[row]->nextRight;

					while(pointerToRowOfFirstMatrix != this->pRows[row]
					&& pointerToRowOfSecondMatrix != sparseMatrix.pRows[row])
					{
						if(pointerToRowOfFirstMatrix == this->pRows[row])
						{
							while(pointerToRowOfSecondMatrix != sparseMatrix.pRows[row])
							{
								result.addElement(
									pointerToRowOfSecondMatrix->row,
									pointerToRowOfSecondMatrix->column,
									pointerToRowOfSecondMatrix->value
									);
								pointerToRowOfSecondMatrix = pointerToRowOfSecondMatrix->nextRight;
							}
						}
						else
							if(pointerToRowOfSecondMatrix == sparseMatrix.pRows[row])
							{
								cout << "HERE " << row << endl;
								while(pointerToRowOfFirstMatrix != this->pRows[row])
								{
									result.addElement(
										pointerToRowOfFirstMatrix->row,
										pointerToRowOfFirstMatrix->column,
										pointerToRowOfFirstMatrix->value
										);
									pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->nextRight;
								}
							}
							else
							{
								if(pointerToRowOfFirstMatrix->IsEqualByIndexes(*pointerToRowOfSecondMatrix))
								{
									result.addElement(
										pointerToRowOfFirstMatrix->row,
										pointerToRowOfFirstMatrix->column,
										pointerToRowOfFirstMatrix->value + pointerToRowOfSecondMatrix->value
										);
									pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->nextRight;
									pointerToRowOfSecondMatrix = pointerToRowOfSecondMatrix->nextRight;
								}
								else
									if(pointerToRowOfFirstMatrix->IsLessByIndexes(*pointerToRowOfSecondMatrix))
									{
										result.addElement(
											pointerToRowOfFirstMatrix->row,
											pointerToRowOfFirstMatrix->column,
											pointerToRowOfFirstMatrix->value
										);
										pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->nextRight;									
									}
									else 
									{
										result.addElement(
											pointerToRowOfSecondMatrix->row,
											pointerToRowOfSecondMatrix->column,
											pointerToRowOfSecondMatrix->value
											);
										pointerToRowOfSecondMatrix = pointerToRowOfSecondMatrix->nextRight;
									}
							}
					}
				}
		}
		return result;
	}
};
int main() {
	ifstream cin("in.txt");
	SparseMatrix x, y;
	cin >> x >> y;
	//cout << x << endl;

	auto z = x.add(y);

	cout << z << endl;
	system("pause");
	return 0;
}
