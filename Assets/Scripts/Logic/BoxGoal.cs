using System;
using UnityEngine;

namespace Level.Mechanics
{
    public class BoxGoal : MonoBehaviour
    {
        public Action onBoxEntered = null;

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
