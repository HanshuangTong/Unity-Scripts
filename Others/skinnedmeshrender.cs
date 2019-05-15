using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinnedmeshrender : MonoBehaviour {

    // Use this for initialization
    private skinnedmeshrender sm;
	void Start () {
        sm = this.GetComponent<skinnedmeshrender>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("d"))
        {
            sm.enabled = false;
        }
        if (Input.GetKeyDown("f"))
        {
            sm.enabled = true;
        }
    }
}
