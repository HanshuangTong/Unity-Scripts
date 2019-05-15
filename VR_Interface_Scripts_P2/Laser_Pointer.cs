using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Pointer : MonoBehaviour
{
    public GameObject points;
    public int PointNum;
    public GameObject OriginObject;
    Main_Control Center;

    LayerMask mask;
    //public GameObject Object_ForClosestPoint;
    // Start is called before the first frame update
    void Start()
    {
        Center = GameObject.Find("AnimateControl").GetComponent<Main_Control>();
    }

    // Update is called once per frame
    void Update()
    {

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        Vector3 forward = OriginObject.transform.forward * 10;
        lineRenderer.SetPosition(0, OriginObject.transform.position);
        lineRenderer.SetPosition(1, OriginObject.transform.position + (forward * 200));
        Ray ray = new Ray(OriginObject.transform.position, OriginObject.transform.forward);
        RaycastHit hit = new RaycastHit();
        //mask = LayerMask.GetMask("AlembicBase", "NoneSelect");
        //mask = ~mask;

        for (int i = 0; i < PointNum; i++)
        {
            if (points.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<Collider>().Raycast(ray, out hit, 200.0f))
            //if(Physics.Raycast(ray,200f,mask))
            {
                Center.SelectedImageIndex = i;
                points.transform.GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                //points.transform.GetChild(i).localScale = 5 * points.transform.GetChild(i).localScale;
                GameObject.Find("PointCloud").GetComponent<ClosestPointsLink>().state = true;
                GameObject.Find("PointCloud").GetComponent<ClosestPointsLink>().selectNum = i;
                //Object_ForClosestPoint.GetComponent<ClosestPointsLink>().selectNum = i;
                //Object_ForClosestPoint.GetComponent<ClosestPointsLink>().state = true;
                //Debug.Log("s1" + Object_ForClosestPoint.GetComponent<ClosestPointsLink>().state);
            }
            else
            {
                points.transform.GetChild(i).GetChild(0).gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                //points.transform.GetChild(i).localScale = 0.2f * points.transform.GetChild(i).localScale;
                //Object_ForClosestPoint.GetComponent<ClosestPointsLink>().state = false;
            }
        }
    }
}
