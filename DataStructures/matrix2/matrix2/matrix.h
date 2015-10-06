#include <iostream>

using namespace std;

struct ElementInfo
{
	// value of element
	double value;

	// row of element
	int row;

	// column of element
	int column;

	// pointer to next nonzero element in row
	ElementInfo *right;

	// Pointer to next nonzero element in column
	ElementInfo *down;

	// default constructor
	ElementInfo():
		value(0.0),
		row(0),
		column(0),
		right(this),
		down(this)
	{
	}

	// Constructor with parameters
	ElementInfo(double newValue, int newRow, int newColumn, ElementInfo *newRight, ElementInfo *newDown):
		value(newValue),
		row(newRow),
		column(newColumn),
		right(newRight),
		down(newDown)
	{
	}

	// Copy costructor
	ElementInfo(const ElementInfo& newElementInfo):
		value(newElementInfo.value),
		row(newElementInfo.row),
		column(newElementInfo.column),
		right(newElementInfo.right),
		down(newElementInfo.down)
	{
	}

	// Check is element equal to other by indexes
	bool IsEqualByIndexes(const ElementInfo& element)
	{
		return 
			this->row == element.row
			&& this->column == element.column;
	}

	// Check is element less to other by indexes
	bool IsLessByIndexes(const ElementInfo& element)
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

	// Check is element equal to other
	bool IsEqual(const ElementInfo& element)
	{
		return this->row == element.row && this->column == element.column && this->value == element.value;
	}
};

class Matrix
{
	// Number of rows in matrix
	int numberOfRows;

	// Number of columns in matrix
	int numberOfColumns;

	// Array of heading pointers on rows
	ElementInfo** pRows;

	// Array of heading pointers on columns
	ElementInfo** pColumns;

	// Add nonzero element to matrix
	void addElementInEnd(double value, int row, int column)
	{
		if(value != 0)
		{
			ElementInfo* element = new ElementInfo(value, row, column, pRows[row], pColumns[column]);
			ElementInfo* pRow = pRows[row];
			while(pRow->right != pRows[row])
			{
				pRow = pRow->right;
			}
			ElementInfo* pColumn = pColumns[column];
			while(pColumn->down != pColumns[column])
			{
				pColumn = pColumn->down;
			}
			pRow->right = element;
			pColumn->down = element;
		}
	}

	// Allocate memory for pRows and pColumns
	void allocateMemory(int rows, int columns) 
	{
		numberOfRows = rows;
		numberOfColumns = columns;
		pRows = new ElementInfo* [numberOfRows + 1];
		pColumns = new ElementInfo* [numberOfColumns + 1];
		for(int i = 1; i <= numberOfRows; i++)
		{
			pRows[i] = new ElementInfo(); 
		}
		for(int i = 1; i <= numberOfColumns; i++)
		{
			pColumns[i] = new ElementInfo();
		}
	}

public:
	// default constructor
	Matrix():
		numberOfRows(0),
		numberOfColumns(0),
		pRows(nullptr),
		pColumns(nullptr)
	{
	}

	// Constructor with parameters
	Matrix(int rows, int columns):
		numberOfRows(rows),
		numberOfColumns(columns)
	{
		allocateMemory(numberOfRows, numberOfColumns);
	}

	// Copy constructor
	Matrix(const Matrix& matrix)
	{
		this->numberOfRows = 0;
		this->numberOfColumns = 0;
		this->pRows = nullptr;
		this->pColumns = nullptr;
		*this = matrix;
	}

	// destructor
	~Matrix()
	{
		for(int row = 1; row <= this->numberOfRows; row++)
		{
			auto pointerToRow = this->pRows[row]->right;
			auto prevPointer = this->pRows[row]->right;
			while(pointerToRow != this->pRows[row])
			{
				pointerToRow = pointerToRow->right;
				delete prevPointer;				
				prevPointer = pointerToRow;				
			}
			delete pointerToRow;
		}
		
		if(pRows != nullptr)
		{
			delete[] pRows;
			pRows = nullptr;
			delete[] pColumns;
			pColumns = nullptr;
		}
	}

