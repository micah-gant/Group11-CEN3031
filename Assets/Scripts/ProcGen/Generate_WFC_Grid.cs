using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_WFC_Grid : MonoBehaviour
{
    [Header("Dimension for Grid")]
    [Tooltip("Grid will be dimension x dimension")]
    public int dimension;

    public void generate()
    {
        WFC_Grid grid = new WFC_Grid(dimension);
    }
}
