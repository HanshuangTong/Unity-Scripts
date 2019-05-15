using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour {
    public float speed = 10;
    public bool canHold = true;
    public GameObject ball;
    public Transform guide;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("g")) {
            if (!canHold)
                throw_drop();
            else
                Pickup();

        }
        if (!canHold && ball)
            ball.transform.position = guide.position;

		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ball")
            if (!ball)
                ball = col.gameObject;

    }
    private void OnTriggerExit(Collider col)
    
    {
        if (col.gameObject.tag == "ball") {
            if (canHold)
                ball = null;
        }
    }

    private void Pickup()
    {
        if (!ball)
            return;
        ball.transform.SetParent(guide);
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.transform.localRotation = transform.rotation;
        ball.transform.position = guide.position;
        canHold = false;
    }

    private void throw_drop()
    {
        if (!ball)
            return;
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball = null;
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        guide.GetChild(0).parent = null;
        canHold = true;
    }
}
