using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetR : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == GameObject.Find("RightHand"))
		{
			Destroy(gameObject);
		}
		else 
		{
			Debug.Log("Falsche Hand!");
		}
	}
}
