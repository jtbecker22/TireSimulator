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

    [Header("Rotation Mapping")]
    private float minZ = 0f;   // Z rotation (degrees) for jack fully lowered
    private float maxZ = 60f;  // Z rotation (degrees) for jack fully raised

    public Transform rotationSource; // Assign the GameObject whose Z rotation controls the jack

    [Header("Audio")]
    public AudioSource audioSource; // Assign in Inspector

    void Update()
    {
        // Use this GameObject if no source is assigned
        Transform source = rotationSource != null ? rotationSource : transform;

        // Get local Z rotation (0-360)
        float zRotation = source.localEulerAngles.z;

        // Optionally handle wrap-around if your range crosses 0/360
        float normalizedZ = Mathf.DeltaAngle(minZ, zRotation) + minZ;

        // Map Z rotation to [0,1] scrub range
        float t = Mathf.InverseLerp(minZ, maxZ, normalizedZ);
        scrub = Mathf.Clamp01(t);

        if (animator != null)
        {
            animator.Play(animationStateName, 0, scrub);
            //animator.speed = 0f; // Pause the animator so it doesn't play automatically
        }

        // Play audio while animation is scrubbing (not at start or end)
        if (audioSource != null)
        {
            if (scrub > 0.02f && scrub < 1f)
            {
                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
            else
            {
                if (audioSource.isPlaying)
                    audioSource.Pause();
            }
        }
    }
}
