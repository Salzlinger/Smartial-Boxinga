using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboGenerator : MonoBehaviour
{
	public GameObject[] TargetPrefabs;
	public static ComboGenerator C1;
		
	private static readonly System.Random _random = new System.Random();
	private static readonly object syncLock = new object();
	
	void Awake()
	{
		C1 = this;
	}
	
	public void ButtonCall()
	{
		int length = 3;
		GameObject[] comboArray = new GameObject[3];
		for(int i = 0; i < length; i++)
		{
			int j = randomNumber(0, 5);
			Debug.Log(TargetPrefabs[j]);
			Debug.Log(comboArray[i]);
			comboArray[i] = TargetPrefabs[j];
			Debug.Log(j);
		}
		ObserverScript.SetComboArray(comboArray);
	}
	
	public static int randomNumber(int min, int max)
	{
		lock(syncLock) {
			return _random.Next(min, max);
		}
	}
}
