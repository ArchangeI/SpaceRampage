using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour 
{
	
	private float speed = 30f;
	private int damage = 10;
	// Use this for initialization
	void Start() 
	{
		StartCoroutine("deathTime");
	}
	
	// Update is called once per frame
	void Update() 
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collider) 
	{
		
		if(collider.gameObject.GetComponent<Player>() != null 
		&& collider.gameObject.tag == "Player")
		{
			collider.gameObject.GetComponent<Player>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}
	IEnumerable deathTime()
	{
		
		yield return new WaitForSeconds(10);
		
		Destroy(gameObject);
		
	}
}
