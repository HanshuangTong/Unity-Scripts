using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractTo : MonoBehaviour {
    public float followSharpness = 0.2f;
    public GameObject targetSpace;
    Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.Sleep();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += (targetSpace.transform.position - transform.position) * followSharpness;
    }
}
