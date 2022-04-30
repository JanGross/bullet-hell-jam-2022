using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Player player;
    private ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleTrigger()
    {
        //BUGBUG: This is a hack to get the particles to work.
        List<ParticleSystem.Particle> insideList = new List<ParticleSystem.Particle>();
        int numInside = particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, insideList);
        if (numInside > 0)
        {
            player.isLit = true;
        }
        else
        {
            player.isLit = false;
        }
    }
}
