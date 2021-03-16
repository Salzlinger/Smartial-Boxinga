using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemode : MonoBehaviour
{
    private int gamemodeid;
	private int tutorialcounter;
	private int dialoguecounter;
	private bool tutorialrepeat;
	private string[] titelStore = {"Empty", 
								   "Tutorial-Modus", 
								   "Zufalls-Modus", 
								   "Begrüßung", 
								   "Jab-Erklärung", 
								   "Jab-Lob", 
								   "Cross-Erklärung", 
								   "Cross-Lob", 
								   "Left Hook", 
								   "Left Hook B", 
								   "Right Hook", 
								   "Right Hook B", 
								   "Left Uppercut", 
								   "Left Uppercut B", 
								   "Right Uppercut",
								   "Right Uppercut B",
								   "Combo Erklärung",
								   "Combo 1", 
								   "Combo 1 B", 
								   "Combo 2", 
								   "Combo 2 B", 
								   "Combo 3", 
								   "Combo 3 B", 
								   "Combo 4", 
								   "Combo 4 B", 
								   "Combo 5",
								   "Combo 5 B",
								   "Tutorial Ende"
								   };
								   
	private string[] descStore = {"Empty",
								  "In diesem Spielmodus können grundlegende Schläge und einfache Kombinationen geübt werden.",
								  "In diesem Spielmodus https://www.youtube.com/watch?v=dQw4w9WgXcQ", 
								  "Begrüßung", 
								  "Jab-Erklärung", 
								  "Jab-Lob", 
								  "Cross-Erklärung", 
								  "Cross-Lob", 
								  "Left Hook", 
								  "Left Hook B", 
								  "Right Hook", 
								  "Right Hook B", 
								  "Left Uppercut", 
								  "Left Uppercut B", 
								  "Right Uppercut",
								  "Right Uppercut B",
								  "Combo Erklärung",
								  "Combo 1", 
								  "Combo 1 B", 
								  "Combo 2", 
								  "Combo 2 B", 
								  "Combo 3", 
								  "Combo 3 B", 
								  "Combo 4", 
								  "Combo 4 B", 
								  "Combo 5",
								  "Combo 5 B",
								  "Das waren die Grundlegenden Schläge und einfache Kombinationen. Möchtest du etwas bestimmtes wiederholen?"
								  };
	
    public static Gamemode gamemode;

	public GameObject[] buttons = new GameObject[3];
	public GameObject Preview;
	public Text titel;
	public Text description;
	
    public void Awake()
    {
        gamemode = this;
		Preview.SetActive(false);
		tutorialcounter = 0;
		dialoguecounter = 0;
		tutorialrepeat = false;
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
				this.setDialogueCounter(1);
				break;
			case 1:
				this.setDialogueCounter(2);
				break;
			default:
				this.setDialogueCounter(0);
				break;
		}
		UpdateText();
    }
	
	public void gameStart()
	{
		// Hier müsste der erste Dialog aufgerufen werden.
		if (dialoguecounter < 3){
			dialoguecounter = 3;
			UpdateText();
			dialoguecounter++;
		}
		ComboChecker.combochecker.setComboList(generateComboList(gamemodeid));
		Preview.SetActive(true);
		for(int i = 0; i < buttons.Length; i++){
			buttons[i].SetActive(false);
		}
		if (dialoguecounter != 16)
		{
			Invoke("UpdateText", 3.0f);
			Invoke("increment", 4.0f);
			PlayingField.playingfield.Invoke("showNextTarget", 8.0f);
		}
		else 
		{
			//Jetzt machen wir den Übergang zu einfachen Kombinationen. Delay muss hiernach evtl etwas größer sein.
			Invoke("UpdateText", 3.0f);
			Invoke("increment", 4.0f);
			//Evtl. größeres Delay
			Invoke("UpdateText", 7.0f);
			Invoke("increment", 7.5f);
			PlayingField.playingfield.Invoke("showNextTarget", 8.0f);
		}
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
	
	private void increment(){
		this.dialoguecounter += 1;
	}
	
	public void setTutorialCounter(int i){
		this.tutorialcounter = i;
	}
	
	public int getTutorialCounter(){
		return this.tutorialcounter;
	}
	
	public void setDialogueCounter(int i){
		this.dialoguecounter = i;
	}
	
	public int getDialogueCounter(){
		return this.dialoguecounter;
	}
	
	public void UpdateText(){
		this.titel.text = this.titelStore[this.dialoguecounter];
		this.description.text = this.descStore[this.dialoguecounter];
	}
	
	public void setTutorialRepeat(bool b){
		this.tutorialrepeat = b;
	}
	
	public bool getTutorialRepeat(){
		return this.tutorialrepeat;
	}
}