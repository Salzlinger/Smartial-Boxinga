using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStage : MonoBehaviour
{
    public GameObject jab;
    public GameObject cross;
    public GameObject hookl;
    public GameObject hookr;
    public GameObject upperl;
    public GameObject upperr;

    public void StartGame()
    {
        Destroy(GameObject.Find("Dialog1"));
        


        for (int i = 0; i < comboChecker.comboList.Length; i++)
        {
            switch (comboChecker.comboList[i])
            {
                case "jab":
                    Instantiate(jab, new Vector3(0, 2, 2 * i), Quaternion.identity);
                    break;
                case "cross":
                    Instantiate(cross, new Vector3(0, 2, 2 * i), Quaternion.identity);
                    break;
                case "hookl":
                    Instantiate(hookl, new Vector3(0, 2, 2 * i), Quaternion.identity);
                    break;
                case "hookr":
                    Instantiate(hookr, new Vector3(0, 2, 2 * i), Quaternion.identity);
                    break;
                case "upperl":
                    Instantiate(upperl, new Vector3(0, 2, 2 * i), Quaternion.identity);
                    break;
                case "upperr":
                    Instantiate(upperr, new Vector3(0, 2, 2 * i), Quaternion.identity);
                    break;

            }
        }

    }
}
