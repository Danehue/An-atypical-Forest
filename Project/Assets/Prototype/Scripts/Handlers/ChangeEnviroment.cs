using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnviroment : MonoBehaviour
{
    public void setObjectActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void changeColor(GameObject obj)
    {
        obj.GetComponent<Light>().color = Color.red;
    }
}
