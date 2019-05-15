using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour {
    public GameObject template;
    public int birthrate = 1;
    public bool scale = true;
    public bool position = true;
    public bool gravity = true;
    public bool speed = false;
    float pretime = 0f;
    public float interval = 0.25f;
    public int particleLimit = 100;

    //control setup
    //1=press to generate
    //2=press to start generate
    public int controlSetup = 1;

    //key setup
    public string key = "a";

    //OVR=1 HTC=2
    public int useVR = 2;

    //OVR key setup
    //1=right 2=left
    public int OVRSetup = 2;

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
    public int HTCSetup = 2;

    //whether generate
    public bool generate = true;


    
    // Use this for initialization
    void Start()
    {
        if(useVR == 2)
        {
            trackedObjectL = idL.GetComponent<SteamVR_TrackedObject>();
            trackedObjectR = idR.GetComponent<SteamVR_TrackedObject>();
        }
    }

    // Update is called once per frame
    void Update () {
        Generate();
        MakeCopy(birthrate);
    }

    void Generate()
    {
        if (useVR == 1)
        {
            if (OVRSetup == 1 && OVRInput.Get(OVRInput.Button.One))
            {
                generate = true;
            }
            else if (OVRSetup == 2 && OVRInput.Get(OVRInput.Button.Three))
            {
                generate = true;
            }
            else if (Input.GetKey(key))
            {
                generate = true;
            }

            else
            {
                generate = false;
            }
        }
        else if (useVR == 2)
        {
            deviceL = SteamVR_Controller.Input((int)trackedObjectL.index);
            deviceR = SteamVR_Controller.Input((int)trackedObjectR.index);
            touchpadR = deviceR.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
            touchpadL = deviceL.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
            if (HTCSetup == 1 && deviceR.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && touchpadR.y < -0.7f)
            {
                generate = true;
            }
            else if (HTCSetup == 2 && deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && touchpadL.y < -0.7f)
            {
                generate = true;
            }
            else if (Input.GetKey(key))
            {
                generate = true;
            }

            else
            {
                generate = false;
            }
        }
    }

    void MakeCopy(int num =1)
    {
        if (generate)
        {
            if (transform.childCount + num < particleLimit)
            {

                if (pretime >= interval)
                {
                    for (int i = 0; i < num; i++)
                    {
                        GameObject newball;
                        newball = Instantiate(template, gameObject.transform);
                        newball.GetComponent<Rigidbody>().Sleep();
                        ModifyCopy modification = gameObject.GetComponent<ModifyCopy>();
                        modification.Modify(newball, scale, position, gravity, speed);
                    }
                    pretime = 0;
                }
                else
                {
                    pretime += Time.deltaTime;
                }
            }
        }
    }
}
