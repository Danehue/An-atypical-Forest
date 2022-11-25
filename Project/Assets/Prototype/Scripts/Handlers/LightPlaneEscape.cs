using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlaneEscape : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Player.lightPlaneEscapeEvent += setLightPlaneEscape;
    }

    void Update()
    {
        
    }

    public void setLightPlaneEscape()
    {
        Debug.Log("Te fuiste capo");
        anim.SetBool("Escape", true);
        Player.lightPlaneEscapeEvent -= setLightPlaneEscape;
    }
}
