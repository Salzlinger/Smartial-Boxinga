using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboPreview : MonoBehaviour
{
	public Text[] nexthits;
	
    void Update()
    {
		switch(ComboChecker.combochecker.getComboList().Length)
		{
			case 0:
				for (int i = 0; i < nexthits.Length; i++)
				{
					nexthits[i].text = "";
				}
				break;
			case 1:
				nexthits[0].text = returnHit(0);
				nexthits[1].text = "";
				nexthits[2].text = "";
				break;
			case 2:
				nexthits[0].text = returnHit(0);
				nexthits[1].text = returnHit(1);
				nexthits[2].text = "";
				break;
			default:
				for (int i = 0; i < nexthits.Length; i++)
				{
					nexthits[i].text = returnHit(i);
				}
				break;
		}
    }
	
	private string returnHit (int i){
		return ComboChecker.combochecker.getComboList()[i].ToString();
	}
	
}
