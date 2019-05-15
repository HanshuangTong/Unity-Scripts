using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPic : MonoBehaviour
{
    //int[] pic_list;
    public GameObject GameScreenObj;
    int num;
    public int segment;
    // Start is called before the first frame update
    void Start()
    {
        num = GameObject.Find("Component").transform.childCount;
        //pic_list = new int[num];
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("AnimateControl").GetComponent<Main_Control>().ScreenRun)
        {
            GameScreenObj.SetActive(true);
            for(int i=0; i < num; i++)
            {
                setpicture(GameScreenObj.transform.GetChild(i).gameObject, i, GameObject.Find("PointCloud").GetComponent<ClosestPointsLink>().piclist[i]);
            }
            
        }
        else
        {
            GameScreenObj.SetActive(false);
        }
    }
    void setpicture(GameObject g1,int si,int i)
    {
        GameObject PointObject = GameScreenObj.transform.GetChild(si).gameObject;
        Mesh mesh = PointObject.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector2[] uvs = new Vector2[vertices.Length];

        for (int j = 0; j < uvs.Length; j++)
        {
            //Vector2 segmentation = new Vector2(1f/segment, 1f/segment);
            Vector2 segmentation = new Vector2((i - (i / segment) * segment) * 1f / segment, (segment - 1 - (i + 1) / segment) * 1f / segment);
            //Debug.Log(segmentation);
            uvs[j] = mesh.uv[j] / segment + segmentation;
        }

        mesh.uv = uvs;
    }
}
