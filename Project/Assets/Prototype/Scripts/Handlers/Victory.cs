using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject victory;
    public GameObject hud;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("LightPlane"))
        {
            victory.SetActive(true);
            hud.SetActive(false);
        }
    }
}
