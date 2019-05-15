using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512cubes : MonoBehaviour {
    public GameObject _samplecubeprefab;
    GameObject[] _samplecube = new GameObject[512];
    // Use this for initialization
    public float _maxscale;
	void Start () {
        for (int i=0;i<512;i++)
        {
            GameObject _instacesamplecube = (GameObject)Instantiate(_samplecubeprefab);
            _instacesamplecube.transform.position = this.transform.position;
            _instacesamplecube.transform.parent = this.transform;
            _instacesamplecube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instacesamplecube.transform.position = Vector3.forward * 100;
            _samplecube[i] = _instacesamplecube;
            //GameObject _instance;
        }
	}
	
	// Update is called once per frame
	void Update () {
		//audioPeer
        for(int i = 0; i < 512; i++)
        {
            if (_samplecube != null)
            {
                _samplecube[i].transform.localScale = new Vector3(10, (AudioPeer._samples[i] * _maxscale) + 2, 10);
            }
        }
	}
}
