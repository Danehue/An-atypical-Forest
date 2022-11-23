using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Agent : Enemy
{
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        rb = GetComponent<Rigidbody>();
        character_name = "Agent";
        character_hp = 100;
        character_speed = 5;
        character_acceleration = 40;
        character_angular_speed = 300;
        character_range = 9f;
        character_dammage = 12;
        character_cooldown = 2f;
        timer = character_cooldown;
        setCharacter();
        isAlive = true;
        instantiaiteBlood = true;

        Enemy_Test.myEvent += angryCharacter;
    }

    void Update()
    {
        if(isAlive) followPlayer(player.transform.position);
    }

    public override void angryCharacter()
    {
        character_name = "Angry Archer";
        character_hp = 150;
        character_speed = 6;
        character_range = 11f;
        character_dammage = 15;
        setCharacter();
    }
}
