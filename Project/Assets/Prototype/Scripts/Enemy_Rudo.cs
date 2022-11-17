using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rudo : Enemy
{
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        rb = GetComponent<Rigidbody>();
        character_name = "Rudo";
        character_hp = 120;
        character_speed = 7;
        character_acceleration = 40;
        character_angular_speed = 300;
        character_range = 2f;
        character_dammage = 7;
        character_cooldown = 1.5f;
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
        character_speed = 8;
        character_dammage = 15;
        setCharacter();
    }
}
