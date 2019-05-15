using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour {
    void DestroyScriptInstance()
    {
        // Removes this script instance from the game object
        Destroy(this);
    }

    void DestroyComponent(Component c)
    {
        // Removes the rigidbody from the game object
        Destroy(c);
    }

    void DestroyObjectDelayed(float delay)
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, delay);
    }

    // When the user presses Ctrl, it will remove the
    // BoxCollider component from the game object
    void Update()
    {
        if (Mathf.Abs(transform.position.y)>50 || Mathf.Abs(transform.position.x) >50 || Mathf.Abs(transform.position.z) > 50)
        {
            Destroy(gameObject);
        }
    }
}
