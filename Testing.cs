using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour{
//creates the grid
    public GridSystem grid;

    private int[] items = new int[] {1,2,56};
    private int heldItemIndex = 0;
    

    public void Start(){ 
        grid = new GridSystem(4 ,2 , 10f, new Vector3(20,0));
        new GridSystem(2 ,2 , 10f, new Vector3(0,0));
        new GridSystem(4 ,2 , 5f, new Vector3(-50,0));
    }

    public void Update(){
        //grid.SetValue(1,1,56);
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("here");
            grid.SetValue(GJLib.GetMouseWorldPosition(), items[heldItemIndex]);
        }

        if (Input.GetMouseButtonDown(1)){
            Debug.Log(grid.GetValue(GJLib.GetMouseWorldPosition()));
        }
        //temp for holding item
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("key 1 was pressed");
            heldItemIndex=0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("key 2 was pressed");
            heldItemIndex=1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("key 3 was pressed");
            heldItemIndex=2;
        }

    }

    
}
