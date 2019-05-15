using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gesture_alembic_with_controller : MonoBehaviour {
    public float start_anim;
    public float end_anim;

    public float min_height;
    public float max_height;

    public GameObject handL;
    public GameObject handR;

    public float animation_multiplier=1;

    float current_height = 0;

    PlayableDirector anim;
	// Use this for initialization
	void Start () {

        anim = gameObject.GetComponent<PlayableDirector>();
        
		
	}
	
	// Update is called once per frame
	void Update () {


        if((OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) && (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)))

        {

            current_height = ((handL.transform.position.y + handR.transform.position.y) / 2);
            current_height = current_height * animation_multiplier;
        }

        


       Debug.Log(current_height);
        anim.time = current_height;
	}
}
