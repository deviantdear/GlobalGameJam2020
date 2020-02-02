using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour, IInstallable
{
    [SerializeField] Gear gear;
    [SerializeField] Transform container;
    public void Install(Gear newGear)
    {
        if (newGear)
        {
            Destroy(gear);
            gear = Instantiate(newGear, container);
        }
        gear.gameObject.SetActive(true);
    }
}
