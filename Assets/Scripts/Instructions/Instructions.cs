using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

[System.Serializable]

public class CarInstruction
{
    public string instructionText;
    public Transform ArrowObjectTransform;
}

public class Instructions : MonoBehaviour
{
    public List<CarInstruction> instructions;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
