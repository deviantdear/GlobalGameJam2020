using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : BaseProjectile
{
    Vector3 m_direction;
    bool m_fired;


    // Update is called once per frame
    void Update()
    {
        if (m_fired)
        {
            transform.position += m_direction * (speed * Time.deltaTime);
        }
    }

    public override void FireProjectile(GameObject launcher, GameObject target, int damage)
    {
        if (launcher && target)
        {

            //provides consistent speed
            m_direction = (target.transform.position - launcher.transform.position).normalized;
            m_fired = true;

        }
    }


    public override void FireProjectile(GameObject launcher, Vector3 direction, int damage)
    {
        m_direction = direction;
        m_fired = true;
    }
}
