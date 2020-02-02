using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Image loadingScreen;

    float startTime;
    float length;
    public float speed;

    Vector3 startPosition;
    Vector3 endPosition;
    float vectorLength;

    bool started = false;

    public void playGame()
    {
        SceneManager.LoadScene("Layout");
        //StartCoroutine(Load());
    }

    private void Start()
    {
        startPosition = loadingScreen.rectTransform.position;
        endPosition = new Vector3(0.0f, 137.0f, 0.0f);
    }
    private void Update()
    {

    }
    IEnumerator Load()
    {
        for(float t = 0; t < 1f; t+= Time.deltaTime)
        {
            yield return null;
            loadingScreen.rectTransform.position = Vector3.Lerp(
                                                      startPosition,
                                                      endPosition,
                                                      t);
        }
        loadingScreen.rectTransform.position = Vector3.Lerp(
                                                    startPosition,
                                                    endPosition,
                                                    1);
    }

    public void options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}