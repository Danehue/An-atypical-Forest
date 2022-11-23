using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using UnityEngine;

public class Enemy_Test : MonoBehaviour
{
    public static event Action myEvent;

    void Start()
    {
        // Enemy uno = new Enemy();
        // Enemy_Archer dos = new Enemy_Archer();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myEvent?.Invoke();
        }
    }
}
