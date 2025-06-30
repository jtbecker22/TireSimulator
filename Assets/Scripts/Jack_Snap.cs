using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack_Snap : MonoBehaviour
{
    public GameObject heldObject;         // The object the player is holding
    public Transform snapTarget;          // The position to snap to
    public GameObject objectToActivate;   // The object to activate when snapped
    public float snapDistance = 1.0f;     // How close is "close enough"

    void Update()
    {
        if (heldObject != null && snapTarget != null)
        {
            float distance = Vector3.Distance(heldObject.transform.position, snapTarget.position);

            if (distance <= snapDistance)
            {
                // Snap: destroy held object, activate the target object
                Destroy(heldObject);
                heldObject = null;

                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(true);
                }
            }
        }
    }
}
