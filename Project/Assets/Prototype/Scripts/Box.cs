using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject player;
    public static GameObject box;

    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        box = gameObject;
    }

    void Update()
    {
        float dist = Vector3.Distance(box.transform.position, player.transform.position);
        if(dist <= 2)
        {
            Player.grabObject(box);
        }
    }
}
