using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour
{
    private int[] tutorialcombolist = { 1, 2, 3 };
    private int gamemodeid;

    public static Gamemode gamemode;

    public void Awake()
    {
        gamemode = this;
    }


    public void setGamemodeID(int id)
    {
        gamemodeid = id;

        ComboChecker.combochecker.setComboList(generateComboList(id));

        PlayingField.playingfield.startGame();
    }

    private int[] generateComboList(int id)
    {

        if (id == 0)
        {
            return tutorialcombolist;
        }

        else if (id == 1)
        {

            int[] randomlist = new int[50];

            for (int i = 0; i < randomlist.Length; i++)
            {
                randomlist[i] = Random.Range(1, 7);
            }

            Debug.Log("Combolänge: " + randomlist.Length);
            Debug.Log("Combo:");
            for (int i = 0; i < randomlist.Length; i++)
            {
                Debug.Log(randomlist[i]);
            }

            return randomlist;
        }
        else
        {
            return null;
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
