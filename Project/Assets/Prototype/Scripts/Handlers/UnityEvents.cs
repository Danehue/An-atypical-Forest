using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent myUnityEvent;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myUnityEvent.Invoke();
        }
    }
}
