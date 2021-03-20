using System;
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

        hideTargets();
    }

    public void showNextTarget()
    {
		try
		{
        targets[ComboChecker.combochecker.getComboList()[0] - 1].SetActive(true);
		}
		catch(IndexOutOfRangeException e)
		{
			if (ComboChecker.combochecker.getComboList().Length == 0)
			{
				Debug.Log("Playingfield Exception e.");
			}
		}
	}
	
	public void hideTargets()
	{
		CancelInvoke();
		for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(false);
        }
	}



}