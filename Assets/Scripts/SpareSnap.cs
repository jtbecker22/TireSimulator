using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpareSnap : MonoBehaviour
{

    [SerializeField]
    private GameObject spare;

    Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spare"))   
        {
            parentTransform = other.gameObject.transform.parent;
            parentTransform.gameObject.SetActive(false);
            spare.gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.SetActive(true);
            this.transform.GetChild(3).gameObject.SetActive(true);
            this.transform.GetChild(4).gameObject.SetActive(true);
            this.transform.GetChild(5).gameObject.SetActive(true);

        }
    }
            // Update is called once per frame
            void Update()
    {
        
    }
}
