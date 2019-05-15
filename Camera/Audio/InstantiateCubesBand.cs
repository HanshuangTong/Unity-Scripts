using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubesBand : MonoBehaviour {
    public GameObject cube;
    GameObject[] cubes = new GameObject[8];
    public float maxScale = 1f;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject instanceCube = (GameObject)Instantiate(cube);
            instanceCube.transform.position = transform.position;
            instanceCube.transform.parent = transform;
            instanceCube.name = "cube" + i;
            transform.eulerAngles = new Vector3(0, 45f * i, 0);
            instanceCube.transform.position = Vector3.forward * 1;
            cubes[i] = instanceCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            if (cubes != null)
            {
                cubes[i].transform.localScale = new Vector3(0.1f, (Audio.freqBand[i] * maxScale) + 0.1f, 0.1f);
            }
        }
    }
}