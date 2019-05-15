using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicscript : MonoBehaviour {
    Renderer rend;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        //float shininess = Mathf.PingPong(Time.time, 1.0f);
        rend.material.SetFloat("_Cull", AudioPeer._samples[4]);
    }
}
