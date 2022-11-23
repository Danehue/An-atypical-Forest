using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Weapon
{
    public override void Start()
    {
        weapon_name = "AK 47";
        weapon_dammage = 40;
        weapon_range = 15;
        weapon_interval = .3f;

        staticAudioSource = audioSource;
        staticClip = clip;
    }
}
