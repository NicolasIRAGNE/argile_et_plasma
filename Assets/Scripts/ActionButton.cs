using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour
{

	public GameObject SpawnedUnit;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		if (SpawnedUnit != null)
		{
			var clone = Instantiate(SpawnedUnit, new Vector3(Random.Range(-3.0f, 3.0f), -5, 1), Quaternion.identity);
			var clonescript = clone.gameObject.GetComponent<Character>();
			clonescript.MoveTarget = clonescript.transform.position + new Vector3(0, 1, 0);
		}
	}
}
