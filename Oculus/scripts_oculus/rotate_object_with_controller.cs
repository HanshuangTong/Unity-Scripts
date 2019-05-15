﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_object_with_controller : MonoBehaviour {

    Vector2 primary_stick;
    Vector2 secondary_stick;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        primary_stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        secondary_stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        gameObject.transform.Rotate(primary_stick.x, primary_stick.y, secondary_stick.x);

    }
}
