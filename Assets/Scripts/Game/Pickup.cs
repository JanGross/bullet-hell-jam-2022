using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    protected bool pickedUp = false;
    public virtual void OnPickup()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pickup");
        if (other.gameObject.tag == "Player")
        {
            pickedUp = true;
            OnPickup();
        }
    }

    //Draw text gizmo in editor to show class name
    void OnDrawGizmos()
    {
        //get curren class name
        string className = this.GetType().ToString();
        GUI.color = Color.blue;

        UnityEditor.Handles.Label(transform.position, className);
    }
}
