using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTrack : MonoBehaviour {

    public GameObject Robots;
    private Vector3 RobotPosition;
    public string MoveRobots;



	// Use this for initialization
	void Start () {
        //RobotPosition = new Vector3(0, 0, Random.Range(-3.0f, 3.0f));
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(MoveRobots))
        {
            RobotPosition = new Vector3(0, 0, Random.Range(-3.0f, 3.0f));
            Robots.transform.position = RobotPosition;
        }
        

       
    }
}
