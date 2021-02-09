using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{

    public bool isLeft;

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.gameObject.name);
        
        // checkt ob der schlag in der Combo grade auch auszuführen ist.
        // man kann hier noch eine Fehler respons mit einem else statement hinzufügen.
       
        
        
        if (other.gameObject.name == ComboChecker.combochecker.getComboList()[0].ToString())
        {
            //Debug.Log("IsLeft: " + isLeft + " Getroffenes Ziel: " + ComboChecker.combochecker.getComboList()[0] + " Mod2: " + (ComboChecker.combochecker.getComboList()[0] % 2 == 0));
            
            if(isLeft != (ComboChecker.combochecker.getComboList()[0] % 2 == 0))
            {
				other.gameObject.SetActive(false);
                ComboChecker.combochecker.bullseye();
            }

        }
       
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
