using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_scale : MonoBehaviour {

    Vector3 initial_scale;

	// Use this for initialization
	void Start () {
        initial_scale = gameObject.transform.localScale;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter(Collider other)
    {

        gameObject.transform.localScale = (initial_scale * 2);


    }

     void OnTriggerExit(Collider other)
    {
        gameObject.transform.localScale = (initial_scale);
    }
}
