using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSnap : MonoBehaviour
{

    Transform parentTransform;

    [SerializeField]
    private GameObject lugNut;
    //private List<GameObject> LugNuts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nut"))
        {
            print(other.gameObject.name);
            //parentTransform = other.gameObject.transform.parent;
            //parentTransform.gameObject.SetActive(false);
            
            lugNut.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
