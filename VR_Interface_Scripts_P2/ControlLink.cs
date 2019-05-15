using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLink : MonoBehaviour
{
    public KeyCode link = KeyCode.L;
    public KeyCode change = KeyCode.C;
    ClosestPointsLink closestPointsLink;

    // Start is called before the first frame update
    void Start()
    {
        closestPointsLink = GetComponent<ClosestPointsLink>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(link))
        {
            closestPointsLink.state = !closestPointsLink.state;
        }

        if (Input.GetKey(change))
        {
            closestPointsLink.selectNum++;
        }
    }
}
