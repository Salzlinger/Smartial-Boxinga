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
								   "Tutorial Ende"
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
								  "Das waren die Grundlegenden Schläge und einfache Kombinationen. Möchtest du etwas bestimmtes wiederholen?"
								  };
	
	public Text titel;
	public Text description;
	
	public static DialogueManager dmanager;
	
	public void Awake() {
		dmanager = this;
		tutorialcounter = 0;
		dialoguecounter = 0;
		tutorialrepeat = false;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
