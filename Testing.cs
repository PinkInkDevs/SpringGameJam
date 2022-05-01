using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
//creates the grid
    public GridSystem grid;

    private int[] items = new int[] {1,2,56};
    private int heldItemIndex = 0;
    public GameObject soilTemplate;
    private Vector3 temp;
    

    public void Start(){ 
        grid = new GridSystem(6 ,8 , 1f, new Vector3(20,0), soilTemplate);
    }

    public void Update(){
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("here");
            temp = GJLib.GetMouseWorldPosition();
            if ( grid.GetValue(temp) !=-1)
            {
                grid.SetValue(temp, items[heldItemIndex]);
                //seeds not yet made thus null
                grid.UpdateSoilTile(temp, items[heldItemIndex]);
            }
            
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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            grid.AllSoilDryUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            grid.AllSoilWatered();
        }

    }

    
}
