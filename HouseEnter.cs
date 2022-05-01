using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEnter : MonoBehaviour
{
    public Sprite doorClosed;
    public Sprite doorOpened;
    private SpriteRenderer house;

    void Start()
    {
        house = GetComponent<SpriteRenderer>();

        house.sprite = doorClosed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("It's Hitting");

        house.sprite = doorOpened;



    }

    void OnCollisionExit2D(Collision2D collision)
    {

        house.sprite = doorClosed;


    }


}
