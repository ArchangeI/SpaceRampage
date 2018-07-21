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
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV,
			zoomSpeed * Time.deltaTime);
		}
		else
		{
			Camera.main.fieldOfView = Constants.CameraDefaultZoom;
		}
	}
	
	void ProcessHit(GameObject hitObject)
	{
		if(hitObject.GetComponent<Player>() != null)
		{
			hitObject.GetComponent<Player>().TakeDamage(damage);
		}
		if(hitObject.GetComponent<Robot>() != null)
		{
			hitObject.GetComponent<Robot>().TakeDamage(damage);
		}

	}


	protected void Fire()
	{
		if(ammo.HasAmmo(tag))
		{
			// Debug.Log("ammo " + tag + " = " + ammo.GetAmmo(tag));
			AudioSource source = GetComponent<AudioSource>();
			
			// GetComponent<AudioSource>().PlayOneShot(liveFire);
			if(!source.isPlaying)
			{
				source.clip = liveFire;
				source.Play();
			}
			else
			{
				// Debug.LogError("ERRORRRR");
			}
			ammo.ConsumeAmmo(tag);
		}
		else
		{
			GetComponent<AudioSource>().PlayOneShot(dryFire);
		}
		GetComponentInChildren<Animator>().Play("Fire");


		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, range))
		{
			ProcessHit(hit.collider.gameObject);
		}
	}
}
