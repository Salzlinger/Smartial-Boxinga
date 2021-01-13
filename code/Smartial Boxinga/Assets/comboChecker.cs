using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboChecker : MonoBehaviour
{
    // Array welches mit der auszuführenden Combo befüllt wird
    int n = 3;
    public static string[] comboList = new string [3] { "jab", "cross", "hook" };
    int i = 0;
    int pos = 0;
    //public string currentPunch = comboList[0];


    void OnEnable()
    {
       // EventManager.onHit += bullseye;
    }

    void OnDisable()
    {
       // EventManager.onHit -= bullseye;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // entfernt das getroffene Ziel aus dem Array
    void bullseye ()
    {
        for (i = 0; i < 3; i++)
        {
            comboList[i] = comboList[i + 1];
        }
        //currentPunch = comboList[0];
    }
}
