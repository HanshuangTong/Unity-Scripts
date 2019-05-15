using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour {
    public GameObject cube;
    GameObject[] cubes = new GameObject[512];
    public float maxScale = 1f;
    

	// Use this for initialization
	void Start () {
		for (int i = 0; i< 512; i++)
        {
            GameObject instanceCube = (GameObject) Instantiate(cube);
            instanceCube.transform.position = transform.position;
            instanceCube.transform.parent = transform;
            instanceCube.name = "cube" + i;
            transform.eulerAngles = new Vector3(0, 0.703f * i, 0);
            instanceCube.transform.position = Vector3.forward * 10;
            cubes[i] = instanceCube; 
        }
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 512; i++)
        {
            if(cubes != null)
            {
                cubes[i].transform.localScale = new Vector3(0.1f, (Audio.samples[i] * maxScale) + 0.1f , 0.1f);
            }
        }
	}
}
