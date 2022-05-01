using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManger : MonoBehaviour
{
    private float timer = 0.0f;
    private int daysPast = 0;
    public GameObject flowers;
    private GridSystem grid;
    
    void Start()
    {
        //grid = new GridSystem(4, 2, 1.0f, new Vector3(0, 0));


    }


    void NewDay()
    {
        timer = 0.0f;
        daysPast++;
        //BasePlant flowersScript = flowers.GetComponent<Rose>();
        //flowersScript.Grow();
        //flowersScript.ChangeSprite();


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
