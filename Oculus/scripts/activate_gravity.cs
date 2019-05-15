using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_gravity : MonoBehaviour {
    Rigidbody rigidbody;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            rigidbody.useGravity = true;
           
            GetComponent<scaling_object>().enabled = false;
            GetComponent<rotate_object>().enabled = false;
        }

    }
}
