using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Input controls for the cannon
/// </summary>
public class RotationControl : MonoBehaviour
{
    /// <summary>
    /// When true, if input axis is 1, then the cannon is at 1.
    /// When false,if input axis is 1, the cannon will rotate up at speed * 1
    /// </summary>
    [SerializeField] bool absoluteAxis = true;

    /// <summary>
    /// Current rotation
    /// </summary>
    [SerializeField] float rotation = 0f;

    /// <summary>
    /// Current rotation
    /// </summary>
    public float Rotation { get => rotation; }

    /// <summary>
    /// Speed at which object is turned
    /// </summary>
    [SerializeField] float speed = 1f;

    /// <summary>
    /// Vertical input axis
    /// </summary>
    [SerializeField] string inputName = "Rotation Control";


    // Gather the input
    void Update()
    {
        float input = Input.GetAxis(inputName);
        if (absoluteAxis)
        {
            rotation = input;
            return;
        }
        rotation = input * speed * Time.deltaTime;
    }
}
