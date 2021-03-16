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
	
    // entfernt das getroffene Ziel aus dem Array und macht mittlerweile ganz viele andere sachen :D
    public void bullseye ()
    {
        for (int i = 0; i < combolist.Length - 1; i++)
        {
            combolist[i] = combolist[i + 1];
        }
        System.Array.Resize(ref combolist, combolist.Length - 1);
        if(combolist.Length > 0)
        {
			//PlayingField.playingfield.Invoke("showNextTarget", 0.4f);
            PlayingField.playingfield.showNextTarget();
        }
		else
		{
			Debug.Log("Fertig.");
			// Im Falle einer Wiederholung könnte hier ein "Notausgang" zum Endscreen des Tutorials
			// gecalled werden indem man die counter auf die entsprechenden werte setzt.
			// So kann nach jeder Wiederholung ausgewählt werden, was man danach machen möchte.
			Gamemode.gamemode.setTutorialCounter(Gamemode.gamemode.getTutorialCounter()+1);
			if(Gamemode.gamemode.getTutorialCounter() > 10)
			{
				Gamemode.gamemode.UpdateText();
				Gamemode.gamemode.setDialogueCounter(Gamemode.gamemode.getDialogueCounter()+1);
				Gamemode.gamemode.Invoke("UpdateText", 3.0f);
				// Hier Anzeige von Buttons/Helfern die einen die Schläge wiederholen lassen
				// die man wiederholen möchte.
				/*
				for(int i = 0; i < Gamemode.gamemode.buttons.Length; i++){
					Gamemode.gamemode.buttons[i].SetActive(true);
				}
				*/
				Gamemode.gamemode.setTutorialCounter(0);
			}
			else
			{
				Gamemode.gamemode.UpdateText();
				Gamemode.gamemode.setDialogueCounter(Gamemode.gamemode.getDialogueCounter()+1);
				Gamemode.gamemode.gameStart();
			}
		}	
	}
}