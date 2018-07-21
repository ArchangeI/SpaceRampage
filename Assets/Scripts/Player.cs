using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

	public int health;
	public int armor;
	public  GameUI gameUI;
	private Ammo ammo;
	private GunEquipper gunEquipper;
	// Use this for initialization
	void Start() 
	{
		ammo = GetComponent<Ammo>();
		gunEquipper = GetComponent<GunEquipper>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void TakeDamage(int amount)
	{
		int healthDamage = amount;
		if(armor > 0)
		{
			int effectiveArmor = armor * 2;
			effectiveArmor -= healthDamage;
			if(effectiveArmor > 0)
			{
				armor = effectiveArmor / 2;
				return;
			}
			armor = 0;
		}

		health -= healthDamage;
		// Debug.Log("Health is " + health);
		if(health <= 0)
		{
			// Debug.Log("GAME OVER");
		}
	}

	public void PickupItem(int pickupType)
	{
		switch(pickupType)
		{
			case Constants.PickupHealth:
			pickupHealth();
			break;
			
			case Constants.PickupArmor:
			pickupArmor();
			break;

			case Constants.PickupPistolAmmo:
			pickupPistolAmmo();
			break;

			case Constants.PickupAssaultRifleAmmo:
			pickupAssaultAmmo();
			break;

			case Constants.PickupShotgunAmmo:
			pickupShotgunAmmo();
			break;

			default:
			Debug.LogError("Bad pickup type " + pickupType);
			break;
		}
	}

	void pickupHealth()
	{
		health += 50;
		if(health > 200)
			health = 200;
	}
	void pickupArmor()
	{
		armor += 15;
	}

	void pickupPistolAmmo()
	{
		ammo.AddAmmo(Constants.Pistol, 20);
	}
	void pickupAssaultAmmo()
	{
		ammo.AddAmmo(Constants.AssaultRifle, 50);
	}
	void pickupShotgunAmmo()
	{
		ammo.AddAmmo(Constants.Shotgun, 10);
	}

}
