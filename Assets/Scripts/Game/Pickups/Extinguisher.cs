using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : Pickup
{
    public ParticleSystem extinguishEffect;
    public Player player;

    [SerializeField]
    private float amount;
    
    public override void OnPickup()
    {
        ParticleSystem particleSystem = player.trail.GetComponent<ParticleSystem>();
        
        int particleCount = particleSystem.particleCount;
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleCount];
        particleSystem.GetParticles(particles);
        

        for (int i = 0; i < particleCount; i++)
        {
            if (particles[i].remainingLifetime < particles[i].startLifetime * 0.95f)
            {
                particles[i].remainingLifetime = 0.0f;
            }
            //instantiate freeze particles at the position of the particle
        }
        particleSystem.SetParticles(particles, particleCount);
        
        StartCoroutine(SpawnEffectsCoroutine(particles, particleCount, particleSystem));
    }
    
    IEnumerator SpawnEffectsCoroutine(ParticleSystem.Particle[] particles, int count, ParticleSystem system)
    {

        for (int i = 0; i < count; i+=20)
        {
            if (particles[i].remainingLifetime < particles[i].startLifetime * 0.95f)
            {
                //instantiate freeze particles at the position of the particle
                Instantiate(extinguishEffect, particles[i].position, Quaternion.identity);
                yield return null;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
}
