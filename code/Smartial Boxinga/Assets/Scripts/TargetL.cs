using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetL : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == GameObject.Find("LeftHand"))
		{
			Destroy(gameObject);
		}
		else 
		{
			Debug.Log("Falsche Hand!");
		}
	}
}
