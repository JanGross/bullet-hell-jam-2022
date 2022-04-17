using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public string name = "Default Pattern";
    public float duration;
    public bool notified = false;
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        OnPatternUpdate();
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            //find all particle systems in children and stop them
            foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
            {
                ps.Stop();
            }

            //find all particle systems in children and sum their particle counts
            int totalParticles = 0;
            foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
            {
                totalParticles += ps.particleCount;
            }

            if (totalParticles == 0)
            {
                Destroy(gameObject);
                return;
            }

            if (enemy && !notified)
            {
                enemy.OnPatternFinished();
                notified = true;
            }
        }
    }

    public virtual void OnPatternUpdate()
    {
        //override this
    }

    public void StartPattern(Enemy enemy)
    {
        //Start pattern
    }
    
}
