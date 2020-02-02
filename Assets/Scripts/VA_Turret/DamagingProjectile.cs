using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingProjectile : NormalProjectile
{
    [SerializeField] float destroyOnCollision = 2f;

    internal void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<IBreakable>()?.Break();
        Destroy(gameObject, destroyOnCollision);
    }
}
