
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAverage : MonoBehaviour
{
    public Transform pointObjects;
    public int pointNum = 1200;
    public int subsetNum = 150;
    private int classnum;
    Vector3[] points;
    public Transform centers;
    public float scaleFactor = 100;
    bool firstRun = true;
    //public Material[] sphereMaterial = new Material[9];
    public GameObject[] sphereTemplates;
    public int sphereStartLayer = 10;
    void Start()
    {
        classnum = pointNum / subsetNum;
        for (int i = 0; i < pointNum / subsetNum; i++)
        {
            //GameObject center = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GameObject center = Instantiate(sphereTemplates[i], centers);
            center.name = string.Concat("center", sphereTemplates[i].name);
            center.layer = sphereStartLayer+i;
            //center.GetComponent<MeshRenderer>().material = sphereMaterial[i];
            //center.GetComponent<MeshRenderer>().enabled = false;
        }
        points = new Vector3[pointNum];
    }


    // Update is called once per frame
    void Update()
    {
        points = pointObjects.GetComponent<PointTransform>().currentPosition;
        for (int i = 0; i < pointNum / subsetNum; i++)
        {
            GameObject center = centers.transform.GetChild(i).gameObject;
            Vector3 pointSum = new Vector3(0, 0, 0);
            float distantSum = 0;
            for (int j = i * subsetNum; j < (i + 1) * subsetNum; j++)
            {
                pointSum += points[j];
            }
            Vector3 pointAver = pointSum / subsetNum;
            for (int j = i * subsetNum; j < (i + 1) * subsetNum; j++)
            {
                distantSum += Vector3.Magnitude(pointAver - points[j]);
            }
            center.transform.localPosition = pointAver;
            center.transform.localScale = new Vector3(distantSum / subsetNum * scaleFactor, distantSum / subsetNum * scaleFactor, distantSum / subsetNum * scaleFactor);
        }
    }

}
