using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Test : MonoBehaviour
{
    public GameObject revolver;
    public GameObject knife;
    public GameObject m16;
    public GameObject ak47;

    public GameObject redLine;

    public static GameObject currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = knife;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon.SetActive(false);
            revolver.SetActive(true);
            redLine.SetActive(true);
            currentWeapon = revolver;
            revolver.GetComponent<Weapon>().Start();
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            currentWeapon.SetActive(false);
            redLine.SetActive(false);
            knife.SetActive(true);
            currentWeapon = knife;
            knife.GetComponent<Weapon>().Start();
        }
        else if(Input.GetKeyDown(KeyCode.Y))
        {
            currentWeapon.SetActive(false);
            m16.SetActive(true);
            redLine.SetActive(true);
            currentWeapon = m16;
            m16.GetComponent<Weapon>().Start();
        }
        else if(Input.GetKeyDown(KeyCode.T))
        {
            currentWeapon.SetActive(false);
            ak47.SetActive(true);
            redLine.SetActive(true);
            currentWeapon = ak47;
            ak47.GetComponent<Weapon>().Start();
        }
    }
}
