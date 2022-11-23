using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon
{
    public override void Start()
    {
        weapon_name = "Revolver";
        weapon_dammage = 110;
        weapon_range = 15;
        weapon_interval = 1.5f;

        staticAudioSource = audioSource;
        staticClip = clip;
    }
}
