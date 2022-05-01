using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTile : MonoBehaviour
{

    private bool watered = false;

    public bool IsWatered()
    {
        return watered;
    }
    //updates water from false to true or true to false
    //changes the sprite for the object and value for soil being dry or not.
    public void UpdateWater()
    {
        if (watered==true){
            watered = false;
        } else {
            watered = true;
        }
    }
    

}
