using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ComboChecker : MonoBehaviour
{
    // Array welches mit der auszuführenden Combo befüllt wird
    private int[] combolist;
    public static ComboChecker combochecker;

    private void Awake()
    {
        combochecker = this;
    }

    public int[] getComboList ()
    {
        return combolist;
    }

    public void setComboList (int[] newcombolist)
    {
        combolist = newcombolist;
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
    public void bullseye ()
    {
        //Debug.Log("Ziel wurde getroffen!");
        for (int i = 0; i < combolist.Length - 1; i++)
        {
            combolist[i] = combolist[i + 1];
        }
        System.Array.Resize(ref combolist, combolist.Length - 1);
        Debug.Log("Anzahl restliche Ziele: " + combolist.Length);
        if(combolist.Length > 0)
        {
			// Debug.Log("Nächstes Ziel: " + combolist[0]);
			//PlayingField.playingfield.Invoke("showNextTarget", 0.4f);
            PlayingField.playingfield.showNextTarget();
        }
		else
		{
			Debug.Log("Fertig.");
			Gamemode.gamemode.setTutorialCounter(Gamemode.gamemode.getTutorialCounter()+1);
			if(Gamemode.gamemode.getTutorialCounter() >= 10)
			{
				for(int i = 0; i < Gamemode.gamemode.buttons.Length; i++){
					Gamemode.gamemode.buttons[i].SetActive(true);
				}
				Gamemode.gamemode.setTutorialCounter(0);
			}
			else
			{
				Gamemode.gamemode.gameStart();
			}
		}	
	}
        
}