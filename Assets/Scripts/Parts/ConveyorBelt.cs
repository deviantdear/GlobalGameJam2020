using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : PoweredObject
{
    /// <summary>
    /// The object that controls movement.
    /// </summary>
    [SerializeField]
    private GameObject triggerObject = null;
    /// <summary>
    /// The final gear(s) that powers the conveyor belt.
    /// </summary>
    [SerializeField]
    private List<Gear> targetGears = null;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < targetGears.Count; i++)
        {
            //Hook up events
            targetGears[i].onPowered += OnTargetGearPowered;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < targetGears.Count; i++)
        {
            //Hook up events
            targetGears[i].onPowered -= OnTargetGearPowered;
        }
    }

    /// <summary>
    /// When the conveyor belt is powered, turn on the trigger that moves objects.
    /// </summary>
    /// <param name="powered"></param>
    protected override void OnPowered(bool powered)
    {
        triggerObject.SetActive(powered);
    }

    /// <summary>
    /// Listen to the target gears and turn on/off.
    /// </summary>
    /// <param name="powered"></param>
    private void OnTargetGearPowered(bool powered)
    {
        bool allPowered = true;
        for (int i = 0; i < targetGears.Count; i++)
        {
            //If one gear is powered off then stop checking
            if (!targetGears[i].Powered)
            {
                allPowered = false;
                break;
            }
        }

        Powered = allPowered;
    }
}
