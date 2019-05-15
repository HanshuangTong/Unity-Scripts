using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;



public class Kmeans : MonoBehaviour
{
    List<GameObject> gcube = new List<GameObject>();
    List<PointGeo> pp = new List<PointGeo>();
    int num;
    int k = 3;
    int iter = 0;
    List<Vector3> means = new List<Vector3>();
    List<Vector3> premeans = new List<Vector3>();
    int runstate = 1;
    GameObject gtemp;
    int time = 0;
    public GameObject csvReader;
    ReadCSV csvData;


    public class PointGeo
    {
        public Vector3 p;
        public int type;
        public GameObject go;
        public PointGeo(Vector3 p1, int ty)
        {
            this.p = p1;
            this.type = ty;
            if (this.type == 0)
            {
                this.go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                this.go.transform.position = p1;
            }
            if (this.type == 1)
            {
                this.go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                this.go.transform.position = p1;
            }
            else
            {
                this.go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                this.go.transform.position = p1;
            }
        }

        public void build()
        {
            Destroy(this.go);
            if (this.type == 0)
            {
                this.go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            }
            if (this.type == 1)
            {
                this.go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            }
            else
            {
                this.go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            }
            this.go.transform.position = this.p;
        }
        public void render()
        {
            if (this.type == 0)
            {
                Renderer rend = this.go.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("_Color");
                rend.material.SetColor("_Color", Color.red);
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_SpecColor", Color.red);
            }
            if (this.type == 1)
            {
                Renderer rend = this.go.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("_Color");
                rend.material.SetColor("_Color", Color.blue);
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_SpecColor", Color.blue);
            }
            if (this.type == 2)
            {
                Renderer rend = this.go.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("_Color");
                rend.material.SetColor("_Color", Color.green);
                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_SpecColor", Color.green);
            }

        }
    }
    void Start()
    {
        //ReadCSVFile();
        csvData = csvReader.GetComponent<ReadCSV>();
        num = csvData.pointNum;
        for (int i = 0; i < num; i++)
        {        
            PointGeo p1 = new PointGeo(csvData.pointClouds[0][i], 0);
            p1.render();
            pp.Add(p1);
        }
        InitMeans(pp, k, means);
        InitpreMeans(pp, k, premeans);
    }
    void Update()
    {
        if (runstate == 1 && time % 20 == 19)
        {
            Classify(pp, k, means);
            int conv = 0;
            for (int j = 0; j < k; j++)
            {
                means[j] = CalcMeans(pp, j);
                if (Compare(means[j], premeans[j]))
                    conv++;
                else
                    premeans[j] = means[j];
            }
            for (int i = 0; i < num; i++)
            {
                pp[i].build();
                pp[i].render();
                Debug.Log(iter);
                //pp[i].render();
            }
            if (conv == k)
            {
                runstate = 0;
                Debug.Log(iter);
            }
            iter++;
        }
        time++;
    }

    // Update is called once per frame

    float StrToFloat(object FloatString)
    {
        float result;
        if (FloatString != null)
        {
            if (float.TryParse(FloatString.ToString(), out result))
                return result;
            else
            {
                return (float)0.00;
            }
        }
        else
        {
            return (float)0.00;
        }
    }
    private void InitMeans(List<PointGeo> pg, int k, List<Vector3> m)
    {
        System.Random random = new System.Random();
        for (int i = 0; i < k; i++)
        {
            int r = random.Next(pg.Count);
            m.Add(new Vector3(pg[r].p.x, pg[r].p.y, pg[r].p.z));
        }
    }
    private void InitpreMeans(List<PointGeo> pg, int k, List<Vector3> m)
    {
        System.Random random = new System.Random();
        for (int i = 0; i < k; i++)
        {
            int r = random.Next(pg.Count);
            m.Add(new Vector3(0, 0, 0));
        }
    }
    private bool Compare(Vector3 a, Vector3 b)
    {
        if (((int)(a.x * 100) == (int)(b.x * 100)) && ((int)(a.y * 100) == (int)(b.y * 100)) && ((int)(a.z * 100) == (int)(b.z * 100)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Classify(List<PointGeo> pg, int k, List<Vector3> m)
    {
        for (int i = 0; i < pg.Count; i++)
        {
            double minDist = double.MaxValue;
            for (int j = 0; j < k; j++)
            {
                double dist = distance(pg[i].p, m[j]);
                if (dist < minDist)
                {
                    minDist = dist;
                    pg[i].type = j;
                }
            }
            //Console.WriteLine("{0}归入类{1}", points[i], pointAssigns[i]);
        }
    }
    private double distance(Vector3 p1, Vector3 p2)
    {
        return Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y) + (p1.z - p2.z) * (p1.z - p2.z));
    }
    private Vector3 CalcMeans(List<PointGeo> pg, int j)
    {
        Vector3 mean = new Vector3();
        int n = 0;
        for (int i = 0; i < pg.Count; i++)
        {
            if (pg[i].type == j)
            {
                mean.x += pg[i].p.x;
                mean.y += pg[i].p.y;
                mean.z += pg[i].p.z;
                n++;
            }
        }
        mean.x /= (float)n;
        mean.y /= (float)n;
        mean.z /= (float)n;
        return mean;
    }

}
