using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Mechanics
{
    /// <summary>
    /// The box that the player needs to get to the end of the level. 
    /// </summary>
    public class Box : MonoBehaviour
    {
        private bool facingUp = false;
        private Animator animator = null;

        [SerializeField]
        private string facingUpTrigger = "Facing Up Enter";
        [SerializeField]
        private string facingUpExitTrigger = "Facing Up Exit";

        [SerializeField]
        private GameObject debugCube = null;

        public bool FacingUp
        {
            get => facingUp;
            set
            {
                if (facingUp != value)
                {
                    //Trigger an animation if available.
                    if (animator != null)
                    {
                        string trigger = value ? facingUpTrigger : facingUpExitTrigger;
                        animator.SetTrigger(trigger);
                    }

                    //Turn on the debug cube
                    if (debugCube != null)
                        debugCube.gameObject.SetActive(value);
                }
                facingUp = value;
            }
        }

        private void Awake()
        {
            //Get Components
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            FacingUp = Vector3.Angle(transform.up, Vector3.up) < 80;
        }
    }
}
