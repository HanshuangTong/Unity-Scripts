using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar_Shooting : MonoBehaviour {
    public GameObject template1;
    public GameObject template2;
    public GameObject template3;
    public int birthrate1 = 5;
    public int birthrate2 = 3;
    public int birthrate3 = 1;

    public int particleLimit = 5000;

    public bool scale = true;
    public bool position = true;
    public bool gravity = true;
    public bool speed = false;
    float pretime = 0f;
    public float interval = 0.25f;

    //control setup
    //1=press to generate
    //2=press to start generate
    public int controlSetup = 1;


    //key setup
    public string generateKey = "q";
    public string switchKey = "w";

    //OVR=1 HTC=2
    public int useVR = 2;

    //OVR key setup
    //1=right 2=left
    public int OVRSetup = 1;

    //HTC key setup
    //1=right 2=left
    //3=left other setting
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    private SteamVR_TrackedObject trackedObjectL;  // controller ID
    private SteamVR_Controller.Device deviceL;
    private SteamVR_TrackedObject trackedObjectR;  // controller ID
    private SteamVR_Controller.Device deviceR;
    public GameObject idL;
    public GameObject idR;
    public int HTCSetup = 1;

    //whether generate
    public bool generate = true;

    //particle number
    public int whichParticle = 1;




    // Use this for initialization
    void Start()
    {
        if (useVR == 2)
        {
            trackedObjectL = idL.GetComponent<SteamVR_TrackedObject>();
            trackedObjectR = idR.GetComponent<SteamVR_TrackedObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (useVR == 2)
        {
            deviceL = SteamVR_Controller.Input((int)trackedObjectL.index);
            deviceR = SteamVR_Controller.Input((int)trackedObjectR.index);
        }

        Generate();
        SwitchParticle();
        if (generate)
        {
            switch (whichParticle)
            {
                case 1:
                    MakeCopy(template1, birthrate1);
                    break;
                case 2:
                    MakeCopy(template2, birthrate2);
                    break;
                case 3:
                    MakeCopy(template3, birthrate3);
                    break;
            }
        }
    }

    void SwitchParticle()
    {
        if (useVR == 2)
        {
            if (Input.GetKeyDown(switchKey) || deviceR.GetPressDown(gripButton))
            {
                if (whichParticle == 3)
                {
                    whichParticle = 1;
                }
                else
                {
                    whichParticle++;
                }
            }
        }
        if (useVR == 1)
        {
            if (Input.GetKeyDown(switchKey) || OVRInput.GetDown(OVRInput.Button.Two))
            {
                if (whichParticle == 3)
                {
                    whichParticle = 1;
                }
                else
                {
                    whichParticle++;
                }
            }
        }
    }

    void Generate()
    {
        if (controlSetup == 1)
        {
            if (useVR == 1)
            {
                if (Input.GetKey(generateKey) || (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger)>0.6f && OVRSetup == 1) || (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.6f && OVRSetup == 2))
                {
                    generate = true;
                }
                else
                {
                    generate = false;
                }
            }
            if (useVR == 2)
            {
                if (Input.GetKey(generateKey) || (deviceR.GetPress(triggerButton) && HTCSetup == 1) || (deviceL.GetPress(triggerButton) && HTCSetup == 2))
                {
                    generate = true;
                }
                else
                {
                    generate = false;
                }
            }
        }

        if (controlSetup == 2)
        {
            if (useVR == 1)
            {
                if (Input.GetKeyDown(generateKey) || (OVRInput.GetDown(OVRInput.Button.One) && OVRSetup == 1) || (OVRInput.GetDown(OVRInput.Button.Three) && OVRSetup == 2))
                {
                    generate = !generate;
                }
            }
            if (useVR == 2)
            {
                if (Input.GetKeyDown(generateKey) || (deviceR.GetPressDown(triggerButton) && HTCSetup == 1) || (deviceL.GetPressDown(triggerButton) && HTCSetup == 2))
                {
                    generate = !generate;
                }
            }
        }
    }

    void MakeCopy(GameObject template, int num)
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

