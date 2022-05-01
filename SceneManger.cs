using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManger : MonoBehaviour
{
    private float timer = 0.0f;
    private int daysPast = 0;
    public GameObject flowers;
    private GridSystem grid;
<<<<<<< Updated upstream
    
=======
    public GameObject player;
    public HouseEnter house;
    public GridSystem theGrid;
    private float timeForDoor = 0.0f;
    private float scaleDilf = 2.0f;

>>>>>>> Stashed changes
    void Start()
    {
        //grid = new GridSystem(4, 2, 1.0f, new Vector3(0, 0));


    }


    void NewDay()
    {
        timer = 0.0f;
        daysPast++;
<<<<<<< Updated upstream
        //BasePlant flowersScript = flowers.GetComponent<Rose>();
        //flowersScript.Grow();
        //flowersScript.ChangeSprite();
=======
        house.CloseDoor();

       //for(int w = 0; w < theGrid.GetWidth; w++){
       //     for(int h = 0; h < theGrid.GetHeight; h++){




       //     }
       // }
>>>>>>> Stashed changes


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 20)
        {
            NewDay();
        }
        //Debug.Log(timer);

    }
}
