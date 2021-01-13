using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class comboChecker : MonoBehaviour
{
    // Array welches mit der auszuführenden Combo befüllt wird
    int n = 3;
    public static string[] comboList = new string [3] { "jab", "cross", "hook" };
    int i = 0;
    int pos = 0;
    //public string currentPunch = comboList[0];


    // Start is called before the first frame update
    void Start()
    {
        EventManager eventManager = GetComponent<EventManager>();
        eventManager.OnHit += bullseye;
        if (eventManager == null)
        {
            Debug.LogError("ITA KAPUTTA!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // entfernt das getroffene Ziel aus dem Array
    public void bullseye (object sender, EventArgs e)
    {
        Debug.Log("geschafft!");
        for (i = 0; i < 2; i++)
        {
            comboList[i] = comboList[i + 1];
        }
        System.Array.Resize(ref comboList, comboList.Length - 1);
        Debug.Log(comboList.Length);
        //currentPunch = comboList[0];
    }
}
