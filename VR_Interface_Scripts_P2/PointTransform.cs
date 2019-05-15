using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTransform : MonoBehaviour
{
    public GameObject csvReader;
    ReadCSV csvData;

    //time to finish transform
    public float time = 13.333f;
    public float present = 0;

    //object to instantiate
    public GameObject pointObjects;
    private int Prematerial = 0;
    //public GameObject ReferenceMaterial;

    public Vector3[] currentPosition;

    public KeyCode pause = KeyCode.P;
    public bool run = true;

    // Start is called before the first frame update
    void Awake()
    {
        csvData = csvReader.GetComponent<ReadCSV>();
        currentPosition = new Vector3[csvData.pointNum];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            run = !run;
        }
        if (run)
        {
            SetPresent();
            for (int i = 0; i < 4; i++)
            {
                if (present < time * (i + 1) / 4 && present > time * i / 4)
                {
                    PointsTransform(i, i + 1);
                }
            }
        }
    }

    void SetPresent()
    {
        if (present < time)
        {
            present += Time.deltaTime;
        }
        else
        {
            present = present + Time.deltaTime - time;
        }
    }

    void PointsTransform(int Start,int End)
    {
        for (int i=0; i<csvData.pointNum; i++)
        {
            Vector3 start = csvData.pointClouds[Start][i];
            Vector3 end = csvData.pointClouds[End][i];
            float state = (present - time * Start / 4 )/time*4;
            currentPosition[i] = start+(end - start) * state;
        }
    }
}
