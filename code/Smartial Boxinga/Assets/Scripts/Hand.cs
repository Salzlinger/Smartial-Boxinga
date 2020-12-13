using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject targetPrefabL;
	public GameObject targetPrefabR;
	private TextMesh m_comboPreview;
	private int m_copyCount;
	
    void Start()
    {
		m_copyCount = 0;
		Debug.Log("Jab links.");
		m_comboPreview = GameObject.Find("Kombovorschau").GetComponent<TextMesh>();
		m_comboPreview.text = "Jab links.";
    }

    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider other)
	{
		m_copyCount++;
		// float zmove;
		// zmove = 5 * m_copyCount;
		Destroy(other.gameObject);
		switch(m_copyCount)
		{
			case 1:
				Instantiate(targetPrefabR, new Vector3(2, 2, 2), Quaternion.Euler(0f, 0f, 270f));
				Debug.Log("Jab rechts.");
				m_comboPreview.text = "Jab rechts.";
				break;
			case 2:
				Instantiate(targetPrefabL, new Vector3(2, 5, 2), Quaternion.Euler(0f, 35f, 270f));
				Debug.Log("Cross links.");
				m_comboPreview.text = "Cross links.";
				break;
			case 3:
				Instantiate(targetPrefabR, new Vector3(2, 5, 0), Quaternion.Euler(0f, -35f, 270f));
				Debug.Log("Cross rechts.");
				m_comboPreview.text = "Cross rechts.";
				break;
			case 4:
				Instantiate(targetPrefabL, new Vector3(2, 2, 0), Quaternion.Euler(0f, 90f, 270f));
				Debug.Log("Hook links.");
				m_comboPreview.text = "Hook links..";
				break;
			case 5:
				Instantiate(targetPrefabR, new Vector3(2, 2, 2), Quaternion.Euler(0f, -90f, 270f));
				Debug.Log("Hook rechts.");
				m_comboPreview.text = "Hook rechts.";
				break;
			default:
				Instantiate(targetPrefabL, new Vector3(2, 2, 0), Quaternion.Euler(0f, 0f, 270f));
				m_copyCount = 0;
				Debug.Log("Jab links.");
				m_comboPreview.text = "Jab links.";
				break;
		}
	}
}
