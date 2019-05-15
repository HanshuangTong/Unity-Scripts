using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalescript : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        Debug.Log("my script started");
    }
	
	// Update is called once per frame
	void Update () {
      
  
		if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            gameObject.transform.localScale += new Vector3(0.1F, 0.1F, 0.1F);
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            gameObject.transform.localScale -= new Vector3(0.1F, 0.1F, 0.1F);
        }
    }
}
