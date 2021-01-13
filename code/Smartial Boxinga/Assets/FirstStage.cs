using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStage : MonoBehaviour
{
    public GameObject Toll;

    public void StartGame()
    {
        Destroy(GameObject.Find("Dialog1"));
        Instantiate(Toll, new Vector3(0, 2.65f, -5.27f), Quaternion.identity);
    }
}
