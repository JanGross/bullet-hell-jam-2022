using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowmotion : Pickup
{
    public float slowFactor = 0.5f;
    public float slowDuration = 5f;
    private bool isSlow = false;

    public override void OnPickup()
    {
        Debug.Log("Slowmotion");
        isSlow = true;
        Time.timeScale = Time.timeScale * slowFactor;

        //disable sprite renderer
        GetComponent<SpriteRenderer>().enabled = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isSlow)
        {
            slowDuration -= Time.deltaTime * (1 / slowFactor);
            if (slowDuration <= 0)
            {
                Time.timeScale =  Time.timeScale * (1 / slowFactor);
                Destroy(gameObject);

            }
        }
    }
}
