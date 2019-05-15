using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;

    // Use this for initialization
    void Start () {
        camera1.transform.parent.gameObject.SetActive(true);
        camera2.transform.parent.gameObject.SetActive(false);
        camera3.transform.parent.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (camera1.transform.localPosition.z < -2.9f)
        {
            //camera1.transform.localPosition = new Vector3(camera1.transform.localPosition.x, camera1.transform.localPosition.y, -2.99f);
            camera1.transform.parent.gameObject.SetActive(false);
            camera2.transform.parent.gameObject.SetActive(true);
            
        }
        if (camera2.transform.localPosition.x > 1.85f)
        {
            //camera1.transform.localPosition = new Vector3(camera1.transform.localPosition.x, camera1.transform.localPosition.y, -2.99f);
            camera2.transform.parent.gameObject.SetActive(false);
            camera3.transform.parent.gameObject.SetActive(true);
        }
    }
}
