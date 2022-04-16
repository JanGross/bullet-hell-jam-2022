using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;
    public float trailLength;
    public ParticleSystem trail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseTrail(float val)
    {
        //Decreate trail length (for pickups)
    }

    public void BulletHit()
    {
        //Increate trail length
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other == trail)
        {
            //Hit by trail
        }
    }
}
