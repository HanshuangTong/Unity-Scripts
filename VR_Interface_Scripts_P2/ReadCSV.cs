using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    public GameObject[] template;

    public int csvNum = 5;
    public float Scale = 1.2f;
    public int pointNum = 900;
    public Vector3[][] pointClouds;
    public string filepath = "";
    public int subsetNum = 100;

    public float pointScale = 3f;

    // Start is called before the first frame update
    void Awake()
    {
        pointClouds = new Vector3[csvNum][];
        for (int j = 0; j<csvNum; j++)
        {
            pointClouds[j] = new Vector3[pointNum];
            List<string> listX = new List<string>();
            List<string> listY = new List<string>();
            List<string> listZ = new List<string>();

            var csvPath = string.Concat(Application.dataPath, "\\CSV\\", filepath,"Stage_0",j.ToString(), ".csv");

            using (var reader = new StreamReader(csvPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listX.Add(values[0]);
                    listY.Add(values[1]);
                    listZ.Add(values[2]);
                }
            }

            for (int k = 0; k < pointNum / subsetNum; k++)
            {
                for (int i = 0; i < subsetNum; i++)
                {
                    Vector3 position = new Vector3(float.Parse(listX[i + k * subsetNum]), float.Parse(listY[i + k * subsetNum]), float.Parse(listZ[i + k * subsetNum]));
                    pointClouds[j][i+k*subsetNum] = position * Scale;
                    if (j == 0)
                    {
                        GameObject newObject;
                        newObject = Instantiate(template[k], gameObject.transform);
                        newObject.name = string.Concat(template[k].name,"_", i);
                        newObject.transform.position = pointClouds[j][i+k*subsetNum];
                        newObject.transform.localScale = new Vector3(1, 1, 1)*pointScale;
                        newObject.transform.GetChild(0). gameObject.layer = 9;
                        Texture2D texture;
                        Texture2D normalMap;
                        texture = Resources.Load(string.Concat("Images/",k,"/",i +1000)) as Texture2D;
                        normalMap = Resources.Load(string.Concat("Normals/", k, "/", i + 2000)) as Texture2D;
                        SetTexture(texture, normalMap, newObject.transform.GetChild(0). GetComponent<MeshRenderer>());
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    static int albedoPropertyId = Shader.PropertyToID("_MainTex");
    static int normalPropertyId = Shader.PropertyToID("_BumpMap");
    static MaterialPropertyBlock sharedPropertyBlock;
    public void SetTexture(Texture2D texture, Texture2D normalMap, MeshRenderer meshRenderer)
    {
        //avoid create new material each time setting the color
        if (sharedPropertyBlock == null)
        {
            sharedPropertyBlock = new MaterialPropertyBlock();
        }
        sharedPropertyBlock.SetTexture(albedoPropertyId, texture);
        sharedPropertyBlock.SetTexture(normalPropertyId, normalMap);
        meshRenderer.SetPropertyBlock(sharedPropertyBlock);
    }
}
