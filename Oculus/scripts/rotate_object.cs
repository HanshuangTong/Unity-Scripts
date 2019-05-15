using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_object : MonoBehaviour {

    public float rot_x;
    public float rot_y;
    public float rot_z;

    public float speed = 1f;
    Vector3 rotation;

    // Use this for initialization
    void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        rotation = new Vector3(rot_x*speed, rot_y*speed, rot_z*speed);
        gameObject.transform.Rotate(rotation);
	}
}
