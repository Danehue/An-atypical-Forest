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

    void Start()
    {
        coins_text = player_coins.GetComponent<Text>();
        box_text = player_box.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coins_text.text = Player.player_score.ToString();
        box_text.text = Player.player_boxes.ToString();
    }
}
