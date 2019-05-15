using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundReaction : MonoBehaviour
{
    
    //GameObject[] cubes = new GameObject[8];
    public float maxScale = 1f;
    Vector3 originalScale;
    Vector3 originalPosition;
    int frequency = 0;


    // Use this for initialization
    void Start()
    {
        /*for (int i = 0; i < 8; i++)
        {
            GameObject instanceCube = (GameObject)Instantiate(cube);
            instanceCube.transform.position = transform.position;
            instanceCube.transform.parent = transform;
            instanceCube.name = "cube" + i;
            transform.eulerAngles = new Vector3(0, 45f * i, 0);
            instanceCube.transform.position = Vector3.forward * 1;
            cubes[i] = instanceCube;
        }*/
        frequency = Random.Range(1, 8);
        originalScale = transform.localScale;
        originalPosition = transform.localPosition;

        
    }

        // Update is called once per frame
    void Update()
    {
            /*for (int i = 0; i < 8; i++)
            {
                if (cubes != null)
                {
                    cubes[i].transform.localScale = new Vector3(0.1f, (Audio.freqBand[i] * maxScale) + 0.1f, 0.1f);
                }
            }*/

            transform.localScale = new Vector3((Audio.freqBand[frequency] * maxScale), (Audio.freqBand[frequency] * maxScale), (Audio.freqBand[frequency] * maxScale)) + originalScale;
            //transform.localPosition = new Vector3((Audio.freqBand[1] * maxScale), (Audio.freqBand[1] * maxScale), (Audio.freqBand[1] * maxScale))+originalPosition;

    }

}