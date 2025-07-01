using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    void Update()
    {
        Vector3 euler = transform.localEulerAngles;
        euler.z = Mathf.Repeat(euler.z, 180f); // Ensures Z is always 0-360
        transform.localEulerAngles = euler;
    }
}
