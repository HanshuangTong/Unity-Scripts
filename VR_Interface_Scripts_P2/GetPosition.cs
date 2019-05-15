using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosition : MonoBehaviour
{
    public GameObject TargetPosition;
    public float DetachX = 0f;
    public float DetachY = 0f;
    public float DetachZ = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(TargetPosition.transform.position.x+ DetachX, TargetPosition.transform.position.y + DetachY, TargetPosition.transform.position.z + DetachZ);

    }
}
