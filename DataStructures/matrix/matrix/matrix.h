#pragma once
#include <iostream>
#include <list>
#include <vector>
#include <string>

using namespace std;

struct ElementInfo
{
	double value;
	int row;
	int column;

	ElementInfo():
		value(0.0),
		row(0),
		column(0)
	{
	}

	ElementInfo(double newValue, int newRow, int newColumn):
		value(newValue),
		row(newRow),
		column(newColumn)
	{
	}

	ElementInfo(const ElementInfo& newElementInfo):
		value(newElementInfo.value),
		row(newElementInfo.row),
		column(newElementInfo.column)
	{
	}

};

class SparseMatrix
{
private:
	int amountOfRows;
	int amountOfColumns;
	list<ElementInfo> elementsOfSparseMatrix;

	list<ElementInfo>::iterator existElement(int row, int column)
	{
		list<ElementInfo>::iterator iteratorToElementsOfSparseMatrix = this->elementsOfSparseMatrix.begin();
		for(iteratorToElementsOfSparseMatrix; iteratorToElementsOfSparseMatrix != this->elementsOfSparseMatrix.end(); iteratorToElementsOfSparseMatrix++)
		{
			if((iteratorToElementsOfSparseMatrix->row == row) && (iteratorToElementsOfSparseMatrix->column == column))
			{
				return iteratorToElementsOfSparseMatrix;
			}
		}
		return this->elementsOfSparseMatrix.end();
	}


public:

	SparseMatrix():
		amountOfRows(0),
		amountOfColumns(0),
		elementsOfSparseMatrix()
	{
	}

	SparseMatrix(int newamountOfRows, int newamountOfColumns):
		amountOfRows(newamountOfRows),
		amountOfColumns(newamountOfColumns)
	{
	}

	SparseMatrix(vector<vector<double>>& matrix)
	{
		this->amountOfRows = matrix.size();
		this->amountOfColumns = matrix[0].size();
		for(int i = 0; i < amountOfRows; i++)
		{
			for(int j = 0; j < amountOfColumns; j++)
			{
				if(matrix[i][j] != 0.0)
				{
					this->elementsOfSparseMatrix.push_back(ElementInfo(matrix[i][j], i+1, j+1));
				}
			}
		}
	}

	SparseMatrix(const SparseMatrix& newSparseMatrix):
		amountOfRows(newSparseMatrix.amountOfRows),
		amountOfColumns(newSparseMatrix.amountOfColumns),
		elementsOfSparseMatrix(newSparseMatrix.elementsOfSparseMatrix)
	{
	}

	SparseMatrix Addition(SparseMatrix secondSparseMatrix)
	{
		if ((this->amountOfRows != secondSparseMatrix.amountOfRows) || (this->amountOfColumns != secondSparseMatrix.amountOfColumns))
		{
			throw range_error("Matrix sizes are not equal!");
		}

		SparseMatrix resultOfAdditionMatrix(this->amountOfRows, this->amountOfColumns);

		for(int numberRow = 1; numberRow <= this->amountOfRows; numberRow++)
		{
			for(int numberColumn = 1; numberColumn <= this->amountOfColumns; numberColumn++)
			{
				if((this->existElement(numberRow, numberColumn) != this->elementsOfSparseMatrix.end()) && (secondSparseMatrix.existElement(numberRow, numberColumn) != secondSparseMatrix.elementsOfSparseMatrix.end()))
				{
					resultOfAdditionMatrix.elementsOfSparseMatrix.push_back(ElementInfo(this->existElement(numberRow, numberColumn)->value + secondSparseMatrix.existElement(numberRow, numberColumn)->value, numberRow, numberColumn));
				}
				else
				{
					if (this->existElement(numberRow, numberColumn) != this->elementsOfSparseMatrix.end())
					{
						resultOfAdditionMatrix.elementsOfSparseMatrix.push_back(ElementInfo(this->existElement(numberRow, numberColumn)->value, numberRow, numberColumn));
					}
					else
					{
						if (secondSparseMatrix.existElement(numberRow, numberColumn) != secondSparseMatrix.elementsOfSparseMatrix.end())
						{
							resultOfAdditionMatrix.elementsOfSparseMatrix.push_back(ElementInfo(secondSparseMatrix.existElement(numberRow, numberColumn)->value, numberRow, numberColumn));
						}
					}
				}
			}
		}
		return resultOfAdditionMatrix;
	}

