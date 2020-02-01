using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This object manages a trigger that will move rigidbodies that fall into it. 
/// </summary>
public class MovementTrigger : MonoBehaviour
{

    [SerializeField]
    private Vector3 forceDirection = Vector3.right;

    private void OnTriggerStay(Collider other)
    {
        //Move any rigidbody that falls into the trigger.
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(forceDirection);
        }
    }

}
