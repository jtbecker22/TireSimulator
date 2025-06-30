using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JackSnapReverse : MonoBehaviour
{
    public GameObject otherCarJack; // Assign the other car jack in the Inspector

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (otherCarJack != null)
        {
            otherCarJack.SetActive(true); // Enable the other car jack
        }
        gameObject.SetActive(false); // Disable this car jack
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }
}
