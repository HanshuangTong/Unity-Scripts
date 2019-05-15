using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifySphere : MonoBehaviour {

    public float Scale = 0.1f;

    //OVR=1 HTC=2
    public int useVR = 2;

    //OVR key setup
    //1=right 2=left
    public int OVRSetup = 1;

    //HTC key setup
    private Valve.VR.EVRButtonId downButton = Valve.VR.EVRButtonId.k_EButton_DPad_Down;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Vector2 touchpadR;
    private Vector2 touchpadL;
    private SteamVR_TrackedObject trackedObjectL;  // controller ID
    private SteamVR_Controller.Device deviceL;
    private SteamVR_TrackedObject trackedObjectR;  // controller ID
    private SteamVR_Controller.Device deviceR;
    public GameObject idL;
    public GameObject idR;

    // Use this for initialization
    void Start () {
        if (useVR == 2)
        {
            trackedObjectL = idL.GetComponent<SteamVR_TrackedObject>();
            trackedObjectR = idR.GetComponent<SteamVR_TrackedObject>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (useVR == 2)
        {
            deviceL = SteamVR_Controller.Input((int)trackedObjectL.index);
            deviceR = SteamVR_Controller.Input((int)trackedObjectR.index);
            touchpadR = deviceR.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
            touchpadL = deviceL.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
            if (transform.localScale.x < 6)
            {
                if ((deviceR.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && touchpadR.x > 0.6f) || Input.GetKey("d"))
                {
                    transform.localScale += new Vector3(Scale, Scale, Scale);
                }
            }
            if (transform.localScale.x > 2)
            {
                if ((deviceR.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && touchpadR.x < -0.6f) || Input.GetKey("s"))
                {
                    transform.localScale -= new Vector3(Scale, Scale, Scale);
                }
            }
        }
        
        else if (useVR == 1)
        {
            if (transform.localScale.x < 6)
            {
                if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0.6f || Input.GetKey("d"))
                {
                    transform.localScale += new Vector3(Scale, Scale, Scale);
                }
            }
            if (transform.localScale.x > 2)
            {
                if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < -0.6f || Input.GetKey("s"))
                {
                    transform.localScale -= new Vector3(Scale, Scale, Scale);
                }
            }
        }
	}
}
