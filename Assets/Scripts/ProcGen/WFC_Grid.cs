using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFC_Grid
{
	private int dimension;

	private Cell[,] grid;
	private Rules rules = new Rules();
	private int[][] currentRule;

	const int UP = 0;
	const int RIGHT = 1;
	const int DOWN = 2;
	const int LEFT = 3;
	
	public WFC_Grid(int dim)
	{
		this.dimension = dim;
		grid = new Cell[dimension, dimension];

		//Iterate through grid filling with cells
		for(int row = 0; row < dimension; row++)
		{
			for(int col = 0; col < dimension; col++)
			{
				grid[row,col] = new Cell(row, col);
			}
		}

		Cell nextCell = collapseCell(grid[0, 0]);
        while (nextCell != null)
            nextCell = collapseCell(nextCell);

        //displayGrid();

        //Debug.Log("Created grid of size " + dimension + " by " + dimension);

        //Test set low entropy
        //grid[6, 9].setWeight(1);

        //findLeastEntropy();

        //currentRule = rules.getRule(0);
        //grid[6, 9].removeStates(ref currentRule[1]);
        //grid[6, 9].collapse();
    }

	public int getCell(int r, int c)
    {
		return grid[r, c].getCurrentState();
    }

	public int getDimension()
    {
		return dimension;
    }

	public Cell findUnCollapsedCell()
    {
		for (int row = 0; row < dimension; row++)
		{
			for (int col = 0; col < dimension; col++)
			{
				if (grid[row, col].checkIfCollapsed())
					continue;
				else
					return grid[row, col];
			}
		}

		return null;
	}

	public Cell findLeastEntropy()
	{
        //AWFUL time complexity. come back to this [TK]
        Cell startCell = findUnCollapsedCell();
        if (startCell == null)
            return null;

        int minR = startCell.position[0], minC = startCell.position[1];
		//int minR = 0, minC = 0;
		for (int row = 0; row < dimension; row++)
		{
			for (int col = 0; col < dimension; col++)
			{
				if (grid[row, col].checkIfCollapsed())
					continue;
				if(grid[row, col].getWeight() < grid[minR,minC].getWeight())
				{
					minR = row;
					minC = col;
				}
			}
		}

		//Debug.Log("Row: " + minR + ", Col: " + minC + ", Weight: " + grid[minR, minC].getWeight());
		return grid[minR, minC];
	}

	public Cell collapseCell(Cell cell)
	{
		if(!cell.checkIfCollapsed())
		{
			int row = cell.position[0], col = cell.position[1];
			cell.collapse();
			currentRule = rules.getRule(cell.getCurrentState());
			//Debug.Log("CS Row: " + cell.position[0] + ", Col: " + cell.position[1]+ ", State: " + cell.getCurrentState());

			//Go to neighbors, remove states
			//UP
			if(row - 1 >= 0)
			{
				grid[row - 1, col].removeStates(ref currentRule[0]);
			}
			//RIGHT
			if (col + 1 < dimension)
			{
				grid[row, col + 1].removeStates(ref currentRule[1]);
			}
			//DOWN
			if (row + 1 < dimension)
			{
				grid[row + 1, col].removeStates(ref currentRule[2]);
			}
			//LEFT
			if (col - 1 >= 0)
			{
				grid[row, col - 1].removeStates(ref currentRule[3]);
			}
		}

		Cell nextCell = findLeastEntropy();
		return nextCell;
	}

	public void displayGrid()
	{
		for (int row = 0; row < dimension; row++)
		{
			for (int col = 0; col < dimension; col++)
			{
				Debug.Log("Row: " + row + ", Col: " + col + ", State: " + grid[row, col].getCurrentState());
			}
		}
	}
}
