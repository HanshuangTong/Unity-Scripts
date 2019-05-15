using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedImage : MonoBehaviour
{
    bool ScreenImageToggle = false;
    GameObject PointCloud;
    Main_Control Center;
    // Start is called before the first frame update
    void Start()
    {
        PointCloud = GameObject.Find("PointCloud");
        Center = GameObject.Find("AnimateControl").GetComponent<Main_Control>();
    }

    // Update is called once per frame
    void Update()
    {
        ScreenImageToggle = Center.ScreenImageIndex;
        if (ScreenImageToggle)
        {
            GetComponent<MeshRenderer>().material = PointCloud.transform.GetChild(Center.SelectedImageIndex).gameObject.GetComponent<MeshRenderer>().material;
            Debug.Log("ImageMapped");
        }
    }
}
