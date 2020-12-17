using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverScript : MonoBehaviour
{
	private static GameObject[] m_comboArray = new GameObject[3]; //Kombobauplan, enthält jeweils die einzelnen Prefabs die instanziiert werden sollen
    private static bool[] m_correctPunches = new bool[3];
    private static int m_currentTargetNr;
	private float m_height;
	
    void Start()
    {
        m_currentTargetNr = 0;
		m_height = 1f;
    }

    void Update()
    {
		if(m_currentTargetNr == 3 && m_correctPunches[2])
		{
			ComboGenerator.C1.ButtonCall();
			InstantiateComboPieces();
			m_currentTargetNr = 0;
		}		   
    }
	
	public static void IGotTriggered()
    {
        Debug.Log("Nachricht an Observer senden.");
		m_correctPunches[m_currentTargetNr] = true;
		Debug.Log(m_correctPunches[m_currentTargetNr]);
		Debug.Log(m_currentTargetNr);
		m_currentTargetNr++;  
    }
	
	public void SetCorrectPunch()
    {
        m_correctPunches[m_currentTargetNr] = true;
        m_currentTargetNr += 1;
    }
	
	public static void SetComboArray(GameObject[] array)
    {
        m_comboArray = array; 
    }
	
	public void InstantiateComboPieces()
	{
		Debug.Log("Ich wurde gerufen.");
		for (int i = 0; i < m_comboArray.Length; i++)
		{
			Debug.Log(i);
			Debug.Log(m_comboArray[i]);
			Instantiate(m_comboArray[i], new Vector3(-0.5f, m_height, i * 0.5f), Quaternion.Euler(0f, 0f, -90.0f));
		}
		m_height += 0.5f;
	}
}
