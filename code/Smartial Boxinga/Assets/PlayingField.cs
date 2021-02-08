using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingField : MonoBehaviour
{
    public GameObject[] targets = new GameObject[6];
    public static PlayingField playingfield;

    public void Awake()
    {
        playingfield = this;

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(false);
        }
    }


    public void startGame()
    {
        Destroy(GameObject.Find("Dialog1"));
        showNextTarget();
    }

    public void showNextTarget()
    {
        
        targets[ComboChecker.combochecker.getComboList()[0] - 1].SetActive(true);
    }



}