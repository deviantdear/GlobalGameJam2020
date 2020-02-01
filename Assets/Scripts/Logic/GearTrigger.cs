using UnityEngine;

public class GearTrigger : MonoBehaviour
{

    [SerializeField]
    private Gear gear = null;

    /// <summary>
    /// Temporary until we add the cannon / projectile logic.
    /// </summary>
    private void OnMouseDown()
    {
        //Toggle the state of the gear.
        gear.gameObject.SetActive(!gear.gameObject.activeSelf);
    }

}
