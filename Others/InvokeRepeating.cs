using UnityEngine;
using System.Collections;

public class InvokeRepeating : MonoBehaviour
{
    public GameObject target;
    public GameObject source;


    void Start()
    {
        
            InvokeRepeating("SpawnObject", 1, 1);
    }

    void SpawnObject()
    {
        float x = source.transform.position.x;
        float z = source.transform.position.z;
        Instantiate(target, new Vector3(x, 2, z), Quaternion.identity);
    }
}