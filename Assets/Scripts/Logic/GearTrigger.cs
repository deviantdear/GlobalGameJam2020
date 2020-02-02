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
        if (gear.gameObject.activeSelf)
            gear.Break();
        else
            gear.gameObject.SetActive(true);
    }

}
