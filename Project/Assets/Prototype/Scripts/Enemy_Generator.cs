using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{
    public GameObject enemy;

    public Transform enemyGenerationZone;

    float timer;

    void Start()
    {
        timer = 5;
    }

    void Update()
    {
        generateEnemy();
        if(Player.player_score > 20)
        {
            generateEnemy();
        }
        // if(Player.player_score > 50)
        // {
        //     generateEnemy();
        // }
    }

    void generateEnemy()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = 20;
            Instantiate(enemy, enemyGenerationZone.position, Quaternion.identity);
        }
    }
}
