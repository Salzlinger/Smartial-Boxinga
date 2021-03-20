using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{

    public bool isLeft;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TutorialTarget")
		{
			Gamemode.gamemode.setGamemodeID(0);
			Gamemode.gamemode.tutorialStart();
		}
		else if (other.gameObject.name == "RandomTarget")
		{
			Gamemode.gamemode.setGamemodeID(1);
			Gamemode.gamemode.enduranceStart();
		}
        else if (other.gameObject.name == ComboChecker.combochecker.getComboList()[0].ToString())
        {
            if(isLeft != (ComboChecker.combochecker.getComboList()[0] % 2 == 0))
            {
				other.gameObject.SetActive(false);
				ComboChecker.combochecker.bullseye();
            }
        }
    }
}
