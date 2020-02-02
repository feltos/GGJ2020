using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;

    bool started = false;

    public void playGame()
    {
        SceneManager.LoadScene("Layout");
        Debug.Log("LOAD");
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("LOAD");
            SceneManager.LoadScene("Layout");
        }
    }

    public void back()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}