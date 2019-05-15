using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiator : MonoBehaviour
{
    public GameObject objToInstantiate;
    public int objCount = 200;
    public float delay = 0.05f;
    public float radius = 1f;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateObjects());
    }

    IEnumerator InstantiateObjects()
    {
        for (int i = 0; i < objCount; i++)
        {
            Vector3 pos = transform.position + (Random.insideUnitSphere*radius);
            pos.y = transform.position.y;
            GameObject clone = (GameObject) Instantiate(objToInstantiate, pos, Quaternion.identity);
            clone.transform.parent = transform;

            yield return new WaitForSeconds(delay);
        }
    }
}
