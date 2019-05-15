using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap_Material : MonoBehaviour
{
    private int MaterialType = 0;
    private int alembicrendered = 0;
    public GameObject[] PointCloudlist = new GameObject[3];
    public Material[] Materiallist = new Material[5];
    //public KeyCode k1;
    private Color cwhite = new Color(1, 1, 1, 1);
    public Color [] colorlist = new Color[4];
    // Start is called before the first frame update
    void Start()
    {
        colorlist[0] = new Color(1, 1, 1, 0);
        colorlist[1] = new Color(1, 0, 0, 0);
        colorlist[2] = new Color(0, 1, 0, 0);
        colorlist[3] = new Color(0, 0, 1, 0);

    }   // Update is called once per frame
    void Update()
    {
        MaterialType = GameObject.Find("AnimateControl").GetComponent<OculusControl>().MaterialType;
        alembicrendered = GameObject.Find("AnimateControl").GetComponent<OculusControl>().alembicrendered;
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            if (MaterialType == 0)
            {
                for (int i = 0; i < PointCloudlist[alembicrendered].GetComponent<ReadCSV>().pointNum; i++)
                {
                    SetMaterial(PointCloudlist[alembicrendered].transform.GetChild(i).gameObject, Materiallist[0], cwhite);
                }
            }
            if (MaterialType == 1)
            {
                for (int i = 0; i < PointCloudlist[alembicrendered].GetComponent<ReadCSV>().pointNum; i++)
                {
                    SetMaterial(PointCloudlist[alembicrendered].transform.GetChild(i).gameObject, Materiallist[alembicrendered + 1], cwhite);
                }
            }
            if (MaterialType == 2)
            {
                int x1 = PointCloudlist[alembicrendered].GetComponent<ReadCSV>().pointNum;
                int x2 = PointCloudlist[alembicrendered].GetComponent<ReadCSV>().subsetNum;
                for (int j = 0;j< x1/x2; j++)
                {
                    for (int i = 0; i < x2; i++)
                    {
                        //Color ctemp = new Color(1.0f / (j + 1), 1.0f / (j + 1), 1.0f / (j + 1), 1);
                        //SetMaterial(PointCloudlist[alembicrendered].transform.GetChild(j*x2+i).gameObject, Materiallist[4], ctemp);
                        SetMaterial(PointCloudlist[alembicrendered].transform.GetChild(j * x2 + i).gameObject, Materiallist[4], colorlist[j]);
                    }
                }
                
            }
        }
        //Debug.Log("mt : " + MaterialType);
    }
    void SetMaterial(GameObject g1, Material m,Color c1)
    {
        MeshRenderer rend = g1.GetComponent<MeshRenderer>();
        rend.material = m;
        rend.material.SetColor("_Color", c1);
    }
}
