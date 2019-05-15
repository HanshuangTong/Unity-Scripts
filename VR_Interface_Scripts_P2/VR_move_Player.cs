using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_move_Player : MonoBehaviour {

    public float speed = 0.01f;
    Vector2 primary_stick;
    Vector2 secondary_stick;

    float x;
    float y;
    float z;

    Vector3 new_pos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        primary_stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        secondary_stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        if (!OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            x = gameObject.transform.position.x + (secondary_stick.x * speed);
            y = gameObject.transform.position.z + (secondary_stick.y * speed);
            z = gameObject.transform.position.y + (primary_stick.y * speed);

            new_pos = new Vector3(x, y, z);

            gameObject.transform.position = new_pos;
        }
        */
        primary_stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        secondary_stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        x = gameObject.transform.position.x - (secondary_stick.x * speed);
        if (!OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            z = gameObject.transform.position.z - (primary_stick.y * speed);
        }

        y = gameObject.transform.position.y - (secondary_stick.y * speed);
 
        gameObject.transform.position = new Vector3(x, y, z);



    }
}
