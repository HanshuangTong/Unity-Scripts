using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public GameObject leader;
    public float followSharpness = 0.05f;

    void Update()
    {
        transform.position += (leader.transform.position - transform.position) * followSharpness;
    }
}