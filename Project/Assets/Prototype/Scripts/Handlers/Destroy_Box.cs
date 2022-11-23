using UnityEngine;

public class Destroy_Box : MonoBehaviour
{
    public float timeToDestroy;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if(timeToDestroy <= 2)
        {
            Enemy.boxAvailable = true;
        }
    }
}
