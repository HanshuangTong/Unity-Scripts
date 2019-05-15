using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialchange2 : MonoBehaviour



{
    public Material mat01;
    public Material mat02;
    //public Material mat03;

    void Update()
    {
        /*
        if (OVRInput.Get(OVRInput.Button.One))
        {
            GetComponent<MeshRenderer>().material = mat01;
        }
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            GetComponent<MeshRenderer>().material = mat02;
        }
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            GetComponent<MeshRenderer>().material = mat03;
        }
        */
        if (Input.GetKeyDown("q"))
        {
            GetComponent<MeshRenderer>().material = mat01;
        }
        if (Input.GetKeyDown("w"))
        {
            GetComponent<MeshRenderer>().material = mat02;
        }


    }
}