	SparseMatrix Subtraction(SparseMatrix secondSparseMatrix)
	{
		if ((this->amountOfRows != secondSparseMatrix.amountOfRows) || (this->amountOfColumns != secondSparseMatrix.amountOfColumns))
		{
			throw range_error("Matrix sizes are not equal!");
		}

		SparseMatrix resultOfSubtractionMatrix(this->amountOfRows, this->amountOfColumns);

		for(int numberRow = 1; numberRow <= this->amountOfRows; numberRow++)
		{
			for(int numberColumn = 1; numberColumn <= this->amountOfColumns; numberColumn++)
			{
				if((this->existElement(numberRow, numberColumn) != this->elementsOfSparseMatrix.end()) && (secondSparseMatrix.existElement(numberRow, numberColumn) != secondSparseMatrix.elementsOfSparseMatrix.end()))
				{
					if((this->existElement(numberRow, numberColumn)->value - secondSparseMatrix.existElement(numberRow, numberColumn)->value) != 0.0)
					{
						resultOfSubtractionMatrix.elementsOfSparseMatrix.push_back(ElementInfo(this->existElement(numberRow, numberColumn)->value - secondSparseMatrix.existElement(numberRow, numberColumn)->value, numberRow, numberColumn));
					}
				}
				else
				{
					if (this->existElement(numberRow, numberColumn) != this->elementsOfSparseMatrix.end())
					{
						resultOfSubtractionMatrix.elementsOfSparseMatrix.push_back(ElementInfo(this->existElement(numberRow, numberColumn)->value, numberRow, numberColumn));
					}
					else
					{
						if ( secondSparseMatrix.existElement(numberRow, numberColumn) != secondSparseMatrix.elementsOfSparseMatrix.end())
						{
							resultOfSubtractionMatrix.elementsOfSparseMatrix.push_back(ElementInfo((-1.0)*secondSparseMatrix.existElement(numberRow, numberColumn)->value, numberRow, numberColumn));
						}
					}
				}
			}
		}
		return resultOfSubtractionMatrix;
	}

	SparseMatrix Multiplication(SparseMatrix secondSparseMatrix)
	{
		if (this->amountOfColumns != secondSparseMatrix.amountOfRows)
		{
			throw range_error("Matrix sizes are incorect!");
		}

		SparseMatrix resultOfMultiplicationMatrix(this->amountOfRows, secondSparseMatrix.amountOfColumns);

		for(list<ElementInfo>::iterator iteratorToElementsOfSparseMatrix = this->elementsOfSparseMatrix.begin(); iteratorToElementsOfSparseMatrix != this->elementsOfSparseMatrix.end(); iteratorToElementsOfSparseMatrix++)
		{
			for(int numberColumn = 1; numberColumn <= secondSparseMatrix.amountOfColumns; numberColumn++)
				{
					if(secondSparseMatrix.existElement(iteratorToElementsOfSparseMatrix->column, numberColumn) != secondSparseMatrix.elementsOfSparseMatrix.end())
					{
						if(resultOfMultiplicationMatrix.existElement(iteratorToElementsOfSparseMatrix->row, numberColumn) == resultOfMultiplicationMatrix.elementsOfSparseMatrix.end())
						{
							resultOfMultiplicationMatrix.elementsOfSparseMatrix.push_back(ElementInfo(iteratorToElementsOfSparseMatrix->value * secondSparseMatrix.existElement(iteratorToElementsOfSparseMatrix->column, numberColumn)->value, iteratorToElementsOfSparseMatrix->row, numberColumn));
						}
						else
						{
							resultOfMultiplicationMatrix.existElement(iteratorToElementsOfSparseMatrix->row, numberColumn)->value += iteratorToElementsOfSparseMatrix->value * secondSparseMatrix.existElement(iteratorToElementsOfSparseMatrix->column, numberColumn)->value;
						}
					}
				}
		}
		return resultOfMultiplicationMatrix;
	}

	bool operator == (const SparseMatrix& right) const
	{
		SparseMatrix forCompare(right);
		if((this->elementsOfSparseMatrix.size() != right.elementsOfSparseMatrix.size()) || (this->amountOfRows != right.amountOfRows) || (this->amountOfColumns != right.amountOfColumns)) return false;

		for(auto it = this->elementsOfSparseMatrix.begin(); it != this->elementsOfSparseMatrix.end(); it++)
		{
			if((forCompare.existElement(it->row, it->column) != forCompare.elementsOfSparseMatrix.end()) && (it->value != forCompare.existElement(it->row, it->column)->value))
			{
				return false;
			}
			else
			{
				if(forCompare.existElement(it->row, it->column) == forCompare.elementsOfSparseMatrix.end())
				{
					return false;
				}
			}
		}
		return true;
	}

	friend ostream& operator <<(ostream& os, SparseMatrix& sm)
	{
		for(int numberRow = 1; numberRow <= sm.amountOfRows; numberRow++)
		{
			for(int numberColumn = 1; numberColumn <= sm.amountOfColumns; numberColumn++)
			{
				if(sm.existElement(numberRow, numberColumn) != sm.elementsOfSparseMatrix.end())
				{
					os << sm.existElement(numberRow, numberColumn)->value << ' ';
				}
				else
				{
					os << "0 ";
				}
			}
			os << endl;
		}
		return os;
	}
};