using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDisplay : MonoBehaviour
{
    private GameObject cube;
    public Transform Parent_GameObject;
    //public GameObject template;
    private int cubeCount;
    public int width = 50;
    public int height = 50;
    public int layers = 1;

    public GameObject cubetocopy;

    //private bool spriterun = false;
    //private bool pre_spriterun = false;
    public GameObject[] cubes;


    // Start is called before the first frame update
    void Awake()
    {
        cubeCount = (int)(width * height * layers);
        cubes = new GameObject[cubeCount];
    }
    void Start()
    {

    }
    void Update()
    {
        //spriterun = GameObject.Find("AnimateControl").GetComponent<OculusControl>().sprite_run;
        //if (spriterun && pre_spriterun != spriterun)
        //{
   
            //Parent_GameObject.gameObject.SetActive(true);
            cubes = CreateCubes(cubeCount);
        //}
        //if (!spriterun && pre_spriterun != spriterun)
        //{
            //Parent_GameObject.gameObject.SetActive(false);
        //}
       // pre_spriterun = spriterun;
    }

    public GameObject[] CreateCubes(int count)
    {
        /*
        var cube = new GameObject[count];
        var cubetocopy = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var renderer = cubetocopy.GetComponent<MeshRenderer>();
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        renderer.receiveShadows = false;
        var collider = cubetocopy.GetComponent<Collider>();
        collider.enabled = false;
        */
        for(int i = 0; i < count; i++)
        {
            GameObject cube1 = GameObject.Instantiate(cubetocopy);
            cube1.transform.SetParent(Parent_GameObject);
            int x = i / (width * layers);
            cube1.transform.position = new Vector3(x, (i - x * height * layers) / layers,0 );
            cubes[i] = cube1;
        }
        GameObject.Destroy(cubetocopy);
        return cubes;
    }

}
