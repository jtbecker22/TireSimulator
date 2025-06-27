using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class rotationAnimation : MonoBehaviour
{


    [SerializeField]
    private StageTrigger rotator;

    public XRNode controllerNode = XRNode.RightHand; // Which controller to use
    public Vector3 rotationAxis = Vector3.up;
    private float speed = 590f;               // Degrees per second
    public float maxRevolutions = 3f;
    
    private float totalRotated = 0f;
    private float maxDegrees => maxRevolutions * 360f;

    void Update()
    {
        // Get the device (controller)
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);

        // Read the joystick's horizontal movement
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickInput))
        {
            float inputX = joystickInput.x;

            if (Mathf.Abs(inputX) > 0.1f && Mathf.Abs(totalRotated) < maxDegrees)
            {
                float rotationThisFrame = inputX * speed * Time.deltaTime;

                // Clamp to prevent over-rotation
                float remaining = maxDegrees - Mathf.Abs(totalRotated);
                if (Mathf.Abs(rotationThisFrame) > remaining)
                    rotationThisFrame = Mathf.Sign(rotationThisFrame) * remaining;
                Vector3 worldAxis = transform.parent.TransformDirection(rotationAxis);

                transform.RotateAround(this.gameObject.transform.parent.position, worldAxis, rotationThisFrame);
                totalRotated += Mathf.Abs(rotationThisFrame);
            }
        }
        if(totalRotated >= (maxRevolutions*360))
        {
            //print("test");
            rotator.finishRotation = true;
        }
        //print(totalRotated);
    }
}


