using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InstructionManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text InstructionBox;

    [SerializeField]
    private Instructions InstructionList;

    [SerializeField]
    private GameObject Arrow;



    [SerializeField]
    int N;
    // Start is called before the first frame update
    void Start()
    {
        print(InstructionBox.text);

        InstructionBox.text = "Today is Wednesday";



    }


    // function 
    // Step 1. when user finish a certain step (logic to inplement in the future) -> int N ---- Alternative for now, is 
    // Step2. Change the InstructionBox.text to the right instruction in instruction list  -> get the text for Instructions[N]

    // Update is called once per frame
    void Update()
    {

        InstructionBox.text = InstructionList.instructions[N].instructionText;

        Vector3 TargetPos = InstructionList.instructions[N].ArrowObjectTransform.position;
        Quaternion TargetRot = InstructionList.instructions[N].ArrowObjectTransform.rotation;

        Arrow.transform.SetPositionAndRotation(TargetPos, TargetRot);

        print(InstructionList.instructions[N].instructionText);

    }

    public void NextButton()
    {
        N++;
        Debug.Log("N: " + N);
    }

    public void BackButton()
    {
        N--;
        Debug.Log("N: " + N);
    }

}
