using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFC_Grid
{
	private int dimension;

	private Cell[,] grid;
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
				grid[row, col] = new Cell();
            }
        }

		Debug.Log("Created grid of size " + dimension + " by " + dimension);
    }

	public Cell findLeastEntropy()
    {
		Cell[,] gridCopy = (Cell[,])grid.Clone();
        System.Array.Sort(gridCopy);

		return null;
    }
}
