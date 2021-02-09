using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboPreview : MonoBehaviour
{
	
	public Text nexthit;
	public Text nexthit2;
	public Text nexthit3;
	
    void Update()
    {
		switch(ComboChecker.combochecker.getComboList().Length)
		{
			case 0:
				nexthit.text = "";
				nexthit2.text = "";
				nexthit3.text = "";
				break;
			case 1:
				nexthit.text = returnHit(0);
				nexthit2.text = "";
				nexthit3.text = "";
				break;
			case 2:
				nexthit.text = returnHit(0);
				nexthit2.text = returnHit(1);
				nexthit3.text = "";
				break;
			default:
				nexthit.text = returnHit(0);
				nexthit2.text = returnHit(1);
				nexthit3.text = returnHit(2);
				break;
		}
    }
	
	private string returnHit (int i){
		return ComboChecker.combochecker.getComboList()[i].ToString();
	}
}
