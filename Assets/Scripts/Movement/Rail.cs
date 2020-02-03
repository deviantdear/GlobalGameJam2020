using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rail script allows the car to travel back and fourth
/// </summary>
public class Rail : MonoBehaviour
{
    public List<RailSection> sections = new List<RailSection>();

    [System.Serializable]
    public struct RailSection
    {
        public Transform left;
        public Transform right;
    }
}
