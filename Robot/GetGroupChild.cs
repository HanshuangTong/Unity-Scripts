using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGroupChild : MonoBehaviour {
    public GameObject group;
    List<GameObject> children;

	// Use this for initialization
	void Start () {
        children = new List<GameObject>();

	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < group.transform.childCount;i++)
        {
            children.Add(group.transform.GetChild(i).gameObject);
        }
	}
}
