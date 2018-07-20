using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
	public Ammo ammo;
	public AudioClip liveFire;
	public AudioClip dryFire;
	public float fireRate;
	protected float lastFireTime;


	public int damage;
	public int range;
	public float zoomFactor;

	private float zoomFOV;
	private float zoomSpeed = 6;

	// Use this for initialization
	void Start () 
	{
		zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
		lastFireTime = Time.time - 10;
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
		
	}
	
	protected void Fire()
	{
		if(ammo.HasAmmo(tag))
		{
			Debug.Log("ammo " + tag + " = " + ammo.GetAmmo(tag));
			AudioSource source = GetComponent<AudioSource>();
			
			// GetComponent<AudioSource>().PlayOneShot(liveFire);
			if(!source.isPlaying)
			{
				source.clip = liveFire;
				source.Play();
			}
			else
			{
				Debug.LogError("ERRORRRR");
			}
			ammo.ConsumeAmmo(tag);
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(dryFire);
		}
		GetComponentInChildren<Animator>().Play("Fire");
	}
}
