using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayingField : MonoBehaviour
{
    public GameObject[] targets = new GameObject[6];
	public VideoClip[] clips = new VideoClip[6];
	public VideoPlayer player;
	public RawImage punch;
    public static PlayingField playingfield;
	
	private bool imagevisible;
	
    public void Awake()
    {
        playingfield = this;
        hideTargets();
    }

	
    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("Ambient"); //Fängt an Ambiente Sound abzuspielen
        FindObjectOfType<AudioManager>().Play("MenuOST"); 
		imagevisible = false;
		punch.color = new Color(255, 255, 255, 0);
    }

    public void showNextTarget()
    {
		try
		{
        targets[ComboChecker.combochecker.getComboList()[0] - 1].SetActive(true);
		if(DialogueManager.dmanager.tutorialPositionSwitch() != 0)
		{
			switchRawImage();
			player.clip = clips[DialogueManager.dmanager.tutorialPositionSwitch()];
		}
		}
		catch(IndexOutOfRangeException e)
		{
			if (ComboChecker.combochecker.getComboList().Length == 0)
			{
				Debug.Log("Playingfield Exception e.");
			}
		}
	}
	
	public void hideTargets()
	{
		CancelInvoke();
		for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(false);
        }
	}
	
	public void switchRawImage()
	{
		if(imagevisible)
		{
			punch.color = new Color(255, 255, 255, 0);
			imagevisible = false;
		}
		else
		{
			punch.color = new Color(255, 255, 255, 150);
			imagevisible = true;
		}
	}
}