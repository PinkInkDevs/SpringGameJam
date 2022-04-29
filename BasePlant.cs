using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlant : MonoBehaviour
{
    public bool watered = false;
    public int growthLevel = 0;
    private int maxGrowth = 3;
    public bool readyToBePicked = false;
    public SpriteRenderer flowerStage;
    public Sprite seeds;
    public Sprite sprout;
    public Sprite flower;


    // Update is called once per frame
    void Update()
    {
        
    }

    //Watered is called when plant is being watered
    public void Watered() //Will check 
    {
        watered = true;
    }

    public void Grow(){
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

    public void ChangeSprite()
    {

        Debug.Log("Here");
        if (growthLevel == 0)
        {
            flowerStage.sprite = seeds;
        }
        else if (growthLevel == 1)
        {
            flowerStage.sprite = sprout;
        }
        else if (growthLevel == 2)
        {
            flowerStage.sprite = flower;
        }


    }

    void PickUp(){
        if (readyToBePicked)
        {
            //Get's picked up here

        }



    }


}
