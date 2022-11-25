using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Test : MonoBehaviour
{
    public GameObject revolver;
    public GameObject knife;
    public GameObject m16;
    public GameObject ak47;

    public static GameObject purchasedWeapon;

    public GameObject redLine;

    public static GameObject currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = knife;
        purchasedWeapon = null; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeWeapon(knife);
            redLine.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeWeapon(purchasedWeapon);
        }
    }

    public void changeWeapon(GameObject weapon)
    {
        currentWeapon.SetActive(false);
        weapon.SetActive(true);
        currentWeapon = weapon;
        redLine.SetActive(true);
        weapon.GetComponent<Weapon>().Start();
    }
}
