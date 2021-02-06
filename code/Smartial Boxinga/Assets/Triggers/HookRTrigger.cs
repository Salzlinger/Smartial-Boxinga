using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRTrigger : MonoBehaviour
{


    public comboChecker combochecker;
    private void OnTriggerEnter(Collider other)
    {
        // checkt ob der schlag in der Combo grade auch auszuführen ist.
        // man kann hier noch eine Fehler respons mit einem else statement hinzufügen.
        if (comboChecker.comboList[0] == "hookr")
        {
            if (combochecker != null)
            {
                combochecker.bullseye();
                Destroy(gameObject);
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
