using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheGame_UI : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public GameObject hud;

    public Text score;

    private float score_point;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        }

        score_point += Time.deltaTime;
        score.text = "Score: " + Mathf.Round(score_point);
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
        Debug.Log("Se cerró el juego");
    }
}
