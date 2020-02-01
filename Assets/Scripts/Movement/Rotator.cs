using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private bool on = false;
    [SerializeField]
    private float rotationSpeed = 10;

    public bool On { get => on; set => on = value; }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
