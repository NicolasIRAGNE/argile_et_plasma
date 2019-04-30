using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject Target;
	public int Damage;
	public float Range;
	public int MaxAmmo;
	public int Ammo;
	public float ReloadTime;
	public Sprite WorldModel;
	public Sprite ViewModel;
	public float Accuracy;
	
	// Use this for initialization
	void Start ()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = ViewModel;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fire()
	{
		Target.gameObject.GetComponent<Character>().Health -= Damage;
	}
}
