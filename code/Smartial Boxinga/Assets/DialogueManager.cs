using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	private int tutorialcounter;
	private int dialoguecounter;
	private bool tutorialrepeat;
	private string[] titelStore = {"Empty", 
								   "Tutorial-Modus", 
								   "Zufalls-Modus", 
								   "Begrüßung A",								   
								   "Begrüßung B",								   
								   "Begrüßung C",								   
								   "Jab-Erklärung", 
								   "Jab-Lob", 
								   "Cross-Erklärung", 
								   "Cross-Lob", 
								   "Left Hook Erklärung", 
								   "Left Hook Lob", 
								   "Right Hook Erklärung", 
								   "Right Hook Lob", 
								   "Left Uppercut Erklärung", 
								   "Left Uppercut Lob", 
								   "Right Uppercut Erklärung",
								   "Right Uppercut Lob",
								   "Combo Erklärung",
								   "Combo 1 Erklärung", 
								   "Combo 1 Lob", 
								   "Combo 2 Erklärung", 
								   "Combo 2 Lob", 
								   "Combo 3 Erklärung", 
								   "Combo 3 Lob", 
								   "Combo 4 Erklärung", 
								   "Combo 4 Lob", 
								   "Combo 5 Erklärung",
								   "Combo 5 Lob",
								   "Tutorial Ende",
								   "Tutorial Repeat"
								   };
								   
	private string[] descStore = {"Empty",
								  "In diesem Spielmodus können grundlegende Schläge und einfache Kombinationen geübt werden.",
								  "In diesem Spielmodus können an zufälligen Kombinationen Reaktionszeit und Ausdauer trainiert werden.", 
								  "Willkommen in meinem Dojo junger Schüler, hier behandeln wir die Grundlagen des Boxens.",
								  "Zuerst müssen wir richtig stehen, das heißt dominantes Bein nach vorne und Hände auf Wangenhöhe.",
								  "Aus dieser Position üben wir alle Schläge. Fangen wir mit dem Jab an. ",
								  "Der Jab ist ein gerader Schlag mit der führenden Hand.", 
								  "Gut! Der Jab wird oft verwendet, also trainiere ihn gewissenhaft.", 
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
								  "Das waren die Grundlegenden Schläge und einfache Kombinationen. Möchtest du etwas bestimmtes wiederholen?",
								  "Möchtest du einen anderen Schlag trainieren?"
								  };
	
	public Text titel;
	public Text description;
	public GameObject[] repeatbuttons;
	
	public static DialogueManager dmanager;
	
	public void Awake() {
		dmanager = this;
		tutorialcounter = 0;
		dialoguecounter = 0;
		tutorialrepeat = false;
	}
	
    void Start()
    {
        foreach(GameObject o in repeatbuttons)
		{
			o.SetActive(false);
		}
		// Zum Testen der Wiederholungsfunktion
		//tutorialcounter = 10;
    }

    void Update()
    {
        
    }
	
	public void increment(){
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
	
	public void comboFinished()
	{
		if(!tutorialrepeat)
		{
			tutorialcounter++;
			if(tutorialcounter > 10)
			{
				UpdateText();
				dialoguecounter++;
				Invoke("UpdateText", 3.0f);
				Invoke("showRepeatButtons", 3.0f);
				/*
				for(int i = 0; i < Gamemode.gamemode.buttons.Length; i++){
					Gamemode.gamemode.buttons[i].SetActive(true);
				}
				*/
				tutorialcounter = 0;
			}
			else
			{
				UpdateText();
				dialoguecounter++;
				Gamemode.gamemode.gameStart();
			}
		}
		else
		{
			tutorialcounter = 0;
			dialoguecounter = 30;
			UpdateText();
			foreach(GameObject o in repeatbuttons)
			{
				o.SetActive(true);
			}
		}
	}
	
	public void endurancePlus(string input)
	{
		titel.text = "Anzahl geschlagener Ziele:";
		description.text = input;
	}
	
	public void updateGamemodeDesc(int id)
	{
		switch(id)
		{
			case 0:
				dialoguecounter = 1;
				// Zum Testen der Wiederholungsfunktion
				//dialoguecounter = 27;
				break;
			case 1:
				dialoguecounter = 2;
				break;
			default:
				dialoguecounter = 0;
				break;
		}
		UpdateText();
	}
	
	public void firstMessageException()
	{
		if (dialoguecounter < 3){
			dialoguecounter = 3;
			UpdateText();
			dialoguecounter++;
		}
	}
	
	public void dialogueSwitch()
	{
		switch(dialoguecounter)
		{
			case 4:
				Invoke("UpdateText", 3.0f);
				Invoke("increment", 4.0f);
				Invoke("UpdateText", 9.0f);
				Invoke("increment", 9.5f);
				Invoke("UpdateText", 12.5f);
				Invoke("increment", 13.0f);
				PlayingField.playingfield.Invoke("showNextTarget", 15.0f);
				break;
			case 18:
				Invoke("UpdateText", 3.0f);
				Invoke("increment", 4.0f);
				Invoke("UpdateText", 7.0f);
				Invoke("increment", 7.5f);
				PlayingField.playingfield.Invoke("showNextTarget", 8.0f);
				break;
			default:
				if(!tutorialrepeat)
				{
					Invoke("UpdateText", 3.0f);
					Invoke("increment", 4.0f);
					PlayingField.playingfield.Invoke("showNextTarget", 8.0f);
				}
				else
				{
					UpdateText();
					PlayingField.playingfield.Invoke("showNextTarget", 4.0f);
				}
				break;
		}
	}
	
	public void RepeatPunch(int pnr)
	{
		tutorialrepeat = true;
		foreach(GameObject o in repeatbuttons)
			{
				o.SetActive(true);
			}
		switch(pnr)
		{
			case 1:
				tutorialcounter = 0;
				dialoguecounter = 6;
				break;
			case 2:
				tutorialcounter = 1;
				dialoguecounter = 8;
				break;
			case 3:
				tutorialcounter = 2;
				dialoguecounter = 10;
				break;
			case 4:
				tutorialcounter = 3;
				dialoguecounter = 12;
				break;
			case 5:
				tutorialcounter = 4;
				dialoguecounter = 14;
				break;
			case 6:
				tutorialcounter = 5;
				dialoguecounter = 16;
				break;
			default:
				Debug.Log("Default Exit RepeatPunch()");
				break;
		}
		Gamemode.gamemode.tutorialLoop();
	}
	
	public void showRepeatButtons()
	{
		foreach(GameObject o in repeatbuttons)
		{
			o.SetActive(true);
		}
	}
}
