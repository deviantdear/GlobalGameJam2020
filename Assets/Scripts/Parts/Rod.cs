using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour, IInstallable
{
    [SerializeField] Gear gear;
    [SerializeField] Transform container;
    public bool Install(Gear newGear)
    {

        if (CompareGears(gear, newGear))
        {
            gear.gameObject.SetActive(true);
            return true;
        }
        return false;
    }

    bool CompareGears(Gear left, Gear right)
    {
        bool ret = left.Radius - right.Radius < .1 && left.Radius - right.Radius > -.1;
        Debug.Log($"Size L:{left.Radius} R:{right.Radius} {ret}");
        return ret;
    }
}
