using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 _rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D _rayHit = Physics2D.Raycast(new Vector2(_rayPosition.x, _rayPosition.y), Camera.main.transform.forward);
            Debug.Log(_rayHit.collider.name);
        }
	}
}
