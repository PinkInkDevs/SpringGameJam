using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlant : MonoBehaviour
{
    public int growthLevel = 0;
    public int maxGrowth = 3;
    public bool readyToBePicked = false;
    public SpriteRenderer flowerStage;
    public Sprite seeds;
    public Sprite sprout;
    public Sprite flower;
    public GameObject rememberTile;
 


    // Update is called once per frame
    public void CreatePlant(GameObject soilTiles)
    {
        this.rememberTile = soilTiles;
    }

    //Watered is called when plant is being watered
    public bool CheckWatered() //Will check 
    {
        return rememberTile.GetComponent<SoilTile>().IsWatered();
    }

    public void Grow(){
        if (CheckWatered())
        {
            growthLevel++;
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

    bool PickUp()
    {
        return readyToBePicked;
    }


}
