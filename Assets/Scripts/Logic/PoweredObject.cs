using System;
using UnityEngine;

[Serializable]
public class PoweredObject : MonoBehaviour
{
    [SerializeField]
    protected bool powered = false;

    public Action<bool> onPowered = null;

    /// <summary>
    /// Whether or not the gear is turned on. 
    /// </summary>
    public bool Powered
    {
        get { return powered; }
        set
        {
            powered = value;
            onPowered?.Invoke(powered);
            OnPowered(powered);
        }
    }

    protected virtual void OnPowered(bool value)
    {
    }
}
