using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_S : MonoBehaviour {
    public int state = -1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "test")
        {
            state = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        state = 1;
    }
}
