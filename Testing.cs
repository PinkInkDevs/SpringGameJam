/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
//creates the grid
    public GridSystem grid;
    //56 seed 1 is trowel/hoe 2 is water can
    private int[] items = new int[] {1,2,56,57,58};
    private int heldItemIndex = 0;
    public GameObject soilTemplate;
    public GameObject daiseyTemplate;
    public GameObject tulipTemplate;
    public GameObject roseTemplate;
    private Vector3 temp;
    

    public void Start(){ 
        grid = new GridSystem(6 ,4 , 1f, new Vector3(0,0), soilTemplate);
    }

    public void Update(){
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("here");
            temp = GJLib.GetMouseWorldPosition();
            if ( grid.GetValue(temp) !=-1)
            {
                grid.SetValue(temp, items[heldItemIndex]);
                //seeds not yet made thus null
                if(items[heldItemIndex]==56){
                    grid.UpdateSoilTile(temp, items[heldItemIndex], daiseyTemplate);
                } else if (items[heldItemIndex]==57) {
                    grid.UpdateSoilTile(temp, items[heldItemIndex], tulipTemplate);
                } else if (items[heldItemIndex]==58){
                    grid.UpdateSoilTile(temp, items[heldItemIndex], roseTemplate);
                } else {
                    grid.UpdateSoilTile(temp, items[heldItemIndex]);
                }
                
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
            Debug.Log("key 4 was pressed");
            heldItemIndex=3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("key 4 was pressed");
            heldItemIndex=4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            grid.AllSoilDryUp();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            grid.AllSoilWatered();
        }

    }

    
}
*/