	// Overloading operator>>
	friend istream& operator>>(istream& in, Matrix& matrix)
	{
		int rows, columns;
		in >> rows >> columns;
		matrix.allocateMemory(rows, columns);
		for(int row = 1; row <= matrix.numberOfRows; row++)
		{
			for(int column = 1; column <= matrix.numberOfColumns; column++) 
			{
				double tempValue;				
				in >> tempValue;				
				matrix.addElementInEnd(tempValue, row, column);				
			}

		}
		return in;
	}

	// Overloading operator<<
	friend ostream& operator<<(ostream& out, Matrix& matrix)
	{
		for(int i=1; i <= matrix.numberOfRows; i++) 
		{			
			auto it = matrix.pRows[i]->right;

			while(it != matrix.pRows[i]) 
			{
				out << it->value << " " <<  it->row << " " << it->column << endl;
				it = it->right;
			}
		}
		out << endl;
		return out;
	}

	Matrix& operator=(const Matrix& matrix)
	{
		if(this != &matrix) 
		{
			for(int row = 1; row <= this->numberOfRows; row++)
			{
				auto pointerToRow = this->pRows[row]->right;
				auto prevPointer = this->pRows[row]->right;
				while(pointerToRow != this->pRows[row])
				{
					pointerToRow = pointerToRow->right;
					delete prevPointer;				
					prevPointer = pointerToRow;				
				}
				delete pointerToRow;
			}
		
			if(pRows != nullptr)
			{
				delete[] pRows;
				pRows = nullptr;
				delete[] pColumns;
				pColumns = nullptr;
			}

			allocateMemory(matrix.numberOfRows, matrix.numberOfColumns);		
			for(int row = 1; row <= matrix.numberOfRows; row++)
			{
				auto pointerToRowOfMatrix = matrix.pRows[row]->right;
				while(pointerToRowOfMatrix != matrix.pRows[row])
				{
					this->addElementInEnd(pointerToRowOfMatrix->value, pointerToRowOfMatrix->row, pointerToRowOfMatrix->column);
					pointerToRowOfMatrix = pointerToRowOfMatrix->right;
				}
			}
		}
		return *this;
	}

	// Multiply matrix on scalar
	Matrix MultiplyOnScalar(const double& scalar)
	{		
		Matrix result = Matrix(*this);
		for(int row = 1; row <= result.numberOfRows; row++) 
		{
			auto pointerToRowOfMatrix = result.pRows[row]->right;
			while(pointerToRowOfMatrix != result.pRows[row])
			{
				pointerToRowOfMatrix->value *= scalar;
				pointerToRowOfMatrix = pointerToRowOfMatrix->right;
			}
		}
		return result;
	}

	// Calculate result of adding two matrixes
	Matrix Add(const Matrix& matrix)
	{
		Matrix result = Matrix(max(this->numberOfRows, matrix.numberOfRows), max(this->numberOfColumns, matrix.numberOfColumns));
		for(int row  = 1; row <= result.numberOfRows; row++)
		{
			if(row > this->numberOfRows)
			{
				auto pointerToRowOFSecondMatrix = matrix.pRows[row]->right;
				while(pointerToRowOFSecondMatrix != matrix.pRows[row])
				{
					result.addElementInEnd(pointerToRowOFSecondMatrix->value, pointerToRowOFSecondMatrix->row, pointerToRowOFSecondMatrix->column);
					pointerToRowOFSecondMatrix = pointerToRowOFSecondMatrix->right;
				}
			}
			else
			{
				if(row > matrix.numberOfRows)
				{
					auto pointerToRowOfFirstMatrix = this->pRows[row]->right;
					while(pointerToRowOfFirstMatrix != this->pRows[row])
					{
						result.addElementInEnd(pointerToRowOfFirstMatrix->value, pointerToRowOfFirstMatrix->row, pointerToRowOfFirstMatrix->column);
						pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->right;
					}
				}
				else
				{
					auto pointerToRowOfFirstMatrix = this->pRows[row]->right;
					auto pointerToRowOfSecondMatrix = matrix.pRows[row]->right;

					while(pointerToRowOfFirstMatrix != this->pRows[row] || pointerToRowOfSecondMatrix != matrix.pRows[row])
					{
						if(pointerToRowOfFirstMatrix == this->pRows[row])
						{
							while(pointerToRowOfSecondMatrix != matrix.pRows[row])
							{
								result.addElementInEnd(pointerToRowOfSecondMatrix->value, pointerToRowOfSecondMatrix->row, pointerToRowOfSecondMatrix->column);
								pointerToRowOfSecondMatrix = pointerToRowOfSecondMatrix->right;
							}
						}
						else
							if(pointerToRowOfSecondMatrix == matrix.pRows[row])
							{
								
								while(pointerToRowOfFirstMatrix != this->pRows[row])
								{
									result.addElementInEnd(pointerToRowOfFirstMatrix->value, pointerToRowOfFirstMatrix->row, pointerToRowOfFirstMatrix->column);
									pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->right;
								}
							}
							else
							{
								if(pointerToRowOfFirstMatrix->IsEqualByIndexes(*pointerToRowOfSecondMatrix))
								{
									result.addElementInEnd(pointerToRowOfFirstMatrix->value + pointerToRowOfSecondMatrix->value,	pointerToRowOfFirstMatrix->row, pointerToRowOfFirstMatrix->column);
									pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->right;
									pointerToRowOfSecondMatrix = pointerToRowOfSecondMatrix->right;
								}
								else
									if(pointerToRowOfFirstMatrix->IsLessByIndexes(*pointerToRowOfSecondMatrix))
									{
										result.addElementInEnd(pointerToRowOfFirstMatrix->value, pointerToRowOfFirstMatrix->row, pointerToRowOfFirstMatrix->column);
										pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->right;									
									}
									else 
									{
										result.addElementInEnd(pointerToRowOfSecondMatrix->value, pointerToRowOfSecondMatrix->row, pointerToRowOfSecondMatrix->column);
										pointerToRowOfSecondMatrix = pointerToRowOfSecondMatrix->right;
									}
							}
					}
				}
			}
		}

		return result;
	}

