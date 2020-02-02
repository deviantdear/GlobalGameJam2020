using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearProjectile : NormalProjectile
{
    [SerializeField] float destroyOnCollision = 2f;
    [SerializeField] Gear gearPrefab;

    internal void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<IInstallable>()?.Install(gearPrefab);
        Destroy(gameObject, destroyOnCollision);
    }
}
