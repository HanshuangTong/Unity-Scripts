using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDisplay : MonoBehaviour
{
    public Transform itemGeometries;
    GameObject[][] items;
    public int catNum = 9;
    public int catItemNum = 3;
    public int catPointNum = 100;

    public int selectPointNum = 0;
    int preSelectPointNum = 0;

    // Order to display on screen
    public int[] catOrder;
    public int[] selectItemOrder;

    GameObject[] selectedItems;

    // Start is called before the first frame update
    void Start()
    {
        items = new GameObject[catNum][];
        for (int i = 0; i < catNum; i++)
        {
            items[i] = new GameObject[catItemNum];
            for (int j = 0; j < catItemNum; j++)
            {
                items[i][j] = itemGeometries.GetChild(i).GetChild(j).gameObject;
            }
        }

        catOrder = new int[catNum];
        selectItemOrder = new int[catNum];
    }

    // Update is called once per frame
    void Update()
    {
        selectPointNum = GameObject.Find("PointCloud").GetComponent<ClosestPointsLink>().piclist[0];
        for (int i = 0; i < catNum; i++)
        {
            catOrder[i] = GameObject.Find("PointCloud").GetComponent<ClosestPointsLink>().piclist[i] / catPointNum;
        }
        if (selectPointNum != preSelectPointNum)
        {
            GenerateNewSelection();
            DestroyPrevious();
            preSelectPointNum = selectPointNum;
        }
    }


    void DestroyPrevious()
    {
        for (int i = 0; i < catNum; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    void GenerateNewSelection()
    {
        for (int i = 0; i < catNum; i++)
        {
            selectItemOrder[i] = Random.Range(0, 3);
            GameObject newSelection;
            newSelection = Instantiate(items[catOrder[i]][selectItemOrder[i]],transform);
            newSelection.transform.position = transform.GetChild(i).position;
        }
    }
}
