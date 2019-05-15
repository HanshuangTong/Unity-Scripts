using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GazeControl_Alembic : MonoBehaviour {



    
    public GameObject Alembic_Object;
    PlayableDirector Alembic;
    Vector3 init_scale;

   

    // Use this for initialization
    void Start()

        
{
        Alembic = Alembic_Object.GetComponent<PlayableDirector>();
        init_scale = Alembic_Object.transform.localScale;
        Alembic.enabled = false;
    }

// Update is called once per frame
void Update()
{
    // handle user gaze
    Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
    RaycastHit hit = new RaycastHit();


        //object 01
        {
            if (Alembic_Object.GetComponent<Collider>().Raycast(ray, out hit, 100.0f))
            {
                Alembic_Object.transform.localScale = (init_scale * 1.2f);
            }

            else

            {

                Alembic_Object.transform.localScale = (init_scale);

            }


            if (Alembic_Object.GetComponent<Collider>().Raycast(ray, out hit, 100.0f) && (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick)))
            {
                Alembic.enabled = true;
            }

            if (Alembic_Object.GetComponent<Collider>().Raycast(ray, out hit, 100.0f) && (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick)))
            {
                Alembic.enabled = false;
            }


        }    

       

        


    }
}
