using System;
using UnityEngine;
using UnityEngine.Events;

namespace Level.Mechanics
{
    public class BoxGoal : MonoBehaviour
    {
        public UnityEvent onBoxEntered = new UnityEvent();

        private void OnTriggerEnter(Collider other)
        {
            Box box = other.GetComponent<Box>();
            if (box != null)
            {
                Debug.Log("Box has entered!");
                onBoxEntered?.Invoke();
            }
        }
    }
}
