using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour {

    public FollowPath  PathToFollow;
    public int CurrentWayPointID=0;
    public float speed;
    private float reachDistace = 1.0f;
    public float rotationspeed = 5.0f;
    public FollowPath[] Paths;
    int PathNum = 0;

    public string PathChangeButton;

    //OVR=1 HTC=2
    public int useVR = 2;

    //OVR key setup
    //1=right 2=left
    public int OVRSetup = 1;

    //HTC key setup
    //1=right 2=left
    //3=left other setting
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    private SteamVR_TrackedObject trackedObjectL;  // controller ID
    private SteamVR_Controller.Device deviceL;
    private SteamVR_TrackedObject trackedObjectR;  // controller ID
    private SteamVR_Controller.Device deviceR;
    public GameObject idL;
    public GameObject idR;
    public int HTCSetup = 1;


    Vector3 current_position;
    Vector3 last_position;

    
    // Use this for initialization
    void Start () {
        if (useVR == 2)
        {
            trackedObjectL = idL.GetComponent<SteamVR_TrackedObject>();
            trackedObjectR = idR.GetComponent<SteamVR_TrackedObject>();
        }

        if (Paths.Length != 0)
        {
            PathToFollow = Paths[PathNum].GetComponent<FollowPath>();
        }
        last_position = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        if (useVR == 2)
        {
            deviceL = SteamVR_Controller.Input((int)trackedObjectL.index);
            deviceR = SteamVR_Controller.Input((int)trackedObjectR.index);
            if (Input.GetKeyDown(PathChangeButton) || deviceL.GetPressDown(gripButton))
            {
                if (PathNum < Paths.Length - 1)
                {
                    PathNum++;
                }
                else
                {
                    PathNum = 0;
                }
                CurrentWayPointID = 0;
            }
        }
        if (useVR == 1)
        {
            if (Input.GetKeyDown(PathChangeButton) || OVRInput.GetDown(OVRInput.Button.Four))
            {
                if (PathNum < Paths.Length - 1)
                {
                    PathNum++;
                }
                else
                {
                    PathNum = 0;
                }
                CurrentWayPointID = 0;
            }
        }

        if (Paths.Length != 0)
        {
            PathToFollow = Paths[PathNum].GetComponent<FollowPath>();
            /*if (PathNum < 1)
            {
                Debug.Log("enable cube");
                CubeCollider.SetActive(true);
                SphereCollider.SetActive(false);

            }

            if (PathNum < 2)
            {
                if (PathNum > 0)
                {
                    Debug.Log("enable sphere");
                    CubeCollider.SetActive(false);
                    SphereCollider.SetActive(true);
                }
            }*/
            //Debug.Log(PathToFollow.name);



            /*if (Input.GetKeyDown(path01))
            {
                PathToFollow = Paths[PathNum=0].GetComponent<FollowPath>();
            }
            if (Input.GetKeyDown(path02))
            {
                PathToFollow = Paths[PathNum = 1].GetComponent<FollowPath>();
            }*/

            float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);

            var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationspeed);


            if (distance <= reachDistace)
            {
                CurrentWayPointID++;
            }

            if (CurrentWayPointID >= PathToFollow.path_objs.Count)
            {
                CurrentWayPointID = 0;
            }
        }
    }
}
