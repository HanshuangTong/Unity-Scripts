using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorAccordingToLocation : MonoBehaviour {
    public Material material_1;
    public Material material_2;
    public Material material_3;
    public Material material_4;
    public Material material_5;
    int positionValue = 0;

    /*public Color colorOfMat;*/

    // Use this for initialization
    void Start () {
        GetComponent<MeshRenderer>().material = material_1;
	} 
	
	// Update is called once per frame
	void Update () {
        positionValue = ((int) (Mathf.Abs(transform.position.x)*2 + Mathf.Abs(transform.position.z) * 2)) % 8;
        switch (positionValue)
        {
            case 0:
                GetComponent<MeshRenderer>().material = material_1;
                break;
            case 1:
                GetComponent<MeshRenderer>().material = material_2;
                break;
            case 2:
                GetComponent<MeshRenderer>().material = material_3;
                break;
            case 3:
                GetComponent<MeshRenderer>().material = material_4;
                break;
            case 4:
                GetComponent<MeshRenderer>().material = material_5;
                break;
            case 5:
                GetComponent<MeshRenderer>().material = material_4;
                break;
            case 6:
                GetComponent<MeshRenderer>().material = material_3;
                break;
            case 7:
                GetComponent<MeshRenderer>().material = material_2;
                break;
        }

    }
}
