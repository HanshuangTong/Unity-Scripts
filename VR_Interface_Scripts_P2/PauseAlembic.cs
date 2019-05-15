using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PauseAlembic : MonoBehaviour
{
    

    public KeyCode pause = KeyCode.P;
    public bool state = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            state = !state;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<PlayableDirector>().enabled = state;
        }
    }
}
