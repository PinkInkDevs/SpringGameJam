using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEnter : MonoBehaviour
{
    public Sprite doorClosed;
    public Sprite doorOpened;
    private SpriteRenderer house;
    private bool doorOpen;
 

    void Start()
    {
        house = GetComponent<SpriteRenderer>();

        house.sprite = doorClosed;

        doorOpen = false;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        house.sprite = doorOpened;

        doorOpen=true;


    }

    void OnCollisionExit2D(Collision2D collision)
    {
        house.sprite = doorClosed;

        doorOpen=false;

    }

    public bool IsDoorOpen() { return doorOpen; }
    public void CloseDoor() { house.sprite = doorClosed; doorOpen = false; }



    void Update()
    {

    }


}
