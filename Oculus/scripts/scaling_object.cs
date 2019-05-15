using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaling_object : MonoBehaviour {

    public float scale_min;
    public float scale_max;
    public float speed = 0.01f;
    Vector3 scale;

    // Use this for initialization
    void Start () {
        scale = gameObject.transform.localScale;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(scale.x> scale_min && scale.x<scale_max)

        {

            speed = speed;
        }

        if (scale.x < scale_min)

        {

            speed = Mathf.Abs(speed);
        }

        if (scale.x > scale_max)

        {

            speed = -speed;
        }

        scale  = scale + (new Vector3(speed,speed,speed));

        gameObject.transform.localScale = scale;
		
	}
}
