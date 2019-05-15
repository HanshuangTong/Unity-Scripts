using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    public GameObject Object_Need_transfer;
    private GetAverage g;
    public GameObject Object_Contains_Center;

    public float present = 0;
    public float time = 3000f;

    // Start is called before the first frame update
    void Start()
    {
        g = Object_Contains_Center.GetComponent<GetAverage>();
    }

    // Update is called once per frame
    void Update()
    {
        int index = GameObject.Find("AnimateControl").GetComponent<Main_Control>().Teleport_Position;
        if (index!=0)
        {
            Debug.Log("index"+index);
            //Object_Need_transfer.transform.position = Vector3.MoveTowards(Object_Need_transfer.transform.position, g.transform.GetChild(index).position, step);
            SetPresent();
            Object_Need_transfer.transform.position = PointsTransform(Object_Need_transfer.transform.position, g.transform.GetChild(index).position);
            //Object_Need_transfer.transform.position = g.transform.GetChild(index).position;
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
    Vector3 PointsTransform(Vector3 Start, Vector3 End)
    {

        float state = present / time;
        return Start + (End - Start) * state;
    }
}
