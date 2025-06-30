using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSnap : MonoBehaviour
{

    Transform parentTransform;

    [SerializeField]
    private List<GameObject> LugNuts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nut"))
        {
            parentTransform = other.gameObject.transform.parent;
            //activate one nut at a time with list, use current nut again to ensure one at a time
            parentTransform.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
