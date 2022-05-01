using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public void play()
    {
        SceneManager.LoadScene("MainScene");

    }

    public void options()
    {
        SceneManager.LoadScene("Options");
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }


}
