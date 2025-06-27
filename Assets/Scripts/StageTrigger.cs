using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StageTrigger : MonoBehaviour
{
    //[SerializeField]
    //private SnapToLug manager;

    [SerializeField]
    private GameObject nextNut;

    [SerializeField]
    private wrenchManager managerWrench;

    [SerializeField]
    private tireManager managerTire;

    int index;

    public bool finishRotation;

    Transform parentTransform;
    private void Start()
    {
        this.GetComponent<XRGrabInteractable>().enabled = false;
        //this.GetComponent<BoxCollider>().isTrigger = true;
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wrench")) 
        {
            //print(this.transform.name);
            //manager.TriggerNextStage(other.gameObject);
            //Destroy(other.transform.parent.gameObject);
            //
            //other.GetComponent<XRGrabInteractable>().enabled = false;
            print(this.gameObject);
            if (this.gameObject != managerWrench.currentNut || managerWrench.LugNuts.Count - 1 == index) { return; }
            parentTransform = other.gameObject.transform.parent;
            parentTransform.SetPositionAndRotation(this.transform.GetChild(0).position, this.transform.GetChild(0).rotation);
            parentTransform.gameObject.SetActive(false);
            //other.gameObject.transform.parent.SetActive(false);
            this.transform.GetChild(0).gameObject.SetActive(true);
            //print(other.transform.parent.gameObject);
            
            
            //Add rotation feature
            //use update:
            //if rotate
            //then make nut grabbable
           // this.GetComponent<XRGrabInteractable>().enabled = true;


            /*if (nextNut != null)
            {
                nextNut.GetComponent<StageTrigger>().enabled = true;
            }*/
            //foreach (KeyValuePair<GameObject, bool> entry in managerWrench.LugNuts)
            // {
            //if (entry.Key == this.gameObject)
            //{
            //int index = managerWrench.LugNuts.IndexOf(this.gameObject);
           // managerWrench.currentNut = managerWrench.LugNuts[index+1];
               // }
           // }
            

           // this.GetComponent<StageTrigger>().enabled = false;
        }
        
    }

    private void Update()
    {
        if (finishRotation) {


            //Add rotation feature
            //use update:
            //if rotate
            //then make nut grabbable
            //this.GetComponent<XRGrabInteractable>().enabled = true;

            index = managerWrench.LugNuts.IndexOf(this.gameObject);
            //if(not null)
            print(index);
            print(managerWrench.LugNuts.Count);
            if (managerWrench.LugNuts.Count - 1 > index) {
                print("if)");
                managerWrench.currentNut = managerWrench.LugNuts[index + 1]; 
                this.GetComponent<XRGrabInteractable>().enabled = true;
                this.transform.GetChild(0).gameObject.SetActive(false);
                parentTransform.gameObject.SetActive(true);
                managerWrench.enableDisableNut();
                
            }
            else
            {
                print("else");
                this.GetComponent<XRGrabInteractable>().enabled = true;
                this.transform.GetChild(0).gameObject.SetActive(false);
                parentTransform.gameObject.SetActive(true);
                managerTire.flatTire.GetComponent<MeshCollider>().enabled = true;
                this.GetComponent<StageTrigger>().enabled = false;

            }



        }
    }

}
