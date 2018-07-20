using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
	//scenes
	public const string SceneBattles = "Battle";
	public const string SceneMenu = "MainMenu";
	
	//gun
	public const string Pistol = "Pistol";
	public const string Shotgun = "Shotgun";
	public const string AssaultRifle = "AssaultRifle";


	//Robot
	public const string BlueRobot = "BlueRobot";
	public const string RedRobot = "RedRobot";
	public const string YellowRobot = "YellowRobot";


	//Pickup
	public const int PickupPistolAmmo = 1;
	public const int PickupShotgunAmmo = 2;
	public const int PickupAssaultRifleAmmo = 3;
	public const int PickupHealth = 4;
	public const int PickupAmmo = 5;

	//misc
	public const string Game = "Game";
	public const float CameraDefaultZoom = 60f;
	

	public static readonly int[] AllPickupTypes  = new int[5]
	{
		PickupPistolAmmo,
		PickupShotgunAmmo,
		PickupAssaultRifleAmmo,
		PickupHealth,
		PickupAmmo
	};
}
