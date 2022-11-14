using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell
{
	//Need data structure for possibilities (Rules)
	//6 possibilities (4 rotations for slope)

	public int[] position = new int[2];
	private int weight;
	int currentState = -1; //Negative one for no state
	private List<int> states; //Possible states

	public Cell(int row, int col)
	{
		//Debug.Log("Created Cell");
		position[0] = row;
		position[1] = col;
		states = new List<int>{0,1,2,3,4,5}; //Could be any of the six
		weight = states.Count;
	}

	public int getCurrentState()
	{
		return currentState;
	}

	public void setCurrentState(int state)
	{
		this.currentState = state;
	}

	public int getWeight()
	{
		return weight;
	}

	public void setWeight(int weight)
	{
		this.weight = weight;
	}

	public void removeStates(ref int[] allowedStates) //aS for allowed states
	{
		if (!checkIfCollapsed())
		{
			List<int> aS = new();
			foreach (int a in allowedStates)
			{
				aS.Add(a); //convert to List
			}

			//all I do is write bad code all day :/
			IEnumerable<int> tempIE = (IEnumerable<int>)states.Intersect(aS);
			states = tempIE.ToList();
			weight = states.Count;
			//Testing
			//Debug.Log("Row: " + position[0] + ", Col: " + position[1]);
			//foreach (int id in states)
			//    Debug.Log(id);
		}
	}

	public bool checkIfCollapsed()
	{
		if(currentState != -1)
			return true; //collapsed
		return false; //not collapsed
	}

	public void collapse()
	{
		int rNum = Random.Range(0, states.Count);
		//Debug.Log("Row: " + position[0] + ", Col: " + position[1] + ", RNum: " + rNum);
		//Debug.Log("State: " + states[rNum]);
		//foreach (int id in states)
		//	Debug.Log(id);
		currentState = states[rNum];
	}
}
