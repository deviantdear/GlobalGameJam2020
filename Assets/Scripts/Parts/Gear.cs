using UnityEngine;

public class Gear : PoweredObject, IBreakable
{
    private bool initialized = false;
    private Rotator rotator = null;

    [SerializeField]
    private float radius = 0.5f;
    [SerializeField]
    private Gear source = null;
    [SerializeField]
    private GameObject brokenGear = null;

    public float Radius => radius;
    public float Speed => rotator.Speed;

    private void OnValidate()
    {
        rotator = GetComponentInChildren<Rotator>(true);
        Powered = powered;
    }

    // Start is called before the first frame update
    void Awake()
    {
        //Get Components
        rotator = GetComponentInChildren<Rotator>(true);

        //Hook up events
        if (source != null)
        {
            source.onPowered += OnSourcePowered;
        }

        initialized = true;
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

        //Update speed based on source.
        if (source != null && source.initialized)
        {
            float multiplier = source.radius / radius;
            rotator.Speed = -source.Speed * multiplier;
        }
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
