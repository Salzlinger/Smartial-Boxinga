using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class comboChecker : MonoBehaviour
{
    // Array welches mit der auszuführenden Combo befüllt wird
    public static string[] comboList = { "jab", "cross", "hookr", "hookl", "upperl", "upperr" };
    //public string currentPunch = comboList[0];

    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // entfernt das getroffene Ziel aus dem Array
    public void bullseye ()
    {
        Debug.Log("Geschafft!");
        for (int i = 0; i < comboList.Length - 1; i++)
        {
            comboList[i] = comboList[i + 1];
        }
        System.Array.Resize(ref comboList, comboList.Length - 1);
        Debug.Log(comboList.Length);
        //currentPunch = comboList[0];
    }
}
