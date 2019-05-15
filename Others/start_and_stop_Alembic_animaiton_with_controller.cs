using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class start_and_stop_Alembic_animaiton_with_controller : MonoBehaviour {
    PlayableDirector Alembic;

	// Use this for initialization
	void Start () {
        Alembic = gameObject.GetComponent<PlayableDirector>();
    }
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))

        {
            Alembic.enabled = true;                   


        }


        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))

        {
            Alembic.enabled = false;


        }
    }
}
