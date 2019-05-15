using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LAB_scene_03_package : MonoBehaviour
{
    // INPUT FOR VIVE
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId touchButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
    private SteamVR_TrackedObject trackedObjectL;  // controller ID
    private SteamVR_Controller.Device deviceL;
    private SteamVR_TrackedObject trackedObjectR;  // controller ID
    private SteamVR_Controller.Device deviceR;
    public GameObject idL;
    public GameObject idR;
    // END INPUT

    private bool selected_or_not;
    public LineRenderer Line;
    private Vector3 new_end_pt;
    private Vector3 dist;
    private Vector3 tem_rendline_end;
    float line_length;

    public GameObject b_atmosphere_01;
    private Vector3 b_atmosphere_01_oriscale;
    public GameObject b_atmosphere_02;
    private Vector3 b_atmosphere_02_oriscale;
    public GameObject b_atmosphere_03;
    private Vector3 b_atmosphere_03_oriscale;
    public GameObject b_exit;
    private Vector3 b_exit_oriscale;

    public GameObject all_furniture;

    public GameObject scene_collect_01;
    public GameObject scene_collect_02;
    public GameObject scene_collect_03;

    public GameObject picture_wall_parent;
    private List<Transform> furniture_pictures = new List<Transform>(); //一定要定义 = 一个列表，不然会出错！！
    private List<Vector3> furniture_pictures_oriscales = new List<Vector3>();

    public GameObject complex_chair_01;
    public GameObject complex_chair_01_collider;
    public GameObject complex_chair_02;
    public GameObject complex_chair_02_collider;
    public GameObject complex_chair_03;
    public GameObject complex_chair_03_collider;
    public GameObject complex_chair_04;
    public GameObject complex_chair_04_collider;

    // material for complex chair
    public Material selected_highlight;
    public Material default_material;




    void Start()
    {
        trackedObjectL = idL.GetComponent<SteamVR_TrackedObject>();
        trackedObjectR = idR.GetComponent<SteamVR_TrackedObject>();


        selected_or_not = false;
        Line.enabled = true;

        // set the original length of select_line
        line_length = 2000f;

        // save the original data
        b_atmosphere_01_oriscale = b_atmosphere_01.gameObject.transform.localScale;
        b_atmosphere_02_oriscale = b_atmosphere_02.gameObject.transform.localScale;
        b_atmosphere_03_oriscale = b_atmosphere_03.gameObject.transform.localScale;
        b_exit_oriscale = b_exit.gameObject.transform.localScale;

        // read furniture pictures and save the original scales
        for (int i = 0;  i < picture_wall_parent.transform.childCount; i++)
        {
            furniture_pictures.Add(picture_wall_parent.transform.GetChild(i));
            Debug.Log(i);
            furniture_pictures_oriscales.Add(picture_wall_parent.transform.GetChild(i).localScale);
        }

        complex_chair_01_collider.SetActive(false);
        //complex_chair_01.GetComponentInChildren<Renderer>().material = selected_highlight;
    }

  
    void Update()
    {
        deviceL = SteamVR_Controller.Input((int)trackedObjectL.index);
        deviceR = SteamVR_Controller.Input((int)trackedObjectR.index);

        // raycast system
        Vector3 line_render_end = transform.position + transform.forward * line_length;
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, transform.position + transform.forward * 200f);

        RaycastHit select_hit;

        Ray select_ray = new Ray(transform.position, transform.position + transform.forward * 5000f);

        Physics.Raycast(select_ray, out select_hit);

        // exit the scene
        if (b_exit.GetComponent<Collider>().Raycast(select_ray, out select_hit, 5000f) && selected_or_not == false)
        {
            selected_or_not = true;
            b_exit.gameObject.transform.localScale = 1.5f * b_exit_oriscale;

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                SceneManager.LoadScene(4);
            }
        }
        else
        {
            selected_or_not = false;
            b_exit.gameObject.transform.localScale = 1.0f * b_exit_oriscale;
        }

        // show or hide office 01
        if (b_atmosphere_01.GetComponent<Collider>().Raycast(select_ray, out select_hit, 5000f) && selected_or_not == false)
        {
            selected_or_not = true;
            b_atmosphere_01.gameObject.transform.localScale = 1.5f * b_atmosphere_01_oriscale;

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                scene_collect_01.SetActive(true);
                scene_collect_02.SetActive(false);
                scene_collect_03.SetActive(false);
            }
        }
        else
        {
            selected_or_not = false;
            b_atmosphere_01.gameObject.transform.localScale = 1.0f * b_atmosphere_01_oriscale;
        }

        // show or hide office 02
        if (b_atmosphere_02.GetComponent<Collider>().Raycast(select_ray, out select_hit, 5000f) && selected_or_not == false)
        {
            selected_or_not = true;
            b_atmosphere_02.gameObject.transform.localScale = 1.5f * b_atmosphere_01_oriscale;

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                scene_collect_01.SetActive(false);
                scene_collect_02.SetActive(true);
                scene_collect_03.SetActive(false);
            }
        }
        else
        {
            selected_or_not = false;
            b_atmosphere_02.gameObject.transform.localScale = 1.0f * b_atmosphere_01_oriscale;
        }

        // show or hide office 03
        if (b_atmosphere_03.GetComponent<Collider>().Raycast(select_ray, out select_hit, 5000f) && selected_or_not == false)
        {
            selected_or_not = true;
            b_atmosphere_03.gameObject.transform.localScale = 1.5f * b_atmosphere_01_oriscale;

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                scene_collect_01.SetActive(false);
                scene_collect_02.SetActive(false);
                scene_collect_03.SetActive(true);
            }
        }
        else
        {
            selected_or_not = false;
            b_atmosphere_03.gameObject.transform.localScale = 1.0f * b_atmosphere_01_oriscale;
        }


        if (deviceL.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))  ////////////////
        {
            complex_chair_01_collider.SetActive(true);
        }

        //
        // select complex chair 01 

        if (complex_chair_01_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 5000f) && selected_or_not == false)
        {

            selected_or_not = true;
            for (int i = 0; i < complex_chair_01.transform.childCount; i++)
            {
                complex_chair_01.transform.GetChild(i).GetComponentInChildren<Renderer>().material = selected_highlight;
            }

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Trigger)) ////L
            {
                select_hit.transform.position = Vector3.MoveTowards(select_hit.transform.position, transform.position, Time.deltaTime * 3f);
            }
            if (deviceR.GetPress(SteamVR_Controller.ButtonMask.Trigger)) ////R
            {
                select_hit.transform.position = Vector3.MoveTowards(select_hit.transform.position, transform.position, -Time.deltaTime * 3f);
            }

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Grip)) ////L
            {
                select_hit.transform.Rotate(0, 3f, 0, Space.Self);
            }

            if (deviceR.GetPress(SteamVR_Controller.ButtonMask.Grip)) ////R
            {
                select_hit.transform.Rotate(0, -3f, 0, Space.Self);
            }
        }
        else
        {
            selected_or_not = false;
            for (int i = 0; i < complex_chair_01.transform.childCount; i++)
            {
                complex_chair_01.transform.GetChild(i).GetComponentInChildren<Renderer>().material = default_material;
            }
        }

        // change the length of line render complex chair 01

        if (complex_chair_01_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 100f) && deviceL.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            line_length = Vector3.Distance(select_hit.point, transform.position);
        }

        // refresh the length immediately complex chair 01

        line_render_end = transform.position + transform.forward * line_length;

        if (complex_chair_01_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 100f) && deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            select_hit.transform.position = line_render_end;
        }
        //
        //

        //
        // select complex chair 02

        if (complex_chair_02_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 5000f) && selected_or_not == false)
        {
            selected_or_not = true;
            for (int i = 0; i < complex_chair_02.transform.childCount; i++)
            {
                complex_chair_02.transform.GetChild(i).GetComponentInChildren<Renderer>().material = selected_highlight;
            }

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Trigger)) ////L
            {
                select_hit.transform.position = Vector3.MoveTowards(select_hit.transform.position, transform.position, Time.deltaTime * 3f);
            }
            if (deviceR.GetPress(SteamVR_Controller.ButtonMask.Trigger)) ////R
            {
                select_hit.transform.position = Vector3.MoveTowards(select_hit.transform.position, transform.position, -Time.deltaTime * 3f);
            }

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Grip)) ////L
            {
                select_hit.transform.Rotate(0, 3f, 0, Space.Self);
            }

            if (deviceR.GetPress(SteamVR_Controller.ButtonMask.Grip)) ////R
            {
                select_hit.transform.Rotate(0, -3f, 0, Space.Self);
            }
        }
        else
        {
            selected_or_not = false;
            for (int i = 0; i < complex_chair_02.transform.childCount; i++)
            {
                complex_chair_02.transform.GetChild(i).GetComponentInChildren<Renderer>().material = default_material;
            }
        }

        // change the length of line render complex chair 02

        if (complex_chair_02_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 100f) && deviceL.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            line_length = Vector3.Distance(select_hit.point, transform.position);
        }

        // refresh the length immediately complex chair 02

        line_render_end = transform.position + transform.forward * line_length;

        if (complex_chair_02_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 100f) && deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            select_hit.transform.position = line_render_end;
        }
        //
        //

        //
        // select complex chair 03

        if (complex_chair_03_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 5000f) && selected_or_not == false)
        {
            selected_or_not = true;
            for (int i = 0; i < complex_chair_03.transform.childCount; i++)
            {
                complex_chair_03.transform.GetChild(i).GetComponentInChildren<Renderer>().material = selected_highlight;
            }

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Trigger)) ////L
            {
                select_hit.transform.position = Vector3.MoveTowards(select_hit.transform.position, transform.position, Time.deltaTime * 3f);
            }
            if (deviceR.GetPress(SteamVR_Controller.ButtonMask.Trigger)) ////R
            {
                select_hit.transform.position = Vector3.MoveTowards(select_hit.transform.position, transform.position, -Time.deltaTime * 3f);
            }

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Grip)) ////L
            {
                select_hit.transform.Rotate(0, 3f, 0, Space.Self);
            }

            if (deviceR.GetPress(SteamVR_Controller.ButtonMask.Grip)) ////R
            {
                select_hit.transform.Rotate(0, -3f, 0, Space.Self);
            }
        }
        else
        {
            selected_or_not = false;
            for (int i = 0; i < complex_chair_03.transform.childCount; i++)
            {
                complex_chair_03.transform.GetChild(i).GetComponentInChildren<Renderer>().material = default_material;
            }
        }

        // change the length of line render complex chair 03

        if (complex_chair_03_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 100f) && deviceL.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            line_length = Vector3.Distance(select_hit.point, transform.position);
        }

        // refresh the length immediately complex chair 03

        line_render_end = transform.position + transform.forward * line_length;

        if (complex_chair_03_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 100f) && deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            select_hit.transform.position = line_render_end;
        }
        //
        //

        //
        // select complex chair 04

        if (complex_chair_04_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 5000f) && selected_or_not == false)
        {
            selected_or_not = true;
            for (int i = 0; i < complex_chair_04.transform.childCount; i++)
            {
                complex_chair_04.transform.GetChild(i).GetComponentInChildren<Renderer>().material = selected_highlight;
            }



            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Trigger)) ////L
            {
                select_hit.transform.position = Vector3.MoveTowards(select_hit.transform.position, transform.position, Time.deltaTime * 3f);
            }
            if (deviceR.GetPress(SteamVR_Controller.ButtonMask.Trigger)) ////R
            {
                select_hit.transform.position = Vector3.MoveTowards(select_hit.transform.position, transform.position, -Time.deltaTime * 3f);
            }

            if (deviceL.GetPress(SteamVR_Controller.ButtonMask.Grip)) ////L
            {
                select_hit.transform.Rotate(0, 3f, 0, Space.Self);
            }

            if (deviceR.GetPress(SteamVR_Controller.ButtonMask.Grip)) ////R
            {
                select_hit.transform.Rotate(0, -3f, 0, Space.Self);
            }
        }
        else
        {
            selected_or_not = false;
            for (int i = 0; i < complex_chair_04.transform.childCount; i++)
            {
                complex_chair_04.transform.GetChild(i).GetComponentInChildren<Renderer>().material = default_material;
            }
        }

        // change the length of line render complex chair 04

        if (complex_chair_04_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 100f) && deviceL.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            line_length = Vector3.Distance(select_hit.point, transform.position);
        }

        // refresh the length immediately complex chair 04

        line_render_end = transform.position + transform.forward * line_length;

        if (complex_chair_04_collider.GetComponent<Collider>().Raycast(select_ray, out select_hit, 100f) && deviceL.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            select_hit.transform.position = line_render_end;
        }
        //
        //

        // select picture wall

        for (int i = 0; i < picture_wall_parent.transform.childCount; i++)
        {
            if (furniture_pictures[i].GetComponent<Collider>().Raycast(select_ray, out select_hit, 5000f))
            {
                furniture_pictures[i].localScale = furniture_pictures_oriscales[i] * 1.2f;
            }
            else
            {
                furniture_pictures[i].localScale = furniture_pictures_oriscales[i] * 1.0f;
            }
        }

        }

    /* public void laser_control_furniture(GameObject furniture, GameObject furniture_collider)
    {

    } */ // void test

    }
