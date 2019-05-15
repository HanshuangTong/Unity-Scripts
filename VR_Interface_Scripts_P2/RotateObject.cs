using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationAngle;
    Quaternion startAngle;
    Quaternion endAngle;

    public float duration;
    float nowTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        startAngle = transform.rotation;
        endAngle = Quaternion.Euler(startAngle.eulerAngles + rotationAngle);
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(startAngle, endAngle, nowTime / duration);
    }
}
