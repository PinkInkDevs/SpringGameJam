using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GridSystem : MonoBehaviour {
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPos;
    private int[,] gridArray;

    private TextMesh[,] debugTextArray;

    private GameObject soilTemplate;
    private GameObject[,] clone;

    private GameObject plantTemplate;

    private GameObject[,] plantArray;
    private Vector3 tempPos;
    //just a holder object
    private GameObject hold;
    
    public GridSystem(int width, int height, float cellSize, Vector3 originPos, GameObject template){
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPos = originPos;
        this.soilTemplate = template;
       

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];
        clone = new GameObject[width, height];
        plantArray = new GameObject[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++){
            for (int y = 0; y<gridArray.GetLength(1); y++){
                tempPos = (GetWorldPosition(x, y) + new Vector3(cellSize,cellSize) * .5f);
                debugTextArray[x,y] = GJLib.CreateWorldText(gridArray[x,y].ToString(), null, tempPos, 2, Color.white, TextAnchor.MiddleCenter);
                //creates tile object placement
                clone[x,y] = CreateTiles(soilTemplate,tempPos);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x+1,y), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x,y+1), Color.white, 100f);
            }
            Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width,height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width,height), Color.white, 100f);
            
            
        }
    }
    //methods used for creating array
    private Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x, y) * cellSize + originPos; //+ originPos;
    }
    private void GetXY(Vector3 worldPosition, out int x, out int y){
        x = Mathf.FloorToInt((worldPosition-originPos).x / cellSize);
        y = Mathf.FloorToInt((worldPosition-originPos).y / cellSize);
    }

    public void SetValue(int x, int y, int value){
        if (x >= 0 && y >= 0 && x < width && y < height){
            gridArray[x,y] = value;
            debugTextArray[x,y].text = gridArray[x,y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value){
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y,value);
    }

    public int GetValue(int x, int y){
        if (x >= 0 && y >= 0 && x < width && y < height){
            return gridArray[x,y];
        } else {
            return -1;
        }
    }
    public int GetValue(Vector3 worldPosition){
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x,y);
    }
    //methods for placing tiles and updating them/watering and plant taking up pos.
    public GameObject CreateTiles(GameObject soilTemplate, Vector3 tempPos)
    {
        return Instantiate(soilTemplate, tempPos, Quaternion.identity);
    }
    public GameObject CreatePlants(GameObject plantTemplate, Vector3 tempPos)
    {
        return Instantiate(plantTemplate, tempPos, Quaternion.identity);
    }  
    //water Soil plant and harvest
    public void UpdateSoilTile(Vector3 worldPosition, int tool, GameObject plantTemplate = null)
    {
        if (tool == 2){
            int x,y;
            GetXY(worldPosition, out x, out y);
            if (GetValue(x,y)!= -1)
            {
                hold = clone[x,y];
                hold.GetComponent<SoilTile>().Water();
            }
        }
        else if (tool > 2){
            int x,y;
            GetXY(worldPosition, out x, out y);
            if (GetValue(x,y) != -1)
            {  

                if (clone[x,y].GetComponent<SoilTile>().IsOccupied() != true)
                {
                    if (tool == 56)
                    {
                        plantArray[x,y] = CreatePlants(plantTemplate, clone[x,y].GetComponent<SoilTile>().transform.position);
                        plantArray[x,y].GetComponent<Daisey>().rememberTile = clone[x,y];
                        clone[x,y].GetComponent<SoilTile>().OccupieTile();
                    } else if (tool == 57)
                    {
                        plantArray[x,y] = CreatePlants(plantTemplate, clone[x,y].GetComponent<SoilTile>().transform.position);
                        plantArray[x,y].GetComponent<Tulip>().rememberTile = clone[x,y];
                        plantArray[x,y].transform.localScale = new Vector3(0.5f,0.5f,1.0f);
                        clone[x,y].GetComponent<SoilTile>().OccupieTile();

                    } else if (tool == 58)
                    {
                        plantArray[x,y] = CreatePlants(plantTemplate, clone[x,y].GetComponent<SoilTile>().transform.position);
                        plantArray[x,y].GetComponent<Rose>().rememberTile = clone[x,y];
                        plantArray[x,y].transform.localScale = new Vector3(0.5f,0.5f,1.0f);
                        clone[x,y].GetComponent<SoilTile>().OccupieTile();

                    }
                }
                
            }
        }
    }
    //all soilTiles dry up
    public void AllSoilDryUp()
    {
        foreach(GameObject item in clone)
        {
            item.GetComponent<SoilTile>().Unwater();
        }
    }
    public void AllSoilWatered()
    {
        foreach(GameObject item in clone)
        {
            item.GetComponent<SoilTile>().Water();
        }
    }

}
