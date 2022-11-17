using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static string weapon_name;
    public static float weapon_dammage, weapon_range, weapon_interval; 
    public AudioSource audioSource;
    public AudioClip clip; 
    public static AudioSource staticAudioSource; 
    public static AudioClip staticClip;
 
    public virtual void Start()
    {
        weapon_name = "Knife";
        weapon_dammage = 100;//30
        weapon_range = 2;
        weapon_interval = .2f;

        staticAudioSource = audioSource;
        staticClip = clip;
    }
}
