using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_mode : MonoBehaviour {
    public int mmode=0;
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
                mmode = 1;
                Debug.Log("staying");
                stayCount = stayCount - 0.2f;
            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit)
        {
            mmode = 0;
            Debug.Log("exit");
        }
    }
}
