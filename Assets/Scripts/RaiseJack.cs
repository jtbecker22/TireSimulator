using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RaiseJack : MonoBehaviour
{
    [SerializeField]
    private StageTrigger rotator;

    [Header("Proximity Points")]
    public Transform toolPoint; // Assign: empty GameObject on Car Jack Tool
    public Transform jackPoint; // Assign: empty GameObject on Car Jack

    public XRNode controllerNode = XRNode.RightHand; // Which controller to use
    public Vector3 rotationAxis = Vector3.up;
    private float speed = 10f;               // Degrees per second
    public float maxRevolutions = 1; //Total Rotation

    private float totalRotated = 0f;
    private float maxDegrees => maxRevolutions * 360f;

    private float proximityThreshold = 0.3f; // Distance in meters

    void Update()
    {
        if (toolPoint == null || jackPoint == null)
            return;

        float distance = Vector3.Distance(toolPoint.position, jackPoint.position);

        if (distance <= proximityThreshold)
        {
            // Get the device (controller)
            InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);

            // Read the joystick's horizontal movement
            if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickInput))
            {
                float inputX = joystickInput.x;

                if (Mathf.Abs(inputX) > 0.1f)
                {
                    float rotationThisFrame = inputX * speed * Time.deltaTime;
                    float newTotalRotated = totalRotated + rotationThisFrame;

                    // Clamp newTotalRotated to [1, maxDegrees]
                    if (newTotalRotated < 1f)
                    {
                        rotationThisFrame -= (newTotalRotated - 1f); // Only rotate back to 1 degree
                        newTotalRotated = 1f;
                    }
                    else if (newTotalRotated > maxDegrees)
                    {
                        rotationThisFrame -= (newTotalRotated - maxDegrees); // Only rotate up to maxDegrees
                        newTotalRotated = maxDegrees;
                    }

                    Vector3 worldAxis = transform.TransformDirection(rotationAxis);
                    transform.RotateAround(this.gameObject.transform.position, worldAxis, rotationThisFrame);
                    totalRotated = newTotalRotated;

                    // Lock Z rotation to 0-360 degrees
                    Vector3 euler = transform.localEulerAngles;
                    euler.z = Mathf.Repeat(euler.z, 360f);
                    transform.localEulerAngles = euler;
                }
            }
        }

        // Optional: handle when fully rotated
        if (Mathf.Approximately(totalRotated, maxDegrees))
        {
            //print("test");
            //rotator.finishRotation = true;
        }
        //print(totalRotated);
    }
}
