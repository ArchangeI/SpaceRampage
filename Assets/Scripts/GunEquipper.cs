using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour 
{
	public static string activeWeaponType;
	public GameObject pistol;
	public GameObject assaultRifle;
	public GameObject shotgun;
	public GameObject activeGun;

	[SerializeField]
	GameUI gameUI;

	// Use this for initialization
	void Start () 
	{
		activeWeaponType = Constants.Pistol;
		activeGun = pistol;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("1"))
		{
			loadGun(pistol);
			activeWeaponType = Constants.Pistol;
			gameUI.UpdateRecticle();

		}
		else if(Input.GetKeyDown("2"))
		{
			loadGun(assaultRifle);
			activeWeaponType = Constants.AssaultRifle;
			gameUI.UpdateRecticle();
		}
		else if(Input.GetKeyDown("3"))
		{
			loadGun(shotgun);
			activeWeaponType = Constants.Shotgun;
			gameUI.UpdateRecticle();
		}
	}

	void loadGun(GameObject weapon)
	{
		pistol.SetActive(false);
		shotgun.SetActive(false);
		assaultRifle.SetActive(false);

		activeGun = weapon;
		activeGun.SetActive(true);
		
	}

	GameObject GetActiveGun()
	{
		return activeGun;
	}
}
