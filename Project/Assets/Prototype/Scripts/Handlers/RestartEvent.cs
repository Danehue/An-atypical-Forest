using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartEvent : MonoBehaviour
{
    public GameObject restartMenu;
    public GameObject hud;
    public GameObject market;
    // Start is called before the first frame update
    void Start()
    {
        Player.deathPlayer += setRestartMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRestartMenu()
    {
        hud.SetActive(false);
        market.SetActive(false);
        restartMenu.SetActive(true);
        Player.deathPlayer -= setRestartMenu;
    }
}
