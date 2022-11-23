using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlane : MonoBehaviour
{
    public GameObject lightPlane;
    public Material newLightPlaneMaterial;
    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        Player.lightPlaneEvent += setLightPlane;
    }

    void Update()
    {
        
    }

    public void setLightPlane()
    {
        lightPlane.GetComponent<Renderer>().material = newLightPlaneMaterial;
        lightPlane.transform.Rotate(9,0,9);
        audioSource.PlayOneShot(clip);
        audioSource.PlayOneShot(clip);
        MeshCollider col = lightPlane.GetComponent<MeshCollider>();
        col.isTrigger = false;
        Player.lightPlaneEvent -= setLightPlane;
    }
}
