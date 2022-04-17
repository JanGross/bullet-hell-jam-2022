using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : Pickup
{
    public Player player;

    [SerializeField]
    private float amount;
    
    public override void OnPickup()
    {
        // we have to stop the particle system before making changes
        ParticleSystem system = player.trail.GetComponent<ParticleSystem>();
        system.Stop();

        system.startLifetime *= amount;

        system.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
}
