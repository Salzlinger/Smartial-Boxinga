using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemode : MonoBehaviour
{
    private int gamemodeid;
	
    public static Gamemode gamemode;

	public GameObject[] buttons = new GameObject[3];
	public GameObject Preview;
	
    public void Awake()
    {
        gamemode = this;
		Preview.SetActive(false);
    }
	
	public void Start()
	{
		//setGamemodeID(0);
	}


    public void setGamemodeID(int id)
    {
        this.gamemodeid = id;
		switch(id)
		{
			case 0:
				DialogueManager.dmanager.setDialogueCounter(1);
				break;
			case 1:
				DialogueManager.dmanager.setDialogueCounter(2);
				break;
			default:
				DialogueManager.dmanager.setDialogueCounter(0);
				break;
		}
		DialogueManager.dmanager.UpdateText();
    }
	
	public int getGamemodeId()
	{
		return this.gamemodeid;
	}
	
	public void gameStart()
	{
		switch(gamemodeid)
		{
			case 0:
				tutorialLoop();
				break;
			case 1:
				enduranceLoop();
				break;
			default:
				Debug.Log("Default exit gameStart()");
				break;
		}
	}
	
	public void tutorialLoop()
	{
		if (DialogueManager.dmanager.getDialogueCounter() < 3){
			DialogueManager.dmanager.setDialogueCounter(3);
			DialogueManager.dmanager.UpdateText();
			DialogueManager.dmanager.increment();
		}
		ComboChecker.combochecker.setComboList(generateComboList(gamemodeid));
		Preview.SetActive(true);
		for(int i = 0; i < buttons.Length; i++){
			buttons[i].SetActive(false);
		}
		switch(DialogueManager.dmanager.getDialogueCounter())
		{
			case 4:
				DialogueManager.dmanager.Invoke("UpdateText", 3.0f);
				DialogueManager.dmanager.Invoke("increment", 4.0f);
				DialogueManager.dmanager.Invoke("UpdateText", 9.0f);
				DialogueManager.dmanager.Invoke("increment", 9.5f);
				DialogueManager.dmanager.Invoke("UpdateText", 12.5f);
				DialogueManager.dmanager.Invoke("increment", 13.0f);
				PlayingField.playingfield.Invoke("showNextTarget", 15.0f);
				break;
			case 18:
				DialogueManager.dmanager.Invoke("UpdateText", 3.0f);
				DialogueManager.dmanager.Invoke("increment", 4.0f);
				DialogueManager.dmanager.Invoke("UpdateText", 7.0f);
				DialogueManager.dmanager.Invoke("increment", 7.5f);
				PlayingField.playingfield.Invoke("showNextTarget", 8.0f);
				break;
			default:
				DialogueManager.dmanager.Invoke("UpdateText", 3.0f);
				DialogueManager.dmanager.Invoke("increment", 4.0f);
				PlayingField.playingfield.Invoke("showNextTarget", 8.0f);
				break;
		}
	}
	
	public void enduranceLoop()
	{
		ComboChecker.combochecker.setComboList(generateComboList(gamemodeid));
		Preview.SetActive(true);
		for(int i = 0; i < buttons.Length; i++){
			buttons[i].SetActive(false);
		}
		PlayingField.playingfield.Invoke("showNextTarget", 1.0f);
	}

    private int[] generateComboList(int id)
    {

        if (id == 0)
        {
			var list = new List<int>();
			list.Clear();
            switch (DialogueManager.dmanager.getTutorialCounter())
			{
				case 0:
					list.Add(1);
					break;
				case 1:
					list.Add(2);
					break;
				case 2:
					list.Add(3);
					break;
				case 3:
					list.Add(4);
					break;
				case 4:
					list.Add(5);
					break;
				case 5:
					list.Add(6);
					break;
				case 6:
					list.Add(1);
					list.Add(2);
					break;
				case 7:
					list.Add(1);
					list.Add(2);
					list.Add(3);
					break;
				case 8:
					list.Add(1);
					list.Add(2);
					list.Add(3);
					list.Add(4);
					break;
				case 9:
					list.Add(1);
					list.Add(2);
					list.Add(3);
					list.Add(6);
					break;
				case 10:
					list.Add(1);
					list.Add(1);
					list.Add(4);
					break;
			}
			var array = list.ToArray();
			return array;
        }

        else if (id == 1)
        {

            int[] randomlist = new int[10];

            for (int i = 0; i < randomlist.Length; i++)
            {
                randomlist[i] = Random.Range(1, 7);
            }

            Debug.Log("Combolänge: " + randomlist.Length);
            Debug.Log("Combo:");
            for (int i = 0; i < randomlist.Length; i++)
            {
                Debug.Log(randomlist[i]);
            }

            return randomlist;
        }
        else
        {
            return null;
        }

    }
}