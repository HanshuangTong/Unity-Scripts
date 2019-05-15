using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectColor : MonoBehaviour
{
    public bool state = false;
    int pre_index = 0;
    int now_index = -1;

    Renderer[] RendList;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        /*
        RendList = new Renderer[9];
        num = 9;
        for (int i = 0; i < num; i++)
        {
            RendList[i] = transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>();
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (state)
        {
            now_index = GameObject.Find("AnimateControl").GetComponent<Main_Control>().TraySelected_Index;
            if (now_index != pre_index)
            {
                Debug.Log("change");
                if (now_index == 0)
                {
                    for (int i = 0; i < num; i++)
                    {
                        transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    }
                }
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        if ((now_index - 1) == i)
                        {
                            Debug.Log("red");
                            transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                        }
                        else
                        {
                            transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                        }
                    }
                }
            }
            pre_index = now_index;
        }
    }
}
