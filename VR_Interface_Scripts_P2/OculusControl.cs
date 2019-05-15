using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OculusControl : MonoBehaviour
{
    public GameObject compasstransder;
    public GameObject objecttranfer;
    public int transfer = 0;
    private bool transfer_permission = false;
    // Start is called before the first frame update
    Vector2 primary_stick;
    Vector2 secondary_stick;
    private float pre_move = 0;
    private int spherenum = 8;
    public int transferselectedtime = 0;
    public GameObject HumanPosition;
    public int alembicrendered = 3;
    private int pre_alembicrendered = -1;
    public GameObject [] Alembiclist= new GameObject [5];
    public GameObject[] PointCloudlist = new GameObject[3];
    public int MaterialType = 0;
    public GameObject[] meshrendererlist = new GameObject[5];
    public bool sprite_run = false;
    public bool FirstStageSignal = false;
    public bool FirstTransfromSignal = false;
    public float speed = 5f;
    void Start()
    {
        //transfer = compasstransder.GetComponent<GetAverage>().SelectedSignal;
        //transfer_permission = objecttranfer.GetComponent<Transport>().Transferallowed;

    }

    // Update is called once per frame
    void Update()
    {
        // Compass Select && Transfer Index

        primary_stick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            transfer_permission = true;
            transferselectedtime += 1;
        }
        // Transfer
        if (transferselectedtime == 2)
        {
            if (transfer == 0)
            {
                alembicrendered = 0;
            }
            else if (transfer < 5)
            {
                alembicrendered = 1;
            }
            else if (transfer < 9)
            {
                alembicrendered = 2;
            }
        }
        //Debug.Log(OVRInput.Button.PrimaryIndexTrigger);
        if (primary_stick.x > 0 && Mathf.Abs(pre_move)< 0.1 && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {      
            transfer = (transfer + 1) % 9;
        }
        if (primary_stick.x < 0 && Mathf.Abs(pre_move) < 0.1 && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            transfer = (transfer - 1) % 9;
        }
        pre_move = primary_stick.x;
        //...

        // FirstStage Transfrom Signal
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            FirstTransfromSignal = true;
        }



        // Alembic Animation

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            alembicrendered = (alembicrendered + 1) % 3;
        }
        if (pre_alembicrendered != alembicrendered)
        {
            
            for (int i = 0; i < 3; i++)
            {

                if (i == alembicrendered)
                {
                    //Alembiclist[i].SetActive(true);
                    PointCloudlist[i].SetActive(true);
                    //PointCloudlist[i].GetComponent<PointTransform>().enabled = true;
                }
                else
                {
                    //Alembiclist[i].SetActive(false);
                    PointCloudlist[i].SetActive(false);
                    //PointCloudlist[i].GetComponent<PointTransform>().enabled = false;
                }
            }
            if (alembicrendered == 0)
            {
                //sprite_run = false;
                Alembiclist[0].GetComponent<PlayableDirector>().enabled = true;
                Alembiclist[1].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[2].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[3].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[4].GetComponent<PlayableDirector>().enabled = false;

                meshrendererlist[0].GetComponent<MeshRenderer>().enabled = true;
                meshrendererlist[1].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[2].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[3].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[4].GetComponent<MeshRenderer>().enabled = false;
            }
            if (alembicrendered == 1)
            {
                //sprite_run = false;
                Alembiclist[0].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[1].GetComponent<PlayableDirector>().enabled = true;
                Alembiclist[2].GetComponent<PlayableDirector>().enabled = true;
                Alembiclist[3].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[4].GetComponent<PlayableDirector>().enabled = false;

                meshrendererlist[0].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[1].GetComponent<MeshRenderer>().enabled = true;
                meshrendererlist[2].GetComponent<MeshRenderer>().enabled = true;
                meshrendererlist[3].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[4].GetComponent<MeshRenderer>().enabled = false;
            }
            if (alembicrendered == 2)
            {
                //sprite_run = false;
                Alembiclist[0].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[1].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[2].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[3].GetComponent<PlayableDirector>().enabled = true;
                Alembiclist[4].GetComponent<PlayableDirector>().enabled = true;

                meshrendererlist[0].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[1].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[2].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[3].GetComponent<MeshRenderer>().enabled = true;
                meshrendererlist[4].GetComponent<MeshRenderer>().enabled = true;
            }
            if (alembicrendered == 3)
            {
                //sprite_run = true;
                Alembiclist[0].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[1].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[2].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[3].GetComponent<PlayableDirector>().enabled = false;
                Alembiclist[4].GetComponent<PlayableDirector>().enabled = false;

                meshrendererlist[0].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[1].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[2].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[3].GetComponent<MeshRenderer>().enabled = false;
                meshrendererlist[4].GetComponent<MeshRenderer>().enabled = false;
            }
        }
        
        pre_alembicrendered = alembicrendered;
        //...



        float step = speed * Time.deltaTime; // calculate distance to move
        if (transferselectedtime == 2)
        {
            if (transfer == 0)
            {
                //HumanPosition.transform.position = Vector3.MoveTowards(HumanPosition.transform.position, GameObject.Find("Center_Alone").transform.GetChild(transfer).localPosition, step);
                HumanPosition.transform.position = GameObject.Find("Center_Alone").transform.GetChild(transfer).localPosition;
            }
            else if (transfer < 5)
            {
                HumanPosition.transform.position = GameObject.Find("Center_Ingredients").transform.GetChild(transfer-1).localPosition;
                //HumanPosition.transform.position = Vector3.MoveTowards(HumanPosition.transform.position, GameObject.Find("Center_Alone").transform.GetChild(transfer - 1).localPosition, step);
            }
            else if (transfer < 9)
            {
                HumanPosition.transform.position = GameObject.Find("Center_Films").transform.GetChild(transfer - 5).localPosition;
                //HumanPosition.transform.position = Vector3.MoveTowards(HumanPosition.transform.position, GameObject.Find("Center_Alone").transform.GetChild(transfer - 5).localPosition, step);
            }
            transferselectedtime = 0;
 
        }


        //Material Change
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            MaterialType = (MaterialType + 1) % 3;
        }
        //...

        

    }
}
