using UnityEngine;

public class ConveyorBelt : PoweredObject
{
    /// <summary>
    /// The object that controls movement.
    /// </summary>
    [SerializeField]
    private GameObject triggerObject = null;
    /// <summary>
    /// The final gear that powers the conveyor belt.
    /// </summary>
    [SerializeField]
    private Gear targetGear = null;

    // Start is called before the first frame update
    void Start()
    {
        //Hook up events
        targetGear.onPowered += OnTargetGearPowered;
    }

    private void OnDestroy()
    {
        //Unhook events
        targetGear.onPowered -= OnTargetGearPowered;
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
    /// Listen to the target gear and turn on/off.
    /// </summary>
    /// <param name="powered"></param>
    private void OnTargetGearPowered(bool powered)
    {
        Powered = powered;
    }
}
