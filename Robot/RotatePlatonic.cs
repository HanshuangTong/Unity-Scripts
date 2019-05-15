using UnityEngine;
using System.Collections;

public class RotatePlatonic : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;


    void Update()
    {
        if (Input.GetKey("d"))
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);

        if (Input.GetKey("s"))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }
}