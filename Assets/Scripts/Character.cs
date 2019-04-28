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
	public float Speed;
	public Weapon EquippedWeapon;
	public bool Ally;
	public Vector3 Target;
	public string State = "Idle";
	
	// Use this for initialization
	void Start ()
	{
		Rifle = Random.Range(RifleMin, RifleMax);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, Target, Time.deltaTime);
		if (State == "Idle")
		{
			Vector3 mousePos = Camera.main.WorldToScreenPoint(Target);
			mousePos.z = 0;

			Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
			mousePos.x = mousePos.x - objectPos.x;
			mousePos.y = mousePos.y - objectPos.y;

			float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			angle -= 90;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		}
	}
}
