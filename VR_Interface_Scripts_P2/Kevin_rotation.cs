using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kevin_rotation : MonoBehaviour
{
    /// script rotates any object in the scene with your joysticks on your VR controllers
    /// just drag and drop this script to an object you want to rotate


    Vector2 primary_stick;
    Vector2 secondary_stick;

    public float rotate01;
   public float rotate_02;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        primary_stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        secondary_stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            gameObject.transform.Rotate(primary_stick.x, primary_stick.y, secondary_stick.x);

        }

        //gameObject.transform.Rotate(primary_stick.x, primary_stick.y, secondary_stick.x);
        
       /*

        primary_stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);
        secondary_stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

        gameObject.transform.Rotate(primary_stick.x, primary_stick.y, secondary_stick.x);

        */

    }
}
