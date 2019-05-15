using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyCopy_Robot : MonoBehaviour {

    public float newScaleMin = 1f;
    public float newScaleMax = 1f;
    public GameObject source;
    public float shootSpeed;
    public GameObject target;


    void Start()
    {

        //shootSpeed = Random.Range(5, 25);
    }

  

    public void Modify(GameObject copy, bool scale, bool position, bool gravity, bool speed)
    {
        if (scale)
        {
            float newScale = Random.Range(newScaleMin, newScaleMax);
            copy.transform.localScale = new Vector3(newScale, newScale, newScale);
        }
        if (position)
        {
            copy.transform.position = source.transform.position;
        }

        if (gravity)
        {
            copy.GetComponent<Rigidbody>().WakeUp();
            copy.GetComponent<Rigidbody>().useGravity = true;
        }
        if (speed)
        {
            copy.GetComponent<Rigidbody>().WakeUp();
            Vector3 heading = target.transform.position - source.transform.position;
            copy.GetComponent<Rigidbody>().velocity = heading.normalized * shootSpeed;
        }
    }



    /*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
