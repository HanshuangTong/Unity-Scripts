using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale_object_controller : MonoBehaviour {

    public GameObject l_hand;
    public GameObject r_hand;

    float distance_hand_init=1;
    float distance_hand_end=1;

    Vector3 current_scale;
    Vector3 new_scale;
    float factor_scale=1;

    // Use this for initialization
    void Start () {
        current_scale = gameObject.transform.localScale;
        new_scale = current_scale;
    }
	
	// Update is called once per frame
	void Update () {

       

        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)&& OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))

        {
            current_scale = gameObject.transform.localScale;
            distance_hand_init = Vector3.Distance(l_hand.transform.position, r_hand.transform.position);
            Debug.Log("pressed");

        }


        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))

        {
            distance_hand_end = Vector3.Distance(l_hand.transform.position, r_hand.transform.position);

            factor_scale = (distance_hand_end / distance_hand_init);
            new_scale = current_scale * factor_scale;

        }

               

        gameObject.transform.localScale = new_scale;

		
	}
}
