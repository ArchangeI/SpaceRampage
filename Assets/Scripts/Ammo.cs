using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour 
{
	[SerializeField]
	GameUI gameUI;
	[SerializeField]
	int pistolAmmo;
	[SerializeField]
	int shotgunAmmo;
	[SerializeField]
	int assaultRifleAmmo;
	// Use this for initialization

	public  Dictionary<string,int> tagToAmmo;
	
	void Awake()
	{
		tagToAmmo = new Dictionary<string, int>()
		{
			{Constants.Pistol, pistolAmmo},
			{Constants.Shotgun, shotgunAmmo},
			{Constants.AssaultRifle, assaultRifleAmmo}
		};
	}
	
	public void AddAmmo(string tag, int ammo)
	{
		if(!tagToAmmo.ContainsKey(tag))
		{
			Debug.LogError("Unrecognized gun type passed " + tag);
		}

		tagToAmmo[tag] += ammo;
	}
	public bool HasAmmo(string tag)
	{
		if(!tagToAmmo.ContainsKey(tag))
		{
			Debug.LogError("Unrecognized gun type passed " + tag);
		}

		return tagToAmmo[tag] > 0;
	}

	public int GetAmmo(string tag)
	{
		if(!tagToAmmo.ContainsKey(tag))
		{
			Debug.LogError("Unrecognized gun type passed " + tag);
		}

		return tagToAmmo[tag];
	}

	public void ConsumeAmmo(string tag)
	{
		if(!tagToAmmo.ContainsKey(tag))
		{
			Debug.LogError("Unrecognized gun type passed " + tag);
		}

		tagToAmmo[tag]--;
	}


}
