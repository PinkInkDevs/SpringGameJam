using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlant : MonoBehaviour
{
    public bool watered = false;
    public int growthLevel = 0;
    private int maxGrowth = 3;
    public bool readyToBePicked = false;


    // Update is called once per frame
    void Update()
    {
        
    }

    //Watered is called when plant is being watered
    void Watered()
    {
        watered = true;
    }

    void Grow(){
        if (watered)
        {
            growthLevel++;
            watered=false;
        }
        if(growthLevel >= maxGrowth)
        {
            readyToBePicked = true;
        }
    }

    void PickUp(){
        if (readyToBePicked)
        {
            //Get's picked up here

        }



    }


}
