using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameUI  : MonoBehaviour
{
	[SerializeField]
	Sprite yellowReticle;
	[SerializeField]
	Sprite redReticle;
	[SerializeField]
	Sprite blueReticle;
	[SerializeField]
	Image reticle;
	// Use this for initialization
	public void UpdateRecticle()
	{
		switch(GunEquipper.activeWeaponType)
		{
			case Constants.Pistol:
				reticle.sprite = redReticle;
				break;
			case Constants.Shotgun:
				reticle.sprite = yellowReticle;	
				break;
			case Constants.AssaultRifle:
				reticle.sprite = blueReticle;	
				break;
			default:
				return;
		}
	}
	
}