	// Calculate result of subtracting two matrixes
	Matrix Subtract(const Matrix& matrix)
	{
		Matrix copyMatrix = Matrix(matrix);
		return this->Add(copyMatrix.MultiplyOnScalar(-1.0));
	}

	// Calculate result of multiplying two matrixes
	Matrix Multiply(const Matrix& matrix)
	{
		if(this->numberOfColumns != matrix.numberOfRows) 
		{
			throw logic_error("Invalid dimensions of matrixes for multiplying.");
		}

		Matrix result = Matrix(this->numberOfRows, matrix.numberOfColumns);

		for(int row = 1; row <= result.numberOfRows; row++)
		{			
			for(int column = 1; column <= result.numberOfColumns; column++)
			{				
				auto pointerToRowOfFirstMatrix = this->pRows[row]->right;				
				auto pointerToColumnOfSecondMatrix = matrix.pColumns[column]->down;				
				double tempSum = 0;
				while(pointerToRowOfFirstMatrix != this->pRows[row] && pointerToColumnOfSecondMatrix != matrix.pColumns[column])
				{
					if(pointerToRowOfFirstMatrix->column < pointerToColumnOfSecondMatrix->row)
					{
						pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->right;
					}
					else
					{
						if(pointerToRowOfFirstMatrix->column > pointerToColumnOfSecondMatrix->row)
						{
							pointerToColumnOfSecondMatrix = pointerToColumnOfSecondMatrix->down;
						}
						else
						{							
							tempSum += pointerToRowOfFirstMatrix->value * pointerToColumnOfSecondMatrix->value;						
							pointerToRowOfFirstMatrix = pointerToRowOfFirstMatrix->right;
							pointerToColumnOfSecondMatrix = pointerToColumnOfSecondMatrix->down;
						}
					}
				}				
				result.addElementInEnd(tempSum, row, column);
			}
		}

		return result;
	}

	// Check is matrix equal to other
	bool IsEqual(const Matrix& matrix)
	{		
		if(this->numberOfRows != matrix.numberOfRows || this->numberOfColumns != matrix.numberOfColumns)
		{			
			return false;
		}

		for(int row = 1; row <= this->numberOfRows; row++)
		{
			auto pointerToFirstMatrix = this->pRows[row]->right;
			auto pointerToSecondMatrix = matrix.pRows[row]->right;
			while(pointerToFirstMatrix != this->pRows[row] && pointerToSecondMatrix != matrix.pRows[row])
			{
				if(!pointerToFirstMatrix->IsEqual(*pointerToSecondMatrix))
				{
					return false;
				}
				pointerToFirstMatrix = pointerToFirstMatrix->right;
				pointerToSecondMatrix = pointerToSecondMatrix->right;
			}
		}
		return true;
	}
};