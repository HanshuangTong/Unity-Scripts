﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PickupItems : MonoBehaviour {


    float throwForce = 600;
    Vector3 objectpos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if(distance >= 3f)
        {
            isHolding = false;
        }
        //check if isholding

        if (Input.GetKey("f")) {

            if (distance <= 3f)
            {
                isHolding = true {

                    item.GetComponent<Rigidbody>().useGravity = false;
                    item.GetComponent<Rigidbody>().detectCollisions = true;

                    item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    item.transform.SetParent(tempParent.transform);


                    if (Input.GetKey("t"))
                    {
                        item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                        isHolding = false;
                    }
                }
                
            }
        }

        if (Input.GetKey("g"))
        {

            isHolding = false;
        }
            if (isHolding == true)
            {
                item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                item.transform.SetParent(tempParent.transform);


                if (Input.GetKey ("t"))
                {
                    item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                    isHolding = false;
                }
            }
            else
            {
                objectpos = item.transform.position;
                item.transform.SetParent(null);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.transform.position = objectpos;

            }
        }

    void OnMouseDown()
    {
        if(distance <= 3f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
        

    }
    void OnMouseUp()
    {
        isHolding = false;

    }
}*/
