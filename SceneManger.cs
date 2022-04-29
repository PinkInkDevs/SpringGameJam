using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManger : MonoBehaviour
{
    private float timer = 0.0f;
    private int daysPast = 0;   
    //public GameObject flowers[]



    void NewDay()
    {
        daysPast++;
        



    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Debug.Log(timer);

    }
}
