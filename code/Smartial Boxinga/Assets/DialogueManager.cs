using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	private int tutorialcounter;
	private int dialoguecounter;
	private bool tutorialrepeat;
	private string[] titelStore = {"", 
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
								   
	private string[] descStore = {"",
								  "In diesem Spielmodus können grundlegende Schläge und einfache Kombinationen geübt werden.",
								  "In diesem Spielmodus können an zufälligen Kombinationen Reaktionszeit und Ausdauer trainiert werden.", 
								  "Willkommen in meinem Dojo junger Schüler, hier behandeln wir die Grundlagen des Boxens.",
								  "Zuerst müssen wir richtig stehen, das heißt dominantes Bein nach vorne und Hände auf Wangenhöhe.",
								  "Aus dieser Position üben wir alle Schläge. Fangen wir mit dem Jab an. ",
								  "Der Jab ist ein gerader Schlag mit der führenden Hand.", 
								  "Gut! Der Jab wird oft verwendet, also trainiere ihn gewissenhaft.", 
								  "Der Cross ist das Gegenstück zum Jab, ein schneller Schlag mit der hinteren Hand.", 
								  "Ausgezeichnet. Denke daran die Hand mit der du nicht schlägst zum Blocken au Wangenhöhe zu halten,", 
								  "Der linke Haken ist ein kraftvoller Schlag mit der linken Hand gegen die Seite des Kopfes des Gegners.", 
								  "Gut. Der linke Haken bekommt viel Energie durch Rotation des Oberkörpers, das ist hier sehr wichtig.", 
								  "Jetzt zum rechten Haken, dieser wird äquivalent zum linken Haken mit rechts geschlagen.", 
								  "Das sieht doch schon ganz gut aus. Immer an die Rotation denken.", 
								  "Es folgt der linke Kinnhaken, ein von unten nach oben ausgeführter Schlag mit der linken Hand.", 
								  "Indem du Schub aus deinen Beinen mitnimmst kannst du diesen Schlag wesentlich stärker machen.", 
								  "Der rechte Kinnhaken wird wieder analog zum linken Kinnhaken mit der rechten Hand ausgeführt.",
								  "Auch hier wieder an die Bewegung der Beine denken, sonst geht dir Kraft verloren.",
								  "Nun wird es Zeit die gelernten Schläge in einfachen Kombinationen anzuwenden.",
								  "Fangen wir mit einer schnellen Jab-Cross Kombination an.", 
								  "Sehr schön. Diese schnelle Kombo kann verwendet werden, um langsamere Schläge vorzubereiten.", 
								  "Ein solcher Schlag ist der linke Haken. Setzen wir diesen an das Ende der schnellen Kombination.", 
								  "Genau so. Der Cross gibt dir genügend Zeit, deinen linken Haken zu setzen.", 
								  "Probieren wir die gleiche Kombo nochmal mit einem rechten Haken am Ende.", 
								  "Das sieht doch schon langsam aus wie echtes Boxen. Weiter so!", 
								  "Man kann den rechten Haken auch durch einen rechten Kinnhaken ersetzen. Probieren wir es aus.", 
								  "Hervorragend! Es ist wichtig, variabel in der Wahl seiner Schläge zu bleiben.", 
								  "Kombos müssen nicht immer abwechselnd linke und rechte Schläge sein, wie das nächste Beispiel zeigt.",
								  "Hervorragend. Mit ausreichend Übung kann aus dir ein echter Meister des Boxens werden!",
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
        hideRepeatButtons();
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
		try
		{
			this.titel.text = this.titelStore[this.dialoguecounter];
			this.description.text = this.descStore[this.dialoguecounter];
		}
		catch (Exception e)
		{
			if (this.dialoguecounter > this.descStore.Length -1)
			{
				Debug.Log("DialogueManager Exception e.");
				this.dialoguecounter = this.descStore.Length -1;
				UpdateText();
			}
		}
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
			showRepeatButtons();
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
				Gamemode.gamemode.Invoke("setComboInvokable", 15.0f);
				PlayingField.playingfield.Invoke("showNextTarget", 15.0f);
				break;
			case 18:
				Invoke("UpdateText", 3.0f);
				Invoke("increment", 4.0f);
				Invoke("UpdateText", 7.0f);
				Invoke("increment", 7.5f);
				Gamemode.gamemode.Invoke("setComboInvokable", 8.0f);
				PlayingField.playingfield.Invoke("showNextTarget", 8.0f);
				break;
			default:
				if(!tutorialrepeat)
				{
					Invoke("UpdateText", 3.0f);
					Invoke("increment", 4.0f);
					Gamemode.gamemode.Invoke("setComboInvokable", 8.0f);
					PlayingField.playingfield.Invoke("showNextTarget", 8.0f);
				}
				else
				{
					UpdateText();
					Gamemode.gamemode.Invoke("setComboInvokable", 4.0f);
					PlayingField.playingfield.Invoke("showNextTarget", 4.0f);
				}
				break;
		}
	}
	
	public void RepeatPunch(int pnr)
	{
		tutorialrepeat = true;
		showRepeatButtons();
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
	
	public void hideRepeatButtons()
	{
		foreach(GameObject o in repeatbuttons)
		{
			o.SetActive(false);
		}
	}
	
	public void resetTutorial()
	{
		CancelInvoke();
		setTutorialRepeat(false);
		setDialogueCounter(0);
		setTutorialCounter(0);
		hideRepeatButtons();
	}
}
