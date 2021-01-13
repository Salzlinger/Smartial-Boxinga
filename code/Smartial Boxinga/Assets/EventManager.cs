using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event EventHandler OnHit;

    private void Start()
    {
        OnHit += Testing_OnHit;
    }

    private void Testing_OnHit(object sender, EventArgs e)
    {
        Debug.Log("Fire!");
    }

    public void hit()
    {
        if (OnHit != null)
        {
            OnHit(this, EventArgs.Empty);
        }
    } 
}
