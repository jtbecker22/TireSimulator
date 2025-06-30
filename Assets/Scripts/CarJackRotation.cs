using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(XRGrabInteractable))]
public class CarJackRotation : MonoBehaviour
{
    public float savedZRotation = 0f; // Stores the Z-axis rotation when released

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Save the current local Z-axis rotation
        savedZRotation = transform.localEulerAngles.z;
        Debug.Log("Saved Z Rotation: " + savedZRotation);
    }

    void OnDestroy()
    {
        // Clean up the event subscription
        if (grabInteractable != null)
            grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
