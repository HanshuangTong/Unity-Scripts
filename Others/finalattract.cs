using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalattract : MonoBehaviour {
    public GameObject m1;
    private SkinnedMeshRenderer z1;
    private int vertexindex;
    private Rigidbody rb;
    private Vector3[] v1;
    private Mesh m2;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        z1 = m1.GetComponent<SkinnedMeshRenderer>();
        //z1.BakeMesh(m2);
        //v1 = m2.vertices; 
        //vertexindex = Random.Range(0, v1.Length);
    }
	
	// Update is called once per frame
	void Update () {
        z1.BakeMesh(m2);
        v1 = m2.vertices;
        rb.AddForce((v1[0] - this.transform.position) * 1.0f);
        m2.Clear();
    }
}
