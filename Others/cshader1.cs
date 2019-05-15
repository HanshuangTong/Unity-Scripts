using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshader1 : MonoBehaviour {
    public Material distort;
    private float mscale = 0.2f;
    private float mchange = 0.2f;
    // Use this for initialization
    void Start () {
        //distort.SetFloat("_FPOW", 1.0f);
        Vector4 v2 = new Vector4(1, 1, 1, mchange);
        distort.SetFloat("_FPOW", mscale);
        distort.SetVector("_NoiseScale", v2);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("z"))
        {
            mscale += 0.2f;

        }
        distort.SetFloat("_FPOW", mscale);
        if (Input.GetKeyDown("c"))
        {
            mchange += 0.1f;

        }
        if (Input.GetKeyDown("x"))
        {
            mscale -= 0.2f;

        }
        distort.SetFloat("_FPOW", mscale);
        if (Input.GetKeyDown("v"))
        {
            mchange -= 0.1f;

        }
        Vector4 v1 = new Vector4(1, 1, 1, mchange);
        //distort.SetFloat("_NoiseScale", v1);
        distort.SetVector("_NoiseScale", v1);
    }
}
