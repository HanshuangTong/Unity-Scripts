using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Main_Control : MonoBehaviour
{
    // Start is called before the first frame update
    public int TraySelected_Index = 0;
    public int Teleport_Position  = 0;
    public int ObjectSelected = -1;
    public int Obj_Select_Confirmed = 0;
    public GameObject Alembic;
    public bool ScreenRun = false;
    public GameObject Instruction;
    public bool ScreenImageIndex=false;
    public int SelectedImageIndex=0;
    public GameObject Screen;


    void Start()
    {
        Instruction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RestartInspection();
        TraySelectInspection();
        TeleportInspection();
        ScreenInpection();
        InstructionInpection();
        GlobalStop();
    }

    void GlobalStop()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            GameObject.Find("PointCloud").GetComponent<PointTransform>().run = !GameObject.Find("PointCloud").GetComponent<PointTransform>().run;
            GameObject.Find("Points_alembic").GetComponent<PlayableDirector>().enabled = !GameObject.Find("Points_alembic").GetComponent<PlayableDirector>().enabled;
        }
    }
    void RestartInspection()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Alembic.SetActive(false);
            Alembic.SetActive(true);
            GameObject.Find("PointCloud").GetComponent<PointTransform>().present = 0;
        }
    }
    void TraySelectInspection()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            TraySelected_Index = (TraySelected_Index + 1) % 10;
        }
    }
    void TeleportInspection()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            GameObject.Find("PointCloud").GetComponent<ProjectSpheres>().state = true;
            Teleport_Position = TraySelected_Index;
            GameObject.Find("Points_alembic").SetActive(false);
            GameObject.Find("Map").GetComponent<MapSelectColor>().state = true;
        }
    }
    void ScreenInpection()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            ScreenRun = !ScreenRun;
            Screen.SetActive(ScreenRun);
            ScreenImageIndex = !ScreenImageIndex;
        }
    }
    void InstructionInpection()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger)>0)
        {
            Instruction.SetActive(true);
        }
        else
        {
            Instruction.SetActive(false);
        }
    }

}
