﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour 
{
	[SerializeField]
	private string robotType;
	public int health;
	public int fireRate;
	public int range;

	public Transform missileFireSpot;
	[SerializeField]
	GameObject missilePrefab;
	private NavMeshAgent agent;
	// Use this for initialization
	private Transform player;
	private float timeLastFired;
	private bool isDead;

	public Animator robot;

	void Start () 
	{
		isDead = false;
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;		

	}	
	
	// Update is called once per frame
	void Update () 
	{
		
		transform.LookAt(player);
		agent.SetDestination(player.position);
		if(Vector3.Distance(transform.position, player.position) < range 
		&& (Time.time - timeLastFired) > fireRate)
		{
			timeLastFired = Time.time;
			fire();
		}


	}

	public void TakeDamage(int amount)
	{
		if(isDead)
		{
			return;
		}
		health -= amount;
		Debug.Log("ROBOT IS hit");
		if(health <= 0)
		{
			isDead = true;
			robot.Play("Die");
			Debug.Log("ROBOT IS DEAAAAAAD");
			StartCoroutine("DestroyRobot");
		}
	}

	private void OnDestroy() 
	{
		Debug.Log("ROBOT IS DESTROYED");
	}
	IEnumerable DestroyRobot()
	{
		yield return new WaitForSeconds(1.5f);
		gameObject.SetActive(false);
		Destroy(gameObject);
	}

	void fire()
	{
		GameObject missile = Instantiate(missilePrefab);
		missile.transform.position = missileFireSpot.transform.position;
		missile.transform.rotation = missileFireSpot.transform.rotation;
		robot.Play("Fire");
	}
}
