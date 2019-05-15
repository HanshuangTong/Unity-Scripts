using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randommove : MonoBehaviour {
    public GameObject g1;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    public void Update()
    {
        this.transform.position = g1.transform.position;
    }
}
