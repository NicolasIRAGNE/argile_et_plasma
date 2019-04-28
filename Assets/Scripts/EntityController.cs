using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{

	public Character Selected = null;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

			if (hit.collider != null && Selected == null)
			{
				Debug.Log("clicked on " + hit.collider.gameObject);
				Selected = hit.collider.gameObject.GetComponent<Character>();
			}
			else if (Selected != null)
			{
				Selected.Target = mousePos2D;
				Selected = null;
			}
		}
	}
}
