using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCompass : MonoBehaviour
{
    public int pointNum = 1200;
    public int subsetNum = 150;
    GameObject[][] linkcylinder;
    public Material LinkMaterial;
    public bool CompassAnimate = true;
    public float scaleFactor = 100;
    public Transform pointObjects;
    public GameObject Object_Attached;
    public Transform centers;

    // Start is called before the first frame update
    void Start()
    {
        linkcylinder = new GameObject[pointNum / subsetNum][];
        for (int i = 0; i < pointNum / subsetNum; i++)
        {
            linkcylinder[i] = new GameObject[pointNum / subsetNum];
            for (int j = i + 1; j < pointNum / subsetNum; j++)
            {
                linkcylinder[i][j] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                linkcylinder[i][j].name = string.Concat("linkcylinder", i, j);
                linkcylinder[i][j].transform.SetParent(Object_Attached.transform);
                linkcylinder[i][j].transform.localScale = linkcylinder[i][j].transform.localScale * scaleFactor * 0.005f;
                linkcylinder[i][j].GetComponent<MeshRenderer>().material = LinkMaterial;
            }
        }     
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pointNum / subsetNum; i++)
        {
            for (int j = i + 1; j < pointNum / subsetNum; j++)
            {
                //Debug.Log(Object_Attached.transform.GetChild(i).gameObject.transform.localPosition);
                move_cylinder(linkcylinder[i][j], centers.transform.GetChild(i).gameObject.transform.localPosition, centers.transform.GetChild(j).gameObject.transform.localPosition);
            }
        }
    }

    void move_cylinder(GameObject g1, Vector3 p1, Vector3 p2)
    {
        Vector3 pos = Vector3.Lerp(p1, p2, (float)0.5);
        g1.transform.localPosition = pos;
        g1.transform.LookAt(p2);
        g1.transform.up = p1 - p2;
        g1.transform.localScale = new Vector3(g1.transform.localScale.x, 0.5f * Vector3.Distance(p1, p2), 1.0f * g1.transform.localScale.z);
    }

}
