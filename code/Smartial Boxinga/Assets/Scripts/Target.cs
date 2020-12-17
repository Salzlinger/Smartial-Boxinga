using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public GameObject Observer;
	private bool m_isLeftTarget;
	private bool m_isChosen;

    void Update()
    {
		if(!m_isChosen)
		{
			ChooseHand();
		}
    }
	
	void OnTriggerEnter(Collider other)
	{
		if (m_isLeftTarget) {
			if(other.gameObject == GameObject.Find("LeftHand"))
			{
				Destroy(gameObject);
				ObserverScript.IGotTriggered();
				return;
			}
			else 
			{
				Debug.Log("Dieses Ziel mit der linken Hand schlagen!");
				return;
			}
		}
		else if (!m_isLeftTarget)
		{
			if(other.gameObject == GameObject.Find("RightHand"))
			{
				Destroy(gameObject);
				ObserverScript.IGotTriggered();
				return;
			}
			else 
			{
				Debug.Log("Dieses Ziel mit der rechten Hand schlagen!");
				return;
			}
		}
		
	}
	
	void ChooseHand()
	{
		if (gameObject.GetComponent<Renderer>().material.name == "RIndicator (Instance)")
		{
			m_isLeftTarget = false;
			m_isChosen = true;
		}
		else
		{
			m_isLeftTarget = true;
			m_isChosen = true;
		}
	}
}
