using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun 
{



	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();
		if(Input.GetMouseButtonDown(0) && (Time.time - lastFireTime) 
			> fireRate) //checks whether enough time
			// has elapsed between shots to allow one
		{
			lastFireTime = Time.time;
			Fire();
		}
	}
}
