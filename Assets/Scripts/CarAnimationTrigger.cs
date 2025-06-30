using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimationTrigger : MonoBehaviour
{
    public Animator carAnimator;       // Assign the car's Animator here
    public string animationTrigger = "RaiseCar"; // Set up this trigger in the Animator
    public float movementThreshold = 0.01f;      // Prevent tiny jitters from triggering

    private float lastY;
    private bool animationPlayed = false;

    void Start()
    {
        lastY = transform.position.y;
    }

    void Update()
    {
        float currentY = transform.position.y;
        float deltaY = currentY - lastY;

        if (deltaY > movementThreshold && !animationPlayed)
        {
            Debug.Log("Car jack is rising. Triggering car animation.");
            carAnimator.SetTrigger(animationTrigger);
            animationPlayed = true;
        }

        lastY = currentY;
    }

    public void ResetTrigger()
    {
        animationPlayed = false;
    }
}
