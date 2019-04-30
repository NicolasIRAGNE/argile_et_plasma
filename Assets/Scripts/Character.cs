using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Character : MonoBehaviour
{
	public string[] Name;
	public int Health;
	public int Exp;
	public int Rifle;
	public int RifleMin;
	public int RifleMax;
	public int Morale;
	public int MoraleMin;
	public int MoraleMax;
	public float Speed;
	public Weapon EquippedWeapon;
	public GameObject WeaponObj;
	public GameObject StartingWeapon;
	public bool Ally;
	public Vector3 MoveTarget;
	public GameObject ShootTarget;
	public string State = "Idle";
	
	// Use this for initialization
	void Start ()
	{
		Rifle = Random.Range(RifleMin, RifleMax);
		Morale = Random.Range(MoraleMin, MoraleMax);
		WeaponObj = Instantiate(StartingWeapon, transform.position + new Vector3(-0.2f, -0.2f, 0f), transform.rotation, transform);
		EquippedWeapon = WeaponObj.GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, MoveTarget, Time.deltaTime * Speed);
		if (State == "Idle")
		{
			Vector3 mousePos = Camera.main.WorldToScreenPoint(MoveTarget);
			mousePos.z = 0;

			Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
			mousePos.x = mousePos.x - objectPos.x;
			mousePos.y = mousePos.y - objectPos.y;

			if (transform.position != MoveTarget)
			{
				float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
				angle += 90;
				transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
			}
		}

		if (Input.GetButtonDown("Submit"))
		{
			Aim();
		}
		if (Health <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void Reload()
	{
		EquippedWeapon.Ammo = EquippedWeapon.MaxAmmo;
	}

	void Aim()
	{
		Vector3 mousePos = Camera.main.WorldToScreenPoint(ShootTarget.transform.position);
		mousePos.z = 0;

		Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		angle += 90;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		EquippedWeapon.Target = ShootTarget;
		EquippedWeapon.Fire();
	}
}
