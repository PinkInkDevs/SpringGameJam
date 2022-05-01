using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDirt : MonoBehaviour
{
    //creates the grid
    public GridSystem grid;

    public void Start()
    {
       // grid = new GridSystem(4, 2, 1.0f, new Vector3(0, 0));

    }

    public void Update()
    {
        //grid.SetValue(1,1,56);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("here");
            grid.SetValue(GJLib.GetMouseWorldPosition(), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(GJLib.GetMouseWorldPosition()));
        }
    }


}
