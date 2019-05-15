using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
    public GameObject particles;
    public GameObject environmentParticles;
    int particlesCount;//previous count
    int currentCount;
    List<GameObject> particle;
    public float strength = 5.0f;
    public int abondonRate = 3;
    public float abondonSpeedMax = 5f;
    public float abondonSpeedMin = 3f;

    //test key setting
    public string keyStart = "s";
    public string keyStop = "d";
    public string keyAbondon = "f";

    
    bool state = true;
    public float escapeSpeed = 0.1f;

    //Bake mesh
    SkinnedMeshRenderer meshRenderer;
    MeshCollider meshcollider;
    MeshFilter meshfilter;

    Mesh bakeMesh()
    {
        Mesh mesh = new Mesh();
        meshRenderer.BakeMesh(mesh);
        return mesh;
    }

    //mesh
    Mesh mesh;
    int verticeNum;
    List<int> verticeOrder;
    Vector3[] vertices;
    Vector3[] previousVertices;
    Vector3[] movement;
    float[] movementSpeed;

    //create a shuffled vertice order list
    void Shuffle(int num, List<int> list)
    {
        for(int i = num; i > 0; i--)
        {
            int k = Random.Range(0, i);
            int value = list[i-1];
            list[i-1] = list[k];
            list[k] = value;
        }
    }

    //shift vertice order list
    List<int> Shift(int index, int num, int length, List<int> list)
    {
        List<int> result = list.GetRange(0, index);
        result.AddRange(list.GetRange(index + num, length - num - index));
        result.AddRange(list.GetRange(index, num));
        return result;
    }


    //Abondon particle
    void Abondon(int i)
    {
        GameObject abondon = particle[i];
        abondon.GetComponent<MeshCollider>().enabled = true;
        Rigidbody rigidbody = abondon.GetComponent<Rigidbody>();
        rigidbody.WakeUp();
        rigidbody.detectCollisions = true;
        rigidbody.useGravity = true;
        //Vector3 direction = abondon.transform.position - transform.position;
        //rigidbody.velocity = direction.normalized * Random.Range(abondonSpeedMin,abondonSpeedMax);
        rigidbody.velocity = movement[i] / Time.deltaTime * 3;
        abondon.transform.SetParent(environmentParticles.transform);
    }

    //Attract protocal
    void Attract(int i)
    {
        
        GameObject attract = particle[i];
        attract.GetComponent<MeshCollider>().enabled = false;
        attract.GetComponent<Rigidbody>().Sleep();
        attract.transform.position = vertices[verticeOrder[i]] + transform.position;
        Vector3 direction = vertices[verticeOrder[i]] + transform.position - particle[i].transform.position;
        

    }

    // Use this for initialization
    void Start () {
        //partcle list
        particle = new List<GameObject>();
        particlesCount = particles.transform.childCount;
        /*for (int i = 0; i < particlesCount;i++){
            particle.Add(particles.transform.GetChild(i).gameObject);
        }*/

        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        meshcollider = GetComponent<MeshCollider>();
        meshfilter = GetComponent<MeshFilter>();

        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticeNum = vertices.Length;
        movement = new Vector3[verticeNum];
        movementSpeed = new float[verticeNum];

        //shuffledVertices = new Vector3[verticeNum];
        verticeOrder = new List<int>();
        for (int i = 0; i < verticeNum; i++)
        {
            verticeOrder.Add(i);
        }
        Shuffle(verticeNum, verticeOrder);

    }
	
	// Update is called once per frame
	void Update () {
        //update mesh
        mesh = bakeMesh();
        meshcollider.sharedMesh = mesh;
        meshfilter.mesh = mesh;

        //update mesh vertices
        previousVertices = vertices;
        vertices = mesh.vertices;
        for(int i = 0; i<verticeNum; i++)
        {
            movement[i] = vertices[i] - previousVertices[i];
            movementSpeed[i] = movement[i].magnitude;
        }
        //Debug.Log(movementSpeed[0]);

        
        //update particle list
        currentCount = particles.transform.childCount;
        if (particlesCount != currentCount)
        {
            particle.Clear();
            for (int i = 0; i < currentCount;i++){
                particle.Add(particles.transform.GetChild(i).gameObject);
            }
            particlesCount = currentCount;
        }

        if (Input.GetKeyDown(keyStart))
        {
            state = true;
        }
        if (Input.GetKeyDown(keyStop)) //|| OVRInput.GetDown(OVRInput.Button.One)
        {
            state = false;
        }
        if (Input.GetKeyUp(keyStop))//|| OVRInput.GetDown(OVRInput.Button.One)
        {
            state = true;
        }

        //whether stay on the avatar
        if (state){
            for (int i = 0; i<particlesCount;i++)
            {
                particle[i].GetComponent<Rigidbody>().detectCollisions = false;
                particle[i].transform.position = vertices[verticeOrder[i]] + transform.position;
                /*Vector3 direction = vertices[verticeOrder[i]] + transform.position - particle[i].transform.position;
                particle[i].GetComponent<Rigidbody>().AddForce(direction.normalized * strength);*/
            }
        }
        if (state == false)
        {
            for (int i = 0; i < particlesCount; i++)
            {
                Abondon(i);
            }
        }

        //throw away particles
        if (Input.GetKey(keyAbondon))
        {
            if (currentCount >= 150)
            {
                for (int i = 0; i < abondonRate; i++)
                {
                    Abondon(i);
                }
                verticeOrder = Shift(0,abondonRate, verticeNum, verticeOrder);
            }
        }

        //throw away particles
        for (int i = 0; i<particlesCount; i++)
        {
            if (movementSpeed[verticeOrder[i]] > escapeSpeed)
            {
                Abondon(i);
                verticeOrder = Shift(i, 1, verticeNum, verticeOrder);
            }
        }
        
        mesh.Clear();
	}
}
