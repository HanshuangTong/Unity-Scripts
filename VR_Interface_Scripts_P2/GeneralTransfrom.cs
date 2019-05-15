using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTransfrom : MonoBehaviour
{
    public int NumOfPointNeedToTransfer;
    public float time = 20f;
    float present = 0;
    // Start is called before the first frame update
    GameObject[] Tcubes;
    Vector3[] TcubesStartPosition;

    ReadCSV csvData;
    bool run = true;
    public int NumDisplaycube;
    bool FirstTransfromSignal = false;

    void Start()
    {
        csvData = GameObject.Find("PointCloud_Alone").GetComponent<ReadCSV>();
             
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            TcubesStartPosition = new Vector3 [NumOfPointNeedToTransfer];
            for (int i = 0; i < NumOfPointNeedToTransfer; i++)
            {
                TcubesStartPosition[i] = this.gameObject.transform.GetChild(i).position;
                //Debug.Log(GameObject.Find("SpriteStage").transform.GetChild(i).position);
            }
            NumDisplaycube = this.gameObject.transform.childCount;
            run = !run;
        }
        FirstTransfromSignal = GameObject.Find("AnimateControl").GetComponent<OculusControl>().FirstTransfromSignal;

        if (FirstTransfromSignal)
        {
            SetPresent();

            for (int i = 0; i < NumOfPointNeedToTransfer; i++)
            {
                PointsTransform(this.gameObject.transform.GetChild(i), TcubesStartPosition[i], csvData.pointClouds[0][i]);
            }
            for (int i = NumOfPointNeedToTransfer; i < NumDisplaycube; i++)
            {
                GameObject.Destroy(this.gameObject.transform.GetChild(i).gameObject);
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
            GameObject.Find("AnimateControl").GetComponent<OculusControl>().alembicrendered = 0;
            this.gameObject.SetActive(false);
        }
    }
    void PointsTransform(Transform g1,Vector3 Start, Vector3 End)
    {
        g1.position = Start + (End - Start) * present / time;
    }
}
