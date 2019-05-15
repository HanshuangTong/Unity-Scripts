using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexTranspancy : MonoBehaviour
{
    int pre_index = 0;
    int now_index = -1;
    public GameObject OBJ_index;
    Renderer[] RendList; 
    int num ;
    // Start is called before the first frame update
    void Start()
    {
        OBJ_index = GameObject.Find("Component");
        num = GameObject.Find("Component").transform.childCount;
        RendList = new Renderer[9];
        for(int i = 0; i < num; i++)
        {
            RendList[i] = OBJ_index.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<MeshRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        now_index = GameObject.Find("AnimateControl").GetComponent<Main_Control>().TraySelected_Index;
        if(now_index != pre_index)
        {
            if(now_index == 0)
            {
                for (int i = 0; i < num; i++)
                {
                    RendList[i].material.SetColor("_Color", Color.white);
                }
            }
            else
            {
                for (int i = 0; i < num; i++)
                {
                    if((now_index-1) == i)
                    {                       
                        RendList[i].material.SetColor("_Color",Color.grey);
                    }
                    else
                    {
                        RendList[i].material.SetColor("_Color", Color.white);
                    }
                }       
            }
        }
        pre_index = now_index;
    }
}


