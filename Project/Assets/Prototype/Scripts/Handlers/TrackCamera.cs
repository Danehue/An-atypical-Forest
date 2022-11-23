using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCamera : MonoBehaviour
{
    public GameObject player;
    Vector3 cameraPosition;
    float zoom;
    // Start is called before the first frame update
    void Start()
    {
        zoom = 16;
    }

    // Update is called once per frame
    void Update()
    {
        zoom = Mathf.Clamp(zoom, 8f, 18f);

        zoom -= Input.mouseScrollDelta.y * Time.deltaTime * 200f;
        cameraPosition = new Vector3(0,8,-zoom);
        if(zoom > 8 && zoom < 18)
        {
            gameObject.transform.position = player.transform.position + cameraPosition;
        }
        else if(zoom <= 8)
        {
            gameObject.transform.position = player.transform.position + new Vector3(0,8,-8f);
        }
        else if(zoom >= 18)
        {
            gameObject.transform.position = player.transform.position + new Vector3(0,8,-18f);
        }
    }
}
