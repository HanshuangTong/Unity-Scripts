using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnPlay : MonoBehaviour {
    public float speedUp = 10f;
    public float speedForward = 10f;
    public float speedLeft = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate((Vector3.up * speedUp + Vector3.forward * speedForward + Vector3.left * speedLeft) * Time.deltaTime, Space.World);
	}
}
