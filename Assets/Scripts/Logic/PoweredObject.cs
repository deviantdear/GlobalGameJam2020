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
            //Don't turn on if the power object is inactive.
            if (!gameObject.activeSelf && value)
                return;

            powered = value;
            OnPowered(powered);
            onPowered?.Invoke(powered);
        }
    }

    protected virtual void OnPowered(bool value)
    {
    }

    public virtual void OnDisable()
    {
        //Turn off the power
        Powered = false;
    }
}
