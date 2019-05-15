using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class pointer : MonoBehaviour
{


    public GameObject points;
    public int PointNum;
    public GameObject OriginObject;
    private bool run = false;
    public GameObject Object_ForClosestPoint;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            run = !run;
        }
        if (run)
        {           
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            Vector3 forward = OriginObject.transform.forward * 10;
            lineRenderer.SetPosition(0, OriginObject.transform.position);
            lineRenderer.SetPosition(1, OriginObject.transform.position + (forward * 100));
            Ray ray = new Ray(OriginObject.transform.position, OriginObject.transform.forward);
            RaycastHit hit = new RaycastHit();

            for (int i = 0; i < PointNum; i++)
            {
                if (points.transform.GetChild(i).gameObject.GetComponent<Collider>().Raycast(ray, out hit, 100.0f))
                {
                    points.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                    Object_ForClosestPoint.GetComponent<ClosestPointsLink>().selectNum = i;
                    Object_ForClosestPoint.GetComponent<ClosestPointsLink>().state = true;
                    Debug.Log("s1" + Object_ForClosestPoint.GetComponent<ClosestPointsLink>().state);
                }
                else
                {
                    points.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    Object_ForClosestPoint.GetComponent<ClosestPointsLink>().state = false;
                }
            }
        }
        //Debug.Log(run);
    }
}
      

