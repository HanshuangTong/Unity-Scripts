using System.Collections;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class particleAttractorMove_Robot : MonoBehaviour {
	ParticleSystem ps;
	ParticleSystem.Particle[] m_Particles;
	public Transform targetR4;
    public Transform targetR3;
    public Transform targetR2;
    public Transform targetR1;
    public Transform targetM;
    public Transform targetL1;
    public Transform targetL2;
    public Transform targetL3;
    public Transform targetL4;
    public float speed = 5f;
	int numParticlesAlive;
	void Start () {
		ps = GetComponent<ParticleSystem>();
		if (!GetComponent<Transform>()){
			GetComponent<Transform>();
		}
	}
	void Update () {
		m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
		numParticlesAlive = ps.GetParticles(m_Particles);
		float step = speed * Time.deltaTime;
		for (int i = 0; i < numParticlesAlive; i++)
        if (Input.GetKey(KeyCode.Alpha1)) {
			m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, targetL4.position, step);
		}
		ps.SetParticles(m_Particles, numParticlesAlive);

        m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);
        for (int i = 0; i < numParticlesAlive; i++)
            if (Input.GetKey(KeyCode.Alpha2))
            {
                m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, targetL3.position, step);
            }
        ps.SetParticles(m_Particles, numParticlesAlive);

        m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);
        for (int i = 0; i < numParticlesAlive; i++)
            if (Input.GetKey(KeyCode.Alpha3))
            {
                m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, targetL2.position, step);
            }
        ps.SetParticles(m_Particles, numParticlesAlive);

        m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);
        for (int i = 0; i < numParticlesAlive; i++)
            if (Input.GetKey(KeyCode.Alpha4))
            {
                m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, targetL1.position, step);
            }
        ps.SetParticles(m_Particles, numParticlesAlive);

        m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);
        for (int i = 0; i < numParticlesAlive; i++)
            if (Input.GetKey(KeyCode.Alpha5))
            {
                m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, targetM.position, step);
            }
        ps.SetParticles(m_Particles, numParticlesAlive);

        m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);
        for (int i = 0; i < numParticlesAlive; i++)
            if (Input.GetKey(KeyCode.Alpha6))
            {
                m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, targetR1.position, step);
            }
        ps.SetParticles(m_Particles, numParticlesAlive);

        m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);
        for (int i = 0; i < numParticlesAlive; i++)
            if (Input.GetKey(KeyCode.Alpha7))
            {
                m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, targetR2.position, step);
            }
        ps.SetParticles(m_Particles, numParticlesAlive);

        m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);
        for (int i = 0; i < numParticlesAlive; i++)
            if (Input.GetKey(KeyCode.Alpha8))
            {
                m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, targetR3.position, step);
            }
        ps.SetParticles(m_Particles, numParticlesAlive);

        m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);
        for (int i = 0; i < numParticlesAlive; i++)
            if (Input.GetKey(KeyCode.Alpha9))
            {
                m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, targetR4.position, step);
            }
        ps.SetParticles(m_Particles, numParticlesAlive);
    }

}
