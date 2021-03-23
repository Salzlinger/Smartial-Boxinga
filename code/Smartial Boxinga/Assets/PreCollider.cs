using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreCollider : MonoBehaviour
{
	
	private bool hitIndicator;
	
    // Start is called before the first frame update
    void Start()
    {
        hitIndicator = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public bool wasHit()
	{
		return hitIndicator;
	}
	
	public void hit()
	{
		hitIndicator = true;
	}

	public void resetHitIndicator()
	{
		hitIndicator = false;
	}
}