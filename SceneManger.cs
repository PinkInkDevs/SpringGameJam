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
    private GameObject[,] clone;

    private int[] items = new int[] { 1, 2, 56, 57, 58 };
    private int heldItemIndex = 0;
    public GameObject soilTemplate;
    public GameObject daiseyTemplate;
    public GameObject tulipTemplate;
    public GameObject roseTemplate;
    private Vector3 temp;

    void Start()
    {
        grid = new GridSystem(6, 4, 1f, new Vector3(0, 0), soilTemplate);
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

        clone = grid.GetPlants();
        

        foreach (GameObject plant in clone ) {
            if (plant != null) {
                plant.GetComponent<BasePlant>().Grow();

            }
        }



        //Set the player on the porche 
        player.transform.position = new Vector3(11.5f, 1.5f, 0.0f);
        player.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        player.GetComponent<FarmerMove>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
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

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("reading temp");
            temp = GJLib.GetMouseWorldPosition();
            if (grid.GetValue(temp) != -1)
            {
                grid.SetValue(temp, items[heldItemIndex]);
                //seeds not yet made thus null
                if (items[heldItemIndex] == 56)
                {
                    grid.UpdateSoilTile(temp, items[heldItemIndex], daiseyTemplate);
                }
                else if (items[heldItemIndex] == 57)
                {
                    grid.UpdateSoilTile(temp, items[heldItemIndex], tulipTemplate);
                }
                else if (items[heldItemIndex] == 58)
                {
                    grid.UpdateSoilTile(temp, items[heldItemIndex], roseTemplate);
                }
                else
                {
                    grid.UpdateSoilTile(temp, items[heldItemIndex]);
                }

            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(GJLib.GetMouseWorldPosition()));

        }
        //temp for holding item
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("key 1 was pressed");
            heldItemIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("key 2 was pressed");
            heldItemIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("key 3 was pressed");
            heldItemIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("key 4 was pressed");
            heldItemIndex = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("key 4 was pressed");
            heldItemIndex = 4;
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


    void GoToSleep()
    {


        player.transform.position = new Vector3(11.5f, 2.2f, 0.0f);
        player.GetComponent<FarmerMove>().enabled = false;
        player.transform.localScale = new Vector3(scaleDilf, scaleDilf, 1.0f);

        if (scaleDilf >= 0.0f) { scaleDilf -= 0.01f; }

    }

}