using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_scale : MonoBehaviour {
   
    /// This script scales an object if you touch it with your controller
    /// make sure that your object has trigger enabled in your collider component
    /// make sure that your hands also have a collider component
    /// either the controller or your object have to have a rigid body component
    /// just drag and drop the script to the object you want to transform
    
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
