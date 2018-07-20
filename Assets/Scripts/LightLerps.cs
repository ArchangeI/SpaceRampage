using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLerps : MonoBehaviour 
{
	Vector3 newPosition;
	Vector3 defaultPosition;
	// Use this for initialization

	private void Awake() 
	{
		defaultPosition = newPosition = transform.position;
	}


	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		PositionChanging();
	}

	void PositionChanging()
	{
		Vector3 positionA = new Vector3(-5,5,0);
		Vector3 positionB = new Vector3(5,5,0);

		if(Input.GetKeyDown("a"))
		{
			newPosition = positionA;
		}
		if(Input.GetKeyDown("s"))
		{
			newPosition = defaultPosition;
		}
		if(Input.GetKeyDown("d"))
		{
			newPosition = positionB;
		}

		transform.position = Vector3.Lerp(transform.position, newPosition,Time.deltaTime*2);
	}
}
