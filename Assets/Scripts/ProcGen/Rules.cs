using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules
{
	/* Process ============================================================================================================
	 * So there's a bunch of rules for slopes, but for short and tall they can basically have anything next to them except each other
	 * Short and Tall must be connected with a slope.
	 * 
	 * Slopes need information about: Rotation, and sides
	 * Slope Rotations
	 * - 0: +Z => Tall
	 * - 90: -X => Tall
	 * - 180: -Z => Tall
	 * - 270: +X => Tall
	 * 
	 * Mr. Martin Donald uses JSON files to deal with rotations but that sounds SCARY! I'll do it some other way
	 * 
	 * Rules
	 * - 0: Slope +Z
	 * - 1: Slope -X
	 * - 2: Slope -Z
	 * - 3: Slope +Z
	 * - 4: Short
	 * - 5: Tall
	*/

	const int SUP = 0;
	const int SRIGHT = 1;
	const int SDOWN = 2;
	const int SLEFT = 3;
	const int SHRT = 4;
	const int TALL = 5;

	private int[][] slopeUP;
	private int[][] slopeRIGHT;
	private int[][] slopeDOWN;
	private int[][] slopeLEFT;
	private int[][] shrt;
	private int[][] tall;

	public Rules()
	{
		slopeUP = new int[][]
		{
			new int[] {TALL}, //UP
			new int[] {SHRT,SUP}, //RIGHT
			new int[] {SHRT}, //DOWN
			new int[] {SHRT,SUP}  //LEFT
		};

		slopeRIGHT = new int[][]
		{
			new int[] {SHRT,SRIGHT}, //UP
			new int[] {TALL}, //RIGHT
			new int[] {SHRT,SRIGHT}, //DOWN
			new int[] {SHRT}  //LEFT
		};

		slopeDOWN = new int[][]
		{
			new int[] {SHRT}, //UP
			new int[] {SHRT,SDOWN}, //RIGHT
			new int[] {TALL}, //DOWN
			new int[] {SHRT,SDOWN}  //LEFT
		};

		slopeLEFT = new int[][]
		{
			new int[] {SHRT,SLEFT}, //UP
			new int[] {SHRT}, //RIGHT
			new int[] {SHRT,SLEFT}, //DOWN
			new int[] {TALL}  //LEFT
		};

		shrt = new int[][]
		{
			new int[] {SHRT,SDOWN}, //UP
			new int[] {SHRT,SRIGHT}, //RIGHT
			new int[] {SHRT,SUP}, //DOWN
			new int[] {SHRT,SLEFT}  //LEFT
		};

		tall = new int[][]
		{
			new int[] {TALL,SUP}, //UP
			new int[] {TALL,SLEFT}, //RIGHT
			new int[] {TALL,SDOWN}, //DOWN
			new int[] {TALL,SRIGHT}  //LEFT
		};
	}

	public int[][] getRule(int modelCode)
    {
		switch(modelCode)
        {
			case 0:
				return slopeUP;
			case 1:
				return slopeRIGHT;
			case 2:
				return slopeDOWN;
			case 3:
				return slopeLEFT;
			case 4:
				return shrt;
			case 5:
				return tall;
			default:
				return null;
        }
    }
}
