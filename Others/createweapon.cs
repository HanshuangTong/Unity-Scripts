using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createweapon : MonoBehaviour {

    public GameObject waterhelix;
    public GameObject handR;
    Quaternion rot;

    // Use this for initialization
    void Start()
    {
      rot=  waterhelix.transform.rotation;
    }

    // Update is called once per frame
    void Update() 
    {


        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            waterhelix.transform.rotation = rot;
            //if (Input.GetMouseButtonDown(0)){
            //waterhelix.SetActive(true);
            waterhelix.transform.position = handR.transform.position;

            waterhelix.transform.Rotate(handR.transform.right, 90);

            Debug.Log("pressed");
        }
    }
}

