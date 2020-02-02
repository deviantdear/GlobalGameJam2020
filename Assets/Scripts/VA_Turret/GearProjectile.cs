using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearProjectile : NormalProjectile
{
    [SerializeField] float destroyOnCollision = 2f;
    [SerializeField] Gear gearPrefab;

    internal void OnCollisionEnter(Collision collision)
    {
        IInstallable rod = collision.gameObject.GetComponent<IInstallable>();
        if (rod != null && rod.Install(gearPrefab))
        {
            Destroy(gameObject);
        } else
            Destroy(gameObject, destroyOnCollision);
    }
}
