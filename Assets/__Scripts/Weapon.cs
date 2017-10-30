using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// This is an enum of the various possible weapon types
/// it also includes a "shield" type to allow a shield power-up
/// items marked [NI] below are not implemented in the IGDPD book
/// </summary>


public enum WeaponType {
	none, // the default / no weapon
	blaster, // a simple blaster
	spread, // two shots simultaneously
	phaser, // [NI] shots that move in waves
	missile, // [NI] Homing Missiles
	laser, // [NI] Damage over time
	shield // Raise shieldLevel
}

[System.Serializable]
public class WeaponDefinition{
	public WeaponType type = WeaponType.none;
	public string letter; // leter to show on the power-up
	public Color color = Color.white; // color of collar & power-up
	public GameObject projectilePrefab; //Prefab for projectiles
	public Color projectileColor = Color.white;
	public float damageOnHit = 0; //Amount of damage caused
	public float continuousDamage = 0; //Damage per second (Laser)
	public float delayBetweenShots = 0; 
	public float velocity = 20; //Speed of projectiles
}

public class Weapon : MonoBehaviour{
	
}
