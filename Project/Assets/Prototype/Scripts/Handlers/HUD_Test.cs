using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Test : MonoBehaviour
{
    public GameObject player_coins;
    Text coins_text;
    public GameObject player_box;
    Text box_text;
    public GameObject player_HP;
    Text HP_text;
    public GameObject player_timer;
    Text timer_text;

    void Start()
    {
        coins_text = player_coins.GetComponent<Text>();
        box_text = player_box.GetComponent<Text>();
        HP_text = player_HP.GetComponent<Text>();
        timer_text = player_timer.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coins_text.text = Player.player_score.ToString();
        box_text.text = Player.player_boxes.ToString();
        timer_text.text = Mathf.Round(Player.timer2).ToString();
        HP_text.text = Player.player_hp + " / 500";
    }
}
