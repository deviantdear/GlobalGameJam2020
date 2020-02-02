using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour, IInstallable
{
    [SerializeField] Gear gear;
    public void Install()
    {
        gear.gameObject.SetActive(true);
    }
}
