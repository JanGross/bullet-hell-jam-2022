using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class RotatingPattern : Pattern
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnPatternUpdate()
    {
     //   transform.Rotate(Vector3.up, speed * Time.deltaTime);

        //find all particle systems in children
        ParticleSystem[] systems = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem system in systems)
        {
            ShapeModule shape = system.shape;
            shape.rotation = new Vector3(0, shape.rotation.y + speed * Time.deltaTime, 0);

        }
    }
}
