using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTrail : Pickup
{
    private Player player;
    public float noTrailDuration = 5f;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public override void OnPickup()
    {
        player.trail.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            noTrailDuration -= Time.deltaTime;
            if (noTrailDuration <= 0)
            {
                player.trail.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
