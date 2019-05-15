using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
    public GameObject t1;
    public GameObject cylinder;
    //public Material distort;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v1 = new Vector3(2.0f * cylinder.transform.position.x - t1.transform.position.x, 2.0f * cylinder.transform.position.y - t1.transform.position.y, 2.0f * cylinder.transform.position.z - t1.transform.position.z);
        
        this.transform.position = v1;
	}
}
