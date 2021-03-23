using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{

    public bool isLeft;
	private GameObject lastHit;
	
    private void OnTriggerEnter(Collider other)
    {
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
}
