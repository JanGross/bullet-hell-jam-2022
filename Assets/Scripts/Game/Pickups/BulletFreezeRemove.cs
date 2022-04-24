using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFreezeRemove : Pickup 
{
    public ParticleSystem freezeParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnPickup()
    {
        //hide renderer
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Debug.Log("Start thingy");
        //find all particles in the scene and freeze them
        ParticleSystem[] particleSystems = FindObjectsOfType<ParticleSystem>();

        foreach (ParticleSystem particleSystem in particleSystems)
        {
            //if root gameobject has no pattern component it's not a pattern
            GameObject root = particleSystem.transform.root.gameObject;
            if (!root.GetComponent<Pattern>())
            {
                continue;
            }
           
            int particleCount = particleSystem.particleCount;
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleCount];
            particleSystem.GetParticles(particles);

            for (int i = 0; i < particleCount; i++)
            {
                particles[i].velocity = Vector3.zero;
            }
            
            particleSystem.SetParticles(particles, particleCount);
            StartCoroutine(RemoveParticle(particles, particleCount, particleSystem));
        }

        

    }

    //coroutine that takes a collection of particles and removes one at a time
    IEnumerator RemoveParticle(ParticleSystem.Particle[] particles, int particleCount, ParticleSystem particleSystem)
    {
        //Remove all particles over a span of .5 seconds
        for (int i = 0; i < particleCount; i++)
        {
            particles[i].remainingLifetime = 0.0f;
            particleSystem.SetParticles(particles, particleCount);
            //instantiate freeze particles at the position of the particle
            Instantiate(freezeParticles, particles[i].position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f/particleCount);
        }
    }

}
