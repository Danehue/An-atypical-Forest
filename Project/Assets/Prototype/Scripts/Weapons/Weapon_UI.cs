using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_UI : MonoBehaviour
{
    GameObject weaponTest;
    
    public GameObject hud;
    public GameObject market;
    public float cost;

    public void buyWeapon(GameObject weaponToBuy)
    {
        if(Player.player_score >= cost)
        {
            weaponTest = FindObjectOfType<Weapon_Test>().gameObject;
            Weapon_Test.purchasedWeapon = weaponToBuy;
            weaponTest.GetComponent<Weapon_Test>().changeWeapon(Weapon_Test.purchasedWeapon);
            Player.player_score -= cost;
        }
        hud.SetActive(true);
        market.SetActive(false);
    }

    public void buyPower()
    {
        Player.player_score -= cost;
        hud.SetActive(true);
        market.SetActive(false);
    }
}
