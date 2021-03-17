using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ComboChecker : MonoBehaviour
{
    // Array welches mit der auszuführenden Combo befüllt wird
    private int[] combolist;
	private int endurancecount;
	
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
		if (Gamemode.gamemode.getGamemodeId() == 1)
		{
			combolist[combolist.Length - 1] = UnityEngine.Random.Range(1, 7);
			endurancecount++;
			DialogueManager.dmanager.endurancePlus(endurancecount.ToString());
		}
		else
		{
			System.Array.Resize(ref combolist, combolist.Length - 1);
		}
        if(combolist.Length > 0)
        {
			//PlayingField.playingfield.Invoke("showNextTarget", 0.4f);
            PlayingField.playingfield.showNextTarget();
        }
		else
		{
			Debug.Log("Fertig.");
			DialogueManager.dmanager.comboFinished();
		}	
	}
}