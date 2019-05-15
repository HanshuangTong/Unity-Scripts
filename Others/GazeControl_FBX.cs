using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GazeControl_FBX : MonoBehaviour
{


    Animation FBX_Animator;

    public AnimationClip anim;

    public GameObject FBX_Object;
   
    Vector3 init_scale;

    public Material mat01;
    public Material mat02;



    // Use this for initialization
    void Start()


    {
        init_scale = FBX_Object.transform.localScale;
        FBX_Animator = FBX_Object.GetComponent<Animation>();
        
        FBX_Animator[anim.name].speed = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        // handle user gaze
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        RaycastHit hit = new RaycastHit();


        //object 01
        {
            if (FBX_Object.GetComponent<Collider>().Raycast(ray, out hit, 100.0f))
            {
                FBX_Object.GetComponent<Renderer>().material = mat02;
            }

            else

            {

                FBX_Object.GetComponent<Renderer>().material = mat01;

            }


            if (FBX_Object.GetComponent<Collider>().Raycast(ray, out hit, 100.0f) && (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick)))
            {
                FBX_Animator[anim.name].speed = 1f;
            }

            if (FBX_Object.GetComponent<Collider>().Raycast(ray, out hit, 100.0f) && (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick)))
            {
                FBX_Animator[anim.name].speed = 0f;
            }


        }






    }
}
