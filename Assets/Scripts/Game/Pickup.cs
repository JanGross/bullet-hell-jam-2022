using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public virtual void OnPickup()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pickup");
        if (other.gameObject.tag == "Player")
        {
            OnPickup();
            Destroy(gameObject);
        }
    }
}
