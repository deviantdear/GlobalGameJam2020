using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour, IInstallable
{
    [SerializeField] Gear gear;
    [SerializeField] Transform container;
    public bool Install(Gear newGear)
    {
        if (newGear.Radius == gear.Radius)
        {
            gear.gameObject.SetActive(true);
            return true;
        }
        return false
    }
}
