using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilTile : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite1;
    public Sprite newSprite2;
    private bool watered = false;
    private bool plantPlaced = false;

    public bool IsWatered()
    {
        return watered;
    }
    //updates water from false to true or true to false
    //changes the sprite for the object and value for soil being dry or not.
    public void Water()
    { 
        watered = true;
        spriteRenderer.sprite = newSprite2;
    }
    //used for drying up soil
    public void Unwater()
    {
        watered=false;
        spriteRenderer.sprite = newSprite1;
    }
    public bool IsOccupied()
    {
        return plantPlaced;
    }
    public void OccupieTile()
    {
        plantPlaced = true;
    }
    public void UnoccupieTile()
    {
        plantPlaced = false;
    }
}
