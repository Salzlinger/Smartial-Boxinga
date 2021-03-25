using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{

    public bool isLeft;
	private GameObject lastHit;
	
    private void OnTriggerEnter(Collider other)
    {
		playHitSound();
		if (other.gameObject.CompareTag("PreCollider"))
		{
			lastHit = other.gameObject;
		}
        else if (other.gameObject.name == "TutorialTarget")
		{
			Gamemode.gamemode.setGamemodeID(0);
			Gamemode.gamemode.tutorialStart();
		}
		else if (other.gameObject.name == "RandomTarget")
		{
			Gamemode.gamemode.setGamemodeID(1);
			Gamemode.gamemode.enduranceStart();
		}
        else if (other.gameObject.transform.parent.name == ComboChecker.combochecker.getComboList()[0].ToString() && lastHit.transform.parent == other.gameObject.transform.parent)
        {
            if(isLeft != (ComboChecker.combochecker.getComboList()[0] % 2 == 0))
            {
				if(other.gameObject.CompareTag("CenterCollider"))
				{
					ComboChecker.combochecker.lastHitGood();
				}
				other.gameObject.transform.parent.gameObject.SetActive(false);
				ComboChecker.combochecker.bullseye();
            }
        }
       
    }
    

    private void playHitSound()
    {
        string[] soundnames = { "Hit1", "Hit2", "Hit3" };
        int r = Random.Range(0, 3);

        FindObjectOfType<AudioManager>().Play(soundnames[r]);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
