using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemode : MonoBehaviour
{
    private int gamemodeid;
	private int tutorialcounter;
	public GameObject[] buttons = new GameObject[3];
	public GameObject Preview;
	public Text titel;
	public Text description;
	private string[] titelStore = {"Jab", "Cross", "Left Hook", "Right Hook", "Left Uppercut", "Right Uppercut", "Combo 1", "Combo 2", "Combo 3", "Combo 4", "Combo 5"};
	private string[] descStore = {"Jab", "Cross", "Left Hook", "Right Hook", "Left Uppercut", "Right Uppercut", "Combo 1", "Combo 2", "Combo 3", "Combo 4", "Combo 5"};
	
    public static Gamemode gamemode;

    public void Awake()
    {
        gamemode = this;
		Preview.SetActive(false);
		tutorialcounter = 0;
    }
	
	public void Start()
	{
		//setGamemodeID(0);
	}


    public void setGamemodeID(int id)
    {
		// Hier könnte man Beschreibungen der Spielmodi in der 
		// UI anzeigen lassen.
        this.gamemodeid = id;
    }
	
	public void gameStart()
	{
		ComboChecker.combochecker.setComboList(generateComboList(gamemodeid));
		Preview.SetActive(true);
		for(int i = 0; i < buttons.Length; i++){
			buttons[i].SetActive(false);
		}
		titel.text = titelStore[Gamemode.gamemode.getTutorialCounter()];
			description.text = descStore[Gamemode.gamemode.getTutorialCounter()];
        PlayingField.playingfield.Invoke("showNextTarget", 5.0f);
	}

    private int[] generateComboList(int id)
    {

        if (id == 0)
        {
			var list = new List<int>();
			list.Clear();
            switch (tutorialcounter)
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
	
	public void setTutorialCounter(int i){
		this.tutorialcounter = i;
	}
	
	public int getTutorialCounter(){
		return this.tutorialcounter;
	}
}
