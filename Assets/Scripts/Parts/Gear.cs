using System;
using UnityEngine;

public class Gear : MonoBehaviour
{
    private Rotator rotator = null;

    [SerializeField]
    private Gear source = null;
    [SerializeField]
    private bool powered = false;

    public Action<bool> onPowered = null;

    /// <summary>
    /// Whether or not the gear is turned on. 
    /// </summary>
    private bool Powered
    {
        get { return powered; }
        set
        {
            powered = value;
            rotator.On = value;
            onPowered?.Invoke(powered);
        }
    }

    private void OnValidate()
    {
        rotator = GetComponent<Rotator>();
        Powered = powered;
    }

    // Start is called before the first frame update
    void Awake()
    {
        //Get Components
        rotator = GetComponent<Rotator>();

        //Hook up events
        if (source != null)
        {
            source.onPowered += OnSourcePowered;
        }
    }

    private void Start()
    {
        //Initialize gear with initial values - start rotating if powered
        Powered = powered;
    }

    /// <summary>
    /// Invoked when the source gear (the one providing movement)
    /// turns on.
    /// </summary>
    void OnSourcePowered(bool powered)
    {
        Powered = powered;
    }

}
