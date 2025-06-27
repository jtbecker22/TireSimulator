using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToLug : MonoBehaviour
{
    public GameObject[] interactableStages;
    public string grabbableTag = "Grabbable"; // <- New field for tag name

    private int currentStageIndex = 0;

    public void TriggerNextStage(GameObject CurrentLugNut)
    {
        if (currentStageIndex >= interactableStages.Length) return;

        GameObject current = interactableStages[currentStageIndex];

        GameObject next = (currentStageIndex + 1 < interactableStages.Length)
            ? interactableStages[currentStageIndex + 1]
            : null;

        // ✅ Change tag to allow grabbing
        CurrentLugNut.tag = grabbableTag;

        if (next != null)
        {
            next.SetActive(true);

            

            // ✅ Enable grabbing component if needed
            var grab = CurrentLugNut.GetComponent<XRGrabInteractable>();
            if (grab != null)
                grab.enabled = true;
        }

        if (current != null)
        {
            Destroy(current);
        }

        currentStageIndex++;
    }
}



//6 nuts
//6 childs for each nut 
//if wrench hit nut1, then nut1 child setActive
//then nut1 become grabbable
//nut2 become next trigger in the list
//i


