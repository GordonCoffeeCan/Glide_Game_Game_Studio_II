using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windPush : MonoBehaviour {

    public static bool _windPushed = false;
    public static float _windPushValue=6;

  

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D _col) {
        if (playerControlScript.isGliding == true && _windPushed == false) {
            _col.GetComponent<Rigidbody2D>().AddForce(Vector3.up * _windPushValue, ForceMode2D.Impulse);
            _windPushed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _col) {
        _windPushed = false;
    }

}
