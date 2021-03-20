using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemode : MonoBehaviour
{
    private int gamemodeid;
	
    public static Gamemode gamemode;

	public GameObject[] targets	= new GameObject[2];
	public GameObject Preview;
	
    public void Awake()
    {
        gamemode = this;
    }

    public void setGamemodeID(int id)
    {
		this.gamemodeid = id;
		DialogueManager.dmanager.updateGamemodeDesc(id);
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
		DialogueManager.dmanager.firstMessageException();
		DialogueManager.dmanager.dialogueSwitch();
	}
	
	public void enduranceLoop()
	{
		ComboChecker.combochecker.setComboList(generateComboList());
		PlayingField.playingfield.showNextTarget();
	}
	
	public void tutorialStart()
	{
		gamemodeEnd(1);
		// targets[0].SetActive(false);
		gameStart();
	}
	
	public void enduranceStart()
	{
		gamemodeEnd(0);
		// targets[1].SetActive(false);
		DialogueManager.dmanager.Invoke("UpdateText", 4.5f);
		Invoke("gameStart", 5.0f);
	}
	
	public void gamemodeEnd(int i)
	{
		CancelInvoke();
		// targets[i].SetActive(true);
		DialogueManager.dmanager.resetTutorial();
		ComboChecker.combochecker.clearComboList();
		PlayingField.playingfield.hideTargets();
	}

    private int[] generateComboList()
    {

        if (gamemodeid == 0)
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

        else if (gamemodeid == 1)
        {

            int[] randomlist = new int[10];

            for (int i = 0; i < randomlist.Length; i++)
            {
                randomlist[i] = Random.Range(1, 7);
            }
            return randomlist;
        }
        else
        {
            return null;
        }

    }
	
	public void setComboInvokable()
	{
		ComboChecker.combochecker.setComboList(generateComboList());
	}
}