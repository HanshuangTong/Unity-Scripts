using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_material : MonoBehaviour {

    public Material mat01;
    public Material mat02;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {

        GetComponent<Renderer>().material = mat02;


    }

    void OnTriggerExit(Collider other)
    {

        GetComponent<Renderer>().material = mat01;


    }
}
