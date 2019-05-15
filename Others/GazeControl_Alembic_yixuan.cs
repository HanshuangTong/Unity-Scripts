using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GazeControl_Alembic : MonoBehaviour {


    public GameObject target_01;
    public GameObject target_02;
    public GameObject avatar;
    public GameObject right_hand;
    
    //public GameObject Alembic_Object;
    //PlayableDirector Alembic;
    //Vector3 init_scale;

   

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

        Vector3 forward = right_hand.transform.forward * 10;

        forward = Quaternion.AngleAxis(30, right_hand.transform.right) * forward;

       /* lineRenderer.SetPosition(1, right_hand.transform.position);

        lineRenderer.SetPosition(2, forward);
        */
        

       

        
        lineRenderer.SetPosition(0, right_hand.transform.position);
        lineRenderer.SetPosition(1, ((right_hand.transform.position + (forward * 100))));

        


        // handle user gaze
        Ray ray = new Ray(right_hand.transform.position, right_hand.transform.right);
        RaycastHit hit = new RaycastHit();


        //object 01 target_01.GetComponent<Collider>().Raycast(ray, out hit, 100.0f) && (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {


            if (target_01.GetComponent<Collider>().Raycast(ray, out hit, 1000.0f) )
            {
                avatar.transform.position = target_01.transform.position;
            }

            if (target_02.GetComponent<Collider>().Raycast(ray, out hit, 1000.0f) && (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick)))
            {
                avatar.transform.position = target_02.transform.position;
            }




        }    

       

        


    }
}
