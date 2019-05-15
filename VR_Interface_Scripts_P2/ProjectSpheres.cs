using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class ProjectSpheres : MonoBehaviour
{
    public KeyCode map = KeyCode.M;
    public bool state = false;
    bool reverseState = false;

    public int pointNum = 560;
    public int catergoryPointNum = 140;

    //public int selectedCatNum = 0;
    public Transform averagePoints;

    Vector3[] currentPosition;

    public int startLayer = 10;
    //Vector3[] currentTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = GetComponent<PointTransform>().currentPosition;

        if (Input.GetKeyDown(map))
        {
            state = !state;
            //PausePointTransform();
            //PauseAlembic();  
        }
        if (state)
        {
            if (!reverseState)
            {
                ReverseMesh();
                reverseState = true;
            }
            Project();
        }

        if (!state)
        {
            RegularTransform();
            if (reverseState)
            {
                ReverseMesh();
                reverseState = false;
            }
        }
    }


    void PausePointTransform()
    {
        GetComponent<PointTransform>().run = !state;
    }

    void ReverseMesh()
    {
        for (int i = 0; i < pointNum / catergoryPointNum; i++)
        {
            GameObject meshObject = averagePoints.GetChild(i).gameObject;
            //Debug.Log(averagePoints.GetChild(i).gameObject.layer);
            Mesh mesh = meshObject.GetComponent<MeshFilter>().mesh;
            mesh.triangles = mesh.triangles.Reverse().ToArray();
            meshObject.AddComponent<MeshCollider>();
            meshObject.GetComponent<MeshCollider>().sharedMesh = mesh;
            meshObject.layer = startLayer+i;
        }
    }

    void Project()
    {
        for (int catNum = 0; catNum < pointNum / catergoryPointNum; catNum++)
        {
            for (int i = catNum*catergoryPointNum; i < (catNum + 1) * catergoryPointNum; i++)
            {
                Vector3 direction = currentPosition[i] - averagePoints.GetChild(catNum).position;

                // Bit shift the index of the layer (8) to get a bit mask
                int layerMask = 1 << startLayer+catNum;

                // This would cast rays only against colliders in layer 8.
                // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
                //layerMask = ~layerMask;

                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(averagePoints.GetChild(catNum).position, direction, out hit, 1000, layerMask))
                {
                    transform.GetChild(i).position = direction.normalized * hit.distance + averagePoints.GetChild(catNum).position;
                    Debug.DrawRay(averagePoints.GetChild(catNum).position, direction.normalized * hit.distance, Color.yellow);
                    //Debug.Log("Did Hit");
                }
                else
                {
                    Debug.DrawRay(averagePoints.GetChild(catNum).position, direction.normalized * 1000f, Color.white);
                    //Debug.Log("not hit");
                }
            }
        }

        /*for (int i=catergoryPointNum; i<pointNum; i++)
        {
            transform.GetChild(i).position = currentPosition[i];
        }
        */
    }

    void RegularTransform()
    {
        for (int i = 0; i < pointNum; i++)
        {
            transform.GetChild(i).position = currentPosition[i];
        }
    }
}
