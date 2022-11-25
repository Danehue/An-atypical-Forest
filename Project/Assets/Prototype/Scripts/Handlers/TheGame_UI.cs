using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TheGame_UI : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public GameObject hud;
    public GameObject market;

    private float score_point;
    private bool paused = false;

    void Start()
    {

    }

    void Update()
    {
        togglePause();

        if(paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            toggleMarket();
        }

        score_point += Time.deltaTime;
    }

    void togglePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                playGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void playGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
        hud.SetActive(true);
        paused = false;
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        hud.SetActive(false);
        market.SetActive(false);
        paused = true;
    }

    public void controls()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void back()
    {
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
        pauseMenu.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void backToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void toggleMarket()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && market.activeInHierarchy == false)
        {
            market.SetActive(true);
            hud.SetActive(false);

        }
        else if(Input.GetKeyDown(KeyCode.LeftControl) && market.activeInHierarchy == true)
        {
            market.SetActive(false);
            hud.SetActive(true);
        }
    }
}
