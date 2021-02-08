using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComboChecker : MonoBehaviour
{
    // Array welches mit der auszuführenden Combo befüllt wird
    private int[] combolist;
    public static ComboChecker combochecker;

    private void Awake()
    {
        combochecker = this;
    }

    public int[] getComboList ()
    {
        return combolist;
    }

    public void setComboList (int[] newcombolist)
    {
        combolist = newcombolist;
    }

    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // entfernt das getroffene Ziel aus dem Array
    public void bullseye ()
    {
        //Debug.Log("Ziel wurde getroffen!");
        for (int i = 0; i < combolist.Length - 1; i++)
        {
            combolist[i] = combolist[i + 1];
        }
        System.Array.Resize(ref combolist, combolist.Length - 1);
        Debug.Log("Anzahl restliche Ziele: " + combolist.Length);
        Debug.Log("Nächstes Ziel: " + combolist[0]);
        if(combolist.Length > 0)
        {
            PlayingField.playingfield.showNextTarget();
        }
        
    }




}
