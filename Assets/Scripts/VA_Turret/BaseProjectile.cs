using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    public float speed = 5f;

    public abstract void FireProjectile(GameObject launcher, GameObject target, int damage);
    public abstract void FireProjectile(GameObject launcher, Vector3 direction, int damage);

    internal void OnCollisionEnter(Collision collision)
    {
        GetComponent<IBreakable>()?.Break();
    }

}
