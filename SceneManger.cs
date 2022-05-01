using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManger : MonoBehaviour
{
    private float timer = 0.0f;
    private int daysPast = 0;
    private float timeForDay = 100;
    public GameObject flowers;
    private GridSystem grid;
    public GameObject player;
    public HouseEnter house;
    public GameObject sunTimer;
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

    public int seed56 = 0;
    public int seed57 = 0;
    public int seed58 = 0;

    public GameObject roseText;
    public GameObject daiseyText;
    public GameObject tulipText;

    void Start()
    {
        grid = new GridSystem(16, 8, 1f, new Vector3(-12, -4), soilTemplate);
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
                plant.GetComponent<BasePlant>().rememberTile.GetComponent<SoilTile>().Unwater();
            }
        }

        grid.AllSoilDryUp();


        //Set the player on the porche 
        player.transform.position = new Vector3(11.5f, 1.5f, 0.0f);
        player.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        player.GetComponent<FarmerMove>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

        roseText.GetComponent<TextMeshProUGUI>().text = "Roses:" + seed58;
        daiseyText.GetComponent<TextMeshProUGUI>().text = "Daisey:" + seed56;
        tulipText.GetComponent<TextMeshProUGUI>().text = "Tulips:" + seed57;



        timer += Time.deltaTime;

        sunTimer.transform.position = new Vector3(-13.8f, ((12.6f/timeForDay)* -timer) + 6.3f, 0.0f);


        if (timer > timeForDay)
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

        if (Input.GetKeyDown("space"))
        {
            player.GetComponent<Animator>().SetBool("water", true);
            player.GetComponent<FarmerMove>().enabled = false;
            Debug.Log("reading temp");
            //temp = GJLib.GetMouseWorldPosition();
            temp = player.transform.position;
            temp.y -= 0.7f;
            if (grid.GetValue(temp) != -1)
            {
                grid.SetValue(temp, items[heldItemIndex]);
                //seeds not yet made thus null
                if (items[heldItemIndex] == 56 )
                {
                    
                    if(grid.UpdateSoilTile(temp, items[heldItemIndex], daiseyTemplate)) { seed56++; }
                    
                }
                else if (items[heldItemIndex] == 57 )
                {
                    
                    if(grid.UpdateSoilTile(temp, items[heldItemIndex], tulipTemplate)) { seed57++; }
                    
                }
                else if (items[heldItemIndex] == 58 )
                {
                   
                    if(grid.UpdateSoilTile(temp, items[heldItemIndex], roseTemplate)) { seed58++; }
                   
                }
                else
                {
                    if(grid.UpdateSoilTile(temp, items[heldItemIndex])) { }//pass
                }

            }

            

        }

        if (Input.GetKeyUp("space")) { player.GetComponent<Animator>().SetBool("water", false);
            player.GetComponent<FarmerMove>().enabled = true;
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