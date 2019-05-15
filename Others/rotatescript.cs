using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatescript : MonoBehaviour {
    Vector3 myvector;

    public float x;
    public float y;
    public float z;


    // Use this for initialization
    void Start () {
        Debug.Log("my script startedDDDDDDDDDDDDDDDDDDDDDD");

    }
	
	// Update is called once per frame
	void Update () {
        myvector = new Vector3(x, y, z);

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            gameObject.transform.Rotate(x, y, z);
        }
	}
}
