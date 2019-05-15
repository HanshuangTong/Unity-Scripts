using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable : MonoBehaviour {
    public GameObject g1;
    public GameObject g2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("q"))
        {
            g1.SetActive(true);
        }
        if (Input.GetKeyDown("w"))
        {
            g1.SetActive(false);
        }
        if (Input.GetKeyDown("e"))
        {
            g2.SetActive(true);
        }
        if (Input.GetKeyDown("r"))
        {
            g2.SetActive(false);
        }
    }
}
