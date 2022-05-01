using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManger : MonoBehaviour
{
    private float timer = 0.0f;
    private int daysPast = 0;
    public GameObject flowers;
    private GridSystem grid;
    public GameObject player;
    public HouseEnter house;
    private float timeForDoor = 0.0f;
    private float scaleDilf = 2.0f;

    void Start()
    {
        //grid = new GridSystem(4, 2, 1.0f, new Vector3(0, 0));
        player.transform.position = new Vector3(11.5f, 1.5f, 0.0f);
        player.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        player.GetComponent<FarmerMove>().enabled = true;
        timeForDoor = 0.0f;
        scaleDilf = 2.0f;

    }


    void NewDay()
    {
        timer = 0.0f;
        timeForDoor = 0.0f;
        scaleDilf = 2.0f;
        daysPast++;
        house.CloseDoor();

        BasePlant flowersScript = flowers.GetComponent<Rose>();
        flowersScript.Watered();
        flowersScript.Grow();
        flowersScript.ChangeSprite();



        //Set the player on the porche 
        player.transform.position = new Vector3(11.5f, 1.5f, 0.0f);
        player.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        player.GetComponent<FarmerMove>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 100)
        {
            GoToSleep();
            NewDay();
        }

        if (house.IsDoorOpen())
        {
            timeForDoor += Time.deltaTime;

            if (timeForDoor > 1)
            {
                GoToSleep();

                if (timeForDoor > 4) { NewDay(); }

            }

        }
        else { timeForDoor = 0.0f; }


    }


    void GoToSleep()
    {


        player.transform.position = new Vector3(11.5f, 2.2f, 0.0f);
        player.GetComponent<FarmerMove>().enabled = false;
        player.transform.localScale = new Vector3(scaleDilf, scaleDilf, 1.0f);

        if (scaleDilf >= 0.0f) { scaleDilf -= 0.01f; }

    }

}