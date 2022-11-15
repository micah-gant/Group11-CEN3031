using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputGen : MonoBehaviour
{
    WFC_Grid grid;
    
    public int dimension;

    public Transform par;
    public Transform SUP;
    public Transform SRIGHT;
    public Transform SDOWN;
    public Transform SLEFT;
    public Transform SHRT;
    public Transform TALL;

    //top right is positive X: +100 negative Z: -100

    private Transform getState(int state)
    {
        switch(state)
        {
            case 0:
                return SUP;
            case 1:
                return SRIGHT;
            case 2:
                return SDOWN;
            case 3:
                return SLEFT;
            case 4:
                return SHRT;
            case 5:
                return TALL;
            default:
                return null;
        }
    }

    public void generateTerrain()
    {
        while (true)
        {
            try
            {
                grid = new WFC_Grid(dimension);

                float posC = 0, posR = 0;
                Vector3 pos = Vector3.zero;
                for (int row = 0; row < dimension; row++)
                {
                    for (int col = 0; col < dimension; col++)
                    {
                        int rand = Random.Range(0, 6);
                        Transform block = Instantiate(getState(grid.getCell(row, col)));
                        block.SetParent(par);
                        pos.x = posC;
                        pos.z = posR;
                        block.localPosition = pos;

                        //Move position
                        posC -= 2;
                    }
                    posR += 2;
                    posC = 0;
                }
            }
            catch (System.Exception)
            {
                Debug.Log("Invalid Try Again");
                continue;
            }

            break;
        }
    }
}
