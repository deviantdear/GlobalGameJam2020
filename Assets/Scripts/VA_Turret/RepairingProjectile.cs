using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairingProjectile : NormalProjectile
{
    [SerializeField] float destroyOnCollision = 2f;
    [SerializeField] float repairAmount = 1f;

    internal void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<IRepairable>()?.Repair(repairAmount);
        Destroy(gameObject, destroyOnCollision);
    }
}
