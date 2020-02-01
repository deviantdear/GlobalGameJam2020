using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private bool on = false;
    [SerializeField]
    private float rotationSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
