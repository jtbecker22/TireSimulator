using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack_Animation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    [Header("Scrub Control")]
    [Range(0f, 1f)]
    public float scrub = 0f; // Scrub value shown in the inspector

    public string animationStateName = "JackRaise"; // Name of the animation state

    void Update()
    {
        if (animator != null)
        {
            animator.Play(animationStateName, 0, scrub);
            //animator.speed = 0f; // Pause the animator so it doesn't play automatically
        }
    }
}
