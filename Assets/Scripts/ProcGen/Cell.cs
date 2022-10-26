using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    //Need data structure for possibilities (Rules)
    //6 possibilities (4 rotations for slope)

    private float weight;
    bool isCollapsed = false;
    int currentState = -1; //Negative one for no state
    private int[] states; //Possible states

    public Cell()
    {
        //Debug.Log("Created Cell");

        states = new int[]{0,1,2,3,4,5}; //Could be any of the six
        weight = states.Length;
    }
}
