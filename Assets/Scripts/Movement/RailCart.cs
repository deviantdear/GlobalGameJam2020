using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Travels along a rail system bouncing between nodes.
/// As level progresses, the available nodes increases
/// </summary>
public class RailCart : MonoBehaviour
{
    [SerializeField] Rail currentRail;
    [SerializeField] Camera currentCamera;
    [SerializeField] float speed = 1f;
    [SerializeField] int currentSection = 0;

    private float sectionStartTime = 0f;
    private float sectionLength = 0f;
    private float direction = 1f;

    bool leftToRight = true;
    Vector3 left;
    Vector3 right;

    public void TravelToSection(int sectionIndex)
    {

        leftToRight = true;
        // Set the index
        currentSection = sectionIndex;

        Rail.RailSection section = currentRail.sections[currentSection];
        left = section.left.position;
        right = section.right.position;
        sectionLength = Vector3.Distance(section.left.position, section.right.position);
        sectionStartTime = Time.time;

        // Teleport to the left side of the frame
        transform.position = section.left.position;
        currentCamera.transform.position = section.cameraAnchor.position;
        currentCamera.transform.rotation = section.cameraAnchor.rotation;
    }

    void ReverseDirection()
    {
        leftToRight = !leftToRight;
        if (leftToRight)
        {
            left = currentRail.sections[currentSection].left.position;
            right = currentRail.sections[currentSection].right.position;
        }
        else
        {
            left = currentRail.sections[currentSection].right.position;
            right = currentRail.sections[currentSection].left.position;
        }
        sectionStartTime = Time.time;
    }

    void Start()
    {
        // Spawn at the first section and start traveling
        TravelToSection(0);
    }

    // Move to the target end position.
    void Update()
    {

        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - sectionStartTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / sectionLength;

        if (fractionOfJourney >= 0.9 && direction > 0)
        {
            ReverseDirection();
        } 
        else if(fractionOfJourney <= 0.1 && direction < 0)
        {
            ReverseDirection();
        }

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(left, right, fractionOfJourney);
    }
}
