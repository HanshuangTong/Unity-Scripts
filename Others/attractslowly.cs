using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attractslowly : MetaBall {
    public GameObject g1;
    public float speed;
    public Text countText;

    // Use this for initialization
    void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, g1.transform.position, speed * Time.deltaTime);
        if (Input.GetKeyDown(";"))
        {
            speed += 0.5f;

        }
        if (Input.GetKeyDown("'"))
        {
            speed -= 0.5f;

        }
        setcounttext();
    }

    void setcounttext()
    {
        countText.text = "Attract Value: " + speed.ToString();
    }
}
