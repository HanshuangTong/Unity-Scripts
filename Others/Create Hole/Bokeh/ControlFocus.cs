using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFocus : MonoBehaviour {
    public GameObject focus;
    Vector3 target;
    public float followSharpness = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50, layerMask))
        {
            target = transform.TransformDirection(Vector3.forward*hit.distance)+transform.position;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            target = transform.TransformDirection(Vector3.forward * 10) + transform.position;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.white);
            //Debug.Log("Did not Hit");
        }
        focus.transform.position += (target - focus.transform.position) * followSharpness;
    }
}
