using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_gravity : MonoBehaviour {

   
    /// This script activates gravity on an object with the A button on your VR controller
    /// just drag and drop the script to one of your game objects
    /// make sure your gameobject has a rigid body component with gravity disabled
    
    Rigidbody rigidbody;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        

    }
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.Get(OVRInput.Button.One))
        {
            rigidbody.useGravity = true;
           
           // GetComponent<scaling_object>().enabled = false;
            //GetComponent<rotate_object>().enabled = false;
        }

        else
        {

            rigidbody.useGravity = false;

        }

    }
}
