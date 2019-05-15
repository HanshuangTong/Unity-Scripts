using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUV : MonoBehaviour
{
    //image segment
    public int segment;

    int pointNum;


    bool notrun = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (notrun)
        {
            pointNum = transform.childCount;

            for (int i = 0; i < pointNum; i++)
            {
                GameObject PointObject = transform.GetChild(i).GetChild(0).gameObject;
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
            notrun = !notrun;
        }
        
    }
}
