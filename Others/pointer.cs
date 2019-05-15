using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class pointer : MonoBehaviour
{


    public GameObject [] target;
    //public GameObject target_01;
   // public GameObject target_02;
    public GameObject avatar;
    //public GameObject right_hand;
    private int selected;
    public int n;
    private int i;
    public float speed;
    //public GameObject target1;
    //public GameObject Alembic_Object;
    //PlayableDirector Alembic;
    //Vector3 init_scale;
    public GameObject g1;
    //public GameObject g2;
    private int st=1;


    // Use this for initialization
    void Start()


    {
        // LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        //Alembic = Alembic_Object.GetComponent<PlayableDirector>();
        //init_scale = Alembic_Object.transform.localScale;
        // Alembic.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        LineRenderer lineRenderer = GetComponent<LineRenderer>();

       // g1.transform.localEulerAngles = new Vector3(g1.transform.localEulerAngles.x, g1.transform.localEulerAngles.y-180, g1.transform.localEulerAngles.z);

        Vector3 forward = g1.transform.forward * 10;

        //forward = Quaternion.AngleAxis(180, g1.transform.right) * forward;

        lineRenderer.SetPosition(0, g1.transform.position);
        lineRenderer.SetPosition(1, g1.transform.position + (forward*100));



        //lineRenderer.SetPosition(0, right_hand.transform.position);
        //lineRenderer.SetPosition(1, ((right_hand.transform.position + (forward * 100s))));
        // lineRenderer.SetPosition(0, g1.transform.position);
        //lineRenderer.SetPosition(1, g2.transform.position);

        // handle user gaze
        //Ray ray = new Ray(right_hand.transform.position, right_hand.transform.forward);
        Ray ray = new Ray(g1.transform.position, g1.transform.forward);
        //Ray ray = new Ray(g1.transform.position, g2.transform.position);
        RaycastHit hit = new RaycastHit();
        

        //object 01 target_01.GetComponent<Collider>().Raycast(ray, out hit, 100.0f) && (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))

        for (i=0; i<n; i++)
        {
            Debug.Log("1");
            if (target[i].GetComponent<Collider>().Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("0");
                //float step = speed * Time.deltaTime;
                //avatar.transform.position = Vector3.MoveTowards(avatar.transform.position, target[i].transform.position, step);
                st = i;
                selected = i;
            }
           // avatar.transform.position = target[st].transform.position;
           // target1.transform.position = target[st].transform.position;
            float step = speed * Time.deltaTime;
            //target[st].transform.position.z
            
            //avatar.transform.position = Vector3.MoveTowards(avatar.transform.position, target[st].transform.position, step);
            avatar.transform.position = Vector3.MoveTowards(avatar.transform.position, new Vector3(target[st].transform.position.x, target[st].transform.position.y+100, target[st].transform.position.z ), step);
            //target1.transform.position = target[st].transform.position;


        }
        /*
        
        if (target_01.GetComponent<Collider>().Raycast(ray, out hit, 100.0f) )
        {
            //Debug.Log("0");
            avatar.transform.position = target_01.transform.position;
        }

        if (target_02.GetComponent<Collider>().Raycast(ray, out hit, 100.0f))
        {
            //Debug.Log("1");
            avatar.transform.position = target_02.transform.position;
        }
        */


    }


}
      

