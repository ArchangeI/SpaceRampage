using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun 
{

	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
		if(Input.GetMouseButtonDown(0) && (Time.time - lastFireTime)
		> fireRate)
		{
			lastFireTime = Time.time;
			Fire();
		}	
	}
}
