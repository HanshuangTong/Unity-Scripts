using UnityEngine;
using System.Collections;

public class attract : MetaBall
{
    //public float speed;

    private Container container;
    private Vector3 direction;
    public Rigidbody rb;
    public GameObject m1;
    private float thrust = 0.5f;
    private Vector3 v2;
    private int vertexindex;
    private Vector3[] v1;
    private Mesh m2;
    private SkinnedMeshRenderer z1;
    //private MeshCollider MC;
    //private MeshFilter MF;

    public override void Start()
    {
        //if (true) { Debug.Log("assssssssssssssssssd"); }
        base.Start();
        this.direction = Random.onUnitSphere;
        this.container = this.GetComponentInParent<Container>();
        rb = GetComponent<Rigidbody>();
        z1 = m1.GetComponent<SkinnedMeshRenderer>();
        //if (m1.GetComponent<SkinnedMeshRenderer>()) { Debug.Log("assssssssssssssssssd"); }
        
        //if (true) { Debug.Log("assssssssssssssssssd"); }
        //mesh = m1.GetComponent<MeshFilter>().mesh;
        
        
        //if (true) { Debug.Log("assssssssssssssssssd"); }
        vertexindex = Random.Range(0, v1.Length);
        //v1[vertexindex]+= Vector3.up;
    }

    public void Update()
    {
        this.updatePosition(Time.deltaTime);
    }

    public void updatePosition(float dt)
    {
        z1.BakeMesh(m2);
        v1 = m2.vertices;
        
        //float posX = this.transform.position.x, posY = this.transform.position.y, posZ = this.transform.position.z;
        //Vector3 containerPosition = this.container.transform.position;
        //Vector3 containerScale = this.container.transform.localScale;
        rb.AddForce((v1[vertexindex] - this.transform.position)*1.0f);
        //rb.AddForce(Vector3.up);

        //this.transform.position = new Vector3(posX, posY, posZ) + this.direction * speed * dt;
    }
}

