using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NormalProjectile : BaseProjectile
{
    Vector3 m_direction;
    bool m_fired;
    Rigidbody m_rigidbody;

    public void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void FireProjectile(GameObject launcher, GameObject target, int damage)
    {
        if (launcher && target)
        {

            //provides consistent speed
            m_direction = (target.transform.position - launcher.transform.position).normalized;
            Travel();
        }
    }


    public override void FireProjectile(GameObject launcher, Vector3 direction, int damage)
    {
        m_direction = direction;
        Travel();
    }

    void Travel()
    {
        Vector3 force = m_direction * speed;
        Debug.Log($"Launching cannon with {force}");
        m_rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
