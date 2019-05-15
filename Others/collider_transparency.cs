using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_transparency : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public Material distort;
    private float mscale = 0.2f;
    private float mchange = 0.2f;
    // Use this for initialization
    void Start()
    {
        Vector4 v2 = new Vector4(1, 1, 1, 0.6f);
        distort.SetFloat("_FPOW", 0.8f);
        distort.SetVector("_NoiseScale", v2);
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {

            Debug.Log("entered");
        }
    }
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (stay)
        {
            if (stayCount > 0.2f)
            {
                mscale += 0.2f;
                Debug.Log("staying");
                stayCount = stayCount - 0.2f;
            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }
            //Vector4 v1 = new Vector4(1, 1, 1, mchange);
            //distort.SetFloat("_NoiseScale", v1);
            //distort.SetVector("_NoiseScale", v1);
            distort.SetFloat("_FPOW", mscale);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit)
        {
            Vector4 v2 = new Vector4(1, 1, 1, 0.2f);
            distort.SetVector("_NoiseScale", v2);
            mchange = 0.2f;
            mscale = 0.8f;
            distort.SetFloat("_FPOW", mscale);
            Debug.Log("exit");
        }
    }
}
