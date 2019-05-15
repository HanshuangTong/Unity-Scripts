using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_and_stop_FBX_animaiton_with_controller : MonoBehaviour {
    Animation FBX_Animator;

    public AnimationClip anim;

    // Use this for initialization
    void Start () {
        FBX_Animator = GetComponent<Animation>();

        //anim = FBX_Animator.GetComponent<AnimationClip>();

        FBX_Animator[anim.name].speed = 0f;
    
    }
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))

        {
            // FBX_Animator.enabled = true;
            //FBX_Animator.Play();
            FBX_Animator[anim.name].speed = 1f;
            

        }


        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))

        {  //FBX_Animator.enabled = false;

           //FBX_Animator.Stop();

            FBX_Animator[anim.name].speed = 0f;

            // FBX_Animator.Rewind();
        }


    }
}
