﻿using UnityEngine;

public class Gear : PoweredObject, IBreakable
{
    /// <summary>
    /// The animation id for the break trigger.
    /// </summary>
    private int breakTriggerId = -1;
    private Rotator rotator = null;

    [SerializeField]
    private Gear source = null;
    [SerializeField]
    private GameObject brokenGear = null;

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (source != null)
        {
            Gizmos.DrawLine(transform.position + Vector3.forward / 2, source.transform.position + Vector3.forward / 2);
        }
    }

    private void OnDestroy()
    {
        //Unhook events
        if (source != null)
        {
            source.onPowered -= OnSourcePowered;
        }
    }

    private void Start()
    {
        //Initialize gear with initial values - start rotating if powered
        Powered = powered;
    }

    private void OnEnable()
    {
        if (source != null)
        {
            //Make sure the gear is on/off based on source.
            Powered = source.Powered;
        }
    }

    protected override void OnPowered(bool value)
    {
        rotator.On = powered;
    }

    /// <summary>
    /// Invoked when the source gear (the one providing movement)
    /// turns on.
    /// </summary>
    void OnSourcePowered(bool powered)
    {
        Powered = powered;
    }

    /// <summary>
    /// Turns off the gear and spawns a broken gear in place of it. 
    /// </summary>
    public void Break()
    {
        if (gameObject.activeSelf)
        {
            //Turn off the gear
            gameObject.SetActive(false);

            if (brokenGear != null)
            {
                //Spawn a broken version
                Instantiate(brokenGear, transform.position, transform.rotation);
            }
        }
    }
}
