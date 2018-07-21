using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour 
{

	public int pickupType;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter(Collision collider)
	{
		
		Debug.Log("Collision Enter");
		if(collider.gameObject.GetComponent<Player>() != null
		&& collider.gameObject.tag == "Player")
		{
			Debug.Log("Player collides with pickup item");
			collider.gameObject.GetComponent<Player>().PickupItem(pickupType);
			Destroy(gameObject);
		}
	}

}
