using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManger : MonoBehaviour
{
    private float timer = 0.0f;
    private int daysPast = 0;
    public GameObject flowers;
    



    void NewDay()
    {
        timer = 0.0f;
        daysPast++;
        BasePlant flowersScript = flowers.GetComponent<Rose>();
        flowersScript.Watered();
        flowersScript.Grow();
        flowersScript.ChangeSprite();


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
