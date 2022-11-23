using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M16 : Weapon
{
    public override void Start()
    {
        weapon_name = "M 16";
        weapon_dammage = 33;
        weapon_range = 15;
        weapon_interval = .1f;

        staticAudioSource = audioSource;
        staticClip = clip;
    }
}
