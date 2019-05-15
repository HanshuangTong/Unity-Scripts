using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractToSpace : MonoBehaviour {
    //public float followSharpness = 0.2f;
    Collider targetSpaceCollider;
    float enteredTime = 0;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}


    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (enteredTime < 100)
        {
            enteredTime += Time.deltaTime;
        }

        else if (enteredTime < 120)
        {
            other.GetComponent<Rigidbody>().WakeUp();
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<AttractTo>().enabled = false;
        }
    }
}
