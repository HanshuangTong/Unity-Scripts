using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyToCreateHole : MonoBehaviour {
    public GameObject bound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        GameObject newHole;
        newHole = Instantiate(gameObject,bound.transform);
        Destroy(newHole.GetComponent<CopyToCreateHole>());
        newHole.GetComponent<BoxCollider>().isTrigger = true;
        //Vector3 transformDirection = holeTemplate.transform.position - bound.transform.position;
        //newHole.transform.position += Vector3.down * 0.4f;
        //Destroy(newHole.GetComponent<Rigidbody>());
        
    }
}
