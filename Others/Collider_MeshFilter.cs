using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_MeshFilter : MonoBehaviour {

    SkinnedMeshRenderer meshRenderer;
    MeshCollider meshcollider;
    MeshFilter meshfilter;
    Mesh temp;

    // Use this for initialization
    void Start () {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        meshcollider = GetComponent<MeshCollider>();
        meshfilter = GetComponent<MeshFilter>();
	}
	
	// Update is called once per frame
	void Update () {
        temp = bakeMesh();
        meshcollider.sharedMesh = temp;
        meshfilter.mesh = temp;
    }
    void LateUpdate()
    {
        temp.Clear();
    }

    Mesh bakeMesh()
    {
        Mesh mesh = new Mesh();
        meshRenderer.BakeMesh(mesh);
        return mesh;
    }
}
