using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    public float delay = 1f;
    float onTime = 0f;

    void OnEnable()
    {
        onTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (onTime + delay < Time.time)
            gameObject.SetActive(false);
    }
}